using System;

namespace StoryTeller.Core.Model
{
    public class StoryChapter
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string SsmlText { get; set; }

        public StoryChapterDecision[] Decisions { get; set; }

        public Func<DecisionsTaken, bool> DecisionFunc { get; set; }
        public bool Final { get; set; }
    }
}
