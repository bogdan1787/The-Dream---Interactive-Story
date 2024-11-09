using Autofac;
using AzureFunctions.Autofac.Configuration;
using StoryTeller.Core;

namespace StoryTeller.Alexa
{
    public class DIConfig
    {
        public DIConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<AlexaStorySession>().As<IStorySession>();
            }, functionName);
        }
    }
}
