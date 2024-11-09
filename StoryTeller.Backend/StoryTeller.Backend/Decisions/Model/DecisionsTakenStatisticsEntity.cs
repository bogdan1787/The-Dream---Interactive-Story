using Microsoft.WindowsAzure.Storage.Table;

namespace StoryTeller.Backend.Decisions.Model
{
    public class DecisionsTakenStatisticsEntity : TableEntity
    {
        public string DecisionsTaken
        {
            get => RowKey;
            set => RowKey = value;
        }

        public string Application
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string Version { get; set; }

        public int Count { get; set; }
    }
}
