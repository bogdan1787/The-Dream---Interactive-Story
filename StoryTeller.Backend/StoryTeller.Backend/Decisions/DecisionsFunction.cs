using System.IO;
using System.Threading.Tasks;
using AzureFunctions.Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using NLog;
using StoryTeller.Backend.Decisions.Model;

namespace StoryTeller.Backend.Decisions
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class DecisionsFunction
    {
        [FunctionName("DecisionsStatisticsGet")]
        public static async Task<IActionResult> GetDecisions([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, [Inject] IDecisionService decisionService)
        {
            var body = await req.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(body))
                return new BadRequestObjectResult("Empty body");
            var decisionTaken = JsonConvert.DeserializeObject<DecisionsTakenStatisticsEntity>(body);
            var results = await decisionService.GetDecisionsTakenStatistics(decisionTaken);

            return new JsonResult(results);
        }

        [FunctionName("InsertDecisions")]
        public static async Task<IActionResult> InsertDecisions([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, [Inject] IDecisionService decisionService)
        {
            var body = await req.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(body))
                return new BadRequestObjectResult("Empty body");

            var decisionTaken = JsonConvert.DeserializeObject<DecisionsTakenStatisticsEntity>(body);
            await decisionService.InsertDecisionsTaken(decisionTaken);

            return new OkObjectResult("OK");
        }
    }
}
