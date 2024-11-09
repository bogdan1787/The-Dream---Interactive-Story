using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StoryTeller.Alexa.Entities;
using StoryTeller.Core;
using StoryTeller.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Alexa
{
    public class AlexaBookmark : IBookmark
    {
        private string _userId;
        private string _story;
        public AlexaBookmark(string userId, string story)
        {
            this._userId = userId.Replace(".", string.Empty).Substring(userId.Length / 2);
            this._story = story.Replace(" ", string.Empty);
        }
        public void Delete()
        {
            var table = GetAlexaBookmarkTable().ConfigureAwait(false).GetAwaiter().GetResult();

            var bookMarkEntity = new BookmarkEntity()
            {
                Story = _story,
                UserId = _userId
            };

            table.ExecuteAsync(TableOperation.Delete(bookMarkEntity)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public bool Exists()
        {

            var table = GetAlexaBookmarkTable().ConfigureAwait(false).GetAwaiter().GetResult();

            var retrieveOperation = TableOperation.Retrieve<BookmarkEntity>(_story, _userId);
            var retrievedResult = table.ExecuteAsync(retrieveOperation).ConfigureAwait(false).GetAwaiter().GetResult();
            if (retrievedResult.Result != null &&
                retrievedResult.Result is BookmarkEntity)
            {
                return true;
            }

            return false;
        }

        public int GetCurrentChapter()
        {
            var table = GetAlexaBookmarkTable().ConfigureAwait(false).GetAwaiter().GetResult();

            var retrieveOperation = TableOperation.Retrieve<BookmarkEntity>(_story, _userId);
            var retrievedResult = table.ExecuteAsync(retrieveOperation).ConfigureAwait(false).GetAwaiter().GetResult();
            if (retrievedResult.Result != null &&
                retrievedResult.Result is BookmarkEntity existingBookmarkEntity)
            {
                return existingBookmarkEntity.CurrentChapter;
            }
            return 1;
        }

        public DecisionsTaken GetDecisionsTaken()
        {
            var table = GetAlexaBookmarkTable().ConfigureAwait(false).GetAwaiter().GetResult();

            var retrieveOperation = TableOperation.Retrieve<BookmarkEntity>(_story, _userId);
            var retrievedResult = table.ExecuteAsync(retrieveOperation).ConfigureAwait(false).GetAwaiter().GetResult();
            if (retrievedResult.Result != null &&
                retrievedResult.Result is BookmarkEntity existingBookmarkEntity)
            {
                var data = existingBookmarkEntity.DecisionsTaken;
                if (string.IsNullOrWhiteSpace(data)) return new DecisionsTaken();
                var decisionsTaken = DecisionsTaken.Load(data);
                return decisionsTaken;
            }
            return new DecisionsTaken();
        }

        public void Save(int currentChapter, DecisionsTaken decisionsTaken)
        {
            var table = GetAlexaBookmarkTable().ConfigureAwait(false).GetAwaiter().GetResult();

            var retrieveOperation = TableOperation.Retrieve<BookmarkEntity>(_story, _userId);

            var bookMarkEntity = new BookmarkEntity()
            {
                Story = _story,
                UserId = _userId,
                CurrentChapter = 1
            };

            var retrievedResult = table.ExecuteAsync(retrieveOperation).ConfigureAwait(false).GetAwaiter().GetResult();
            if (retrievedResult.Result != null &&
                retrievedResult.Result is BookmarkEntity existingBookmarkEntity)
            {
                bookMarkEntity = existingBookmarkEntity;
            }

            table.ExecuteAsync(TableOperation.InsertOrReplace(bookMarkEntity)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<CloudTable> GetAlexaBookmarkTable()
        {
            var storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process));
            var tableClient = storageAccount.CreateCloudTableClient();
            var decisionsTable = tableClient.GetTableReference("alexaBookmarkTable");
            await decisionsTable.CreateIfNotExistsAsync().ConfigureAwait(false);
            return decisionsTable;
        }
    }
}
