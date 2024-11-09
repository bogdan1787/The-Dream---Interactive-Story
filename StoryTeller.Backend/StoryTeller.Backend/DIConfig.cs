using Autofac;
using AzureFunctions.Autofac.Configuration;
using NLog;
using StoryTeller.Backend.Decisions;

namespace StoryTeller.Backend
{
    public class DIConfig
    {
        public DIConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<DecisionService>().As<IDecisionService>();
                builder.RegisterType<Logger>().As<ILogger>();
            }, functionName);
        }
    }
}
