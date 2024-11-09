using System;
using System.IO;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using StoryTeller.Core.Logic;
using Alexa.NET.Response.Ssml;
using AzureFunctions.Autofac;
using StoryTeller.Core;
using StoryTeller.Core.Model;

namespace StoryTeller.Alexa
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class AlexaFunction
    {

        [FunctionName("Alexa")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log, [Inject] IStorySession storySession)
        {
            string json = await req.ReadAsStringAsync();
            var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(json);

            var requestType = skillRequest.GetRequestType();

            SkillResponse response = null;

            if (requestType == typeof(LaunchRequest))
            {
                var reprompt = new Reprompt("Would you like to start the story: The Dream?");
                var mainText = "Welcome to Dabo Games! Guide your character and help them make decisions that can affect the course of the story, and ultimately, how it ends! There is only one story available: The Dream. Would you like to start the story?";
                response = ResponseBuilder.Ask(mainText, reprompt);
            }
            else if (requestType == typeof(IntentRequest))
            {
                var intentRequest = skillRequest.Request as IntentRequest;
                if (intentRequest?.Intent.Name == "AMAZON.HelpIntent")
                {
                    response = ResponseBuilder.Tell("Help response");
                    response.Response.ShouldEndSession = false;
                }
                else if (intentRequest?.Intent.Name == "AMAZON.FallbackIntent")
                {
                    response = ResponseBuilder.Tell("Fallback response");
                    response.Response.ShouldEndSession = false;
                }
                else if (intentRequest?.Intent.Name == "AMAZON.StopIntent" || intentRequest?.Intent.Name == "AMAZON.CancelIntent")
                {
                    var speech = new SsmlOutputSpeech
                    {
                        Ssml = "<speak><amazon:effect name=\"whispered\">Will see you in your dream.</amazon:effect></speak>"
                    };
                    response = ResponseBuilder.TellWithCard(speech, "Bye", "Will see you in your dream.");
                    response.Response.ShouldEndSession = true;
                }
                else if (intentRequest?.Intent.Name == "openstory" || intentRequest?.Intent.Name == "AMAZON.YesIntent")
                {
                    var story = StoryFactory.GetStories().First();
                    if (intentRequest.Intent.Slots?.Count > 0 && intentRequest.Intent.Slots["story"] != null)
                    {
                        var value = intentRequest.Intent.Slots["story"].Value;
                        if (!string.IsNullOrWhiteSpace(value))
                            story = value;
                    }
                    var bookmark = new AlexaBookmark(skillRequest.Context.System.User.UserId, story);
                    var storyReader = new StoryReader(StoryFactory.GetStory("EN", story), bookmark);
                    response = BuildStorySkillResponse(storyReader);
                    await storySession.OpenStoryAsync(skillRequest.Context.System.User.UserId, skillRequest.Session.SessionId, story);

                    response.Response.ShouldEndSession = false;
                }
                else if (intentRequest?.Intent.Name == "readstory")
                {
                    var story = await storySession.GetStoryAsync(skillRequest.Context.System.User.UserId, skillRequest.Session.SessionId);
                    var bookmark = new AlexaBookmark(skillRequest.Context.System.User.UserId, story);
                    var storyReader = new StoryReader(StoryFactory.GetStory("EN", story), bookmark);
                    var storyChapter = storyReader.Read();
                    var responseText = storyChapter.Text.Replace("<i>", string.Empty).Replace("</i>", string.Empty);
                    response = ResponseBuilder.Tell(responseText);
                    response.Response.ShouldEndSession = false;
                }
                else if (intentRequest?.Intent.Name == "decide")
                {
                    var story = await storySession.GetStoryAsync(skillRequest.Context.System.User.UserId, skillRequest.Session.SessionId);
                    var bookmark = new AlexaBookmark(skillRequest.Context.System.User.UserId, story);
                    var storyReader = new StoryReader(StoryFactory.GetStory("EN", story), bookmark, true);
                    storyReader.Read();
                    var decision = intentRequest.Intent.Slots["decision"].Value;
                    storyReader.Decide(decision[0]);
                    response = BuildStorySkillResponse(storyReader);
                    response.Response.ShouldEndSession = false;
                }
            }


            return new OkObjectResult(response);
        }

        private static SkillResponse BuildStorySkillResponse(StoryReader storyReader)
        {
            var responseText = new StringBuilder();
            StoryChapter storyChapter = null;
            var readEverything = false;
            while (!readEverything)
            {
                storyChapter = storyReader.Read();
                var storyText = storyChapter.SsmlText ?? storyChapter.Text;
                responseText.AppendLine(storyText.Replace("<i>", string.Empty).Replace("</i>", string.Empty));
                if (storyChapter.Decisions?.Length > 0)
                {
                    readEverything = true;
                }
            }

            var card = new StringBuilder();
            var decisionsText = new StringBuilder();
            if (storyChapter.Decisions?.Length > 0)
            {
                foreach (var decision in storyChapter.Decisions)
                {
                    decisionsText.AppendLine($"<p><say-as interpret-as=\"characters\">{decision.Decision}</say-as><break time=\"1s\"/>{decision.Text}</p>");
                    card.AppendLine($"{decision.Decision}.{decision.Text}");
                }
            }

            var speech = new SsmlOutputSpeech
            {
                Ssml = $"<speak>{responseText} You can:{decisionsText}</speak>"
            };
            var response = ResponseBuilder.TellWithCard(speech, "Decisions", card.ToString());
            return response;
        }
    }
}
