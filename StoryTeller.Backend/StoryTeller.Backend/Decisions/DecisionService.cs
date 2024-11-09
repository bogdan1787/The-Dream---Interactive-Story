using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StoryTeller.Backend.Decisions.Model;


namespace StoryTeller.Backend.Decisions
{
    public class DecisionService : IDecisionService
    {
        public async Task<int> GetDecisionsTakenStatistics(DecisionsTakenStatisticsEntity decisionsTaken)
        {
            var decisionsTable = await GetDecisionsTable();
            var rangeQuery = new TableQuery<DecisionsTakenStatisticsEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, decisionsTaken.Application));
            var decisions = await decisionsTable.ExecuteQueryAsync(rangeQuery);
            if (decisions == null || decisions.Count == 0)
                return 100;

            var totalDecisions = decisions.Sum(d => d.Count);
            var currentTotalDecisions = decisions.FirstOrDefault(d => d.DecisionsTaken == decisionsTaken.DecisionsTaken);
            if (currentTotalDecisions is null)
                return 0;

            return currentTotalDecisions.Count * 100 / totalDecisions;

        }

        public async Task InsertDecisionsTaken(DecisionsTakenStatisticsEntity decisionsTaken)
        {
            var decisionsTable = await GetDecisionsTable();
            var retrieveOperation =
                TableOperation.Retrieve<DecisionsTakenStatisticsEntity>(decisionsTaken.Application,
                    decisionsTaken.DecisionsTaken);

            var retrievedResult = await decisionsTable.ExecuteAsync(retrieveOperation);
            if (retrievedResult.Result != null &&
                retrievedResult.Result is DecisionsTakenStatisticsEntity existingDecisionsTaken)
            {
                decisionsTaken.Count = existingDecisionsTaken.Count;
            }

            decisionsTaken.Count += 1;
            await decisionsTable.ExecuteAsync(TableOperation.InsertOrReplace(decisionsTaken));
        }

        public async Task<CloudTable> GetDecisionsTable()
        {
            var storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            var tableClient = storageAccount.CreateCloudTableClient();
            var decisionsTable = tableClient.GetTableReference("decisionsTable");
            await decisionsTable.CreateIfNotExistsAsync();
            return decisionsTable;
        }
    }
}
