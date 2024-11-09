using System.Collections.Generic;
using System.Linq;
using StoryTeller.Core.Model;

namespace StoryTeller.Core.Logic
{
    public class StoryReader
    {
        private readonly IBookmark _bookmark;
        private readonly Story _story;
        public int CurrentChapterNumber { get; set; }
        public DecisionsTaken DecisionsTaken { get; set; }
        public int LastChapter => _story.Chapters.Select(d => d.Number).Max();

        public StoryReader(Story story, IBookmark bookmark, bool loadLastSavedState = false)
        {
            _story = story;
            _bookmark = bookmark;
            DecisionsTaken = new DecisionsTaken();
            if (loadLastSavedState)
                LoadLastSavedState();
        }

        public StoryChapter Read()
        {
            _bookmark.Save(CurrentChapterNumber, DecisionsTaken);

            CurrentChapterNumber++;
            if (CurrentChapterNumber > _story.Chapters.Max(d => d.Number))
            {
                CurrentChapterNumber = _story.Chapters.Max(d => d.Number);
            }

            var chapter = _story.Chapters.FirstOrDefault(d => d.Number == CurrentChapterNumber &&
                                                          (d.DecisionFunc != null && d.DecisionFunc(DecisionsTaken)));
            if (chapter == null)
            {
                chapter = _story.Chapters.FirstOrDefault(d => d.Number == CurrentChapterNumber);
            }

            return chapter;
        }

        public string[] GetStoryDecisionColors()
        {
            var colors = new List<string>();
            for (var i = 1; i <= CurrentChapterNumber; i++)
            {
                var chapter = _story.Chapters.FirstOrDefault(d => d.Number == i);
                if (chapter?.Decisions != null && chapter.Decisions.Length > 0)
                {
                    var decisionTaken = DecisionsTaken.Get(i);
                    var decision = chapter.Decisions.FirstOrDefault(d => d.Decision == decisionTaken);
                    if (!string.IsNullOrWhiteSpace(decision?.Color))
                    {
                        colors.Add(decision.Color);
                    }
                }
            }

            return colors.ToArray();
        }

        public void Decide(char decision)
        {
            DecisionsTaken.Add(CurrentChapterNumber, decision);
        }

        public void Close()
        {
            _bookmark.Delete();
        }

        private void LoadLastSavedState()
        {
            CurrentChapterNumber = _bookmark.GetCurrentChapter();
            DecisionsTaken = _bookmark.GetDecisionsTaken();
        }

        public bool ExistsLastSavedState()
        {
            return _bookmark.Exists();
        }
    }
}
