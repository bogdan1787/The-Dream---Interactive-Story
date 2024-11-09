using System;

namespace StoryTeller.Model
{
    public class Story
    {
        public string Title { get; set; }
        public StoryChapter[] Chapters { get; set; }
    }
}
