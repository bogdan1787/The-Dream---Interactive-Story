using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StoryTeller.Alexa.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Alexa
{
    public class AlexaStorySession : IStorySession
    {
        public async Task<string> GetStoryAsync(string userId, string sessionId)
        {
            var table = await GetAlexaStorySessionTable();

            return "the dream";
        }

        public async Task OpenStoryAsync(string userId, string sessionId, string story)
        {
            var table = await GetAlexaStorySessionTable();
            await table.ExecuteAsync(TableOperation.InsertOrReplace(new AlexaSessionEntity()
            {
                CurrentStory = story,
                SessionId = sessionId.Replace(".",string.Empty).Substring(sessionId.Length / 2),
                UserId = userId.Replace(".",string.Empty).Substring(userId.Length / 2)
            }));
        }

        private async Task<CloudTable> GetAlexaStorySessionTable()
        {
            var storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("alexaStorySessionTable");
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            return table;
        }
    }
}
