using Microsoft.WindowsAzure.Storage.Table;

namespace StoryTeller.Alexa.Entities
{
    public class AlexaSessionEntity : TableEntity
    {
        public string SessionId
        {
            get => RowKey;
            set => RowKey = value;
        }

        public string UserId
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string CurrentStory { get; set; }
    }
}
