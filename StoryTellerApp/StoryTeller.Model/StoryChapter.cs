using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.Model
{
    public class StoryChapter
    {
        public int Number { get; set; }
        public char Decision { get; set; }
        public string Text { get; set; }

        public StoryChapterDecision[] Decisions { get; set; }
    }
}
