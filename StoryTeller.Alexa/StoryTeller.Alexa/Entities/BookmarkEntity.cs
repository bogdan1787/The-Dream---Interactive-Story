using Microsoft.WindowsAzure.Storage.Table;

namespace StoryTeller.Alexa.Entities
{
    public class BookmarkEntity : TableEntity
    {
        public string UserId
        {
            get => RowKey;
            set => RowKey = value;
        }

        public string Story
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public int CurrentChapter { get; set; }

        public string DecisionsTaken { get; set; }
    }
}
