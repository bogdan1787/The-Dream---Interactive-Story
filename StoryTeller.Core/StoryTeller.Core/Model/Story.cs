namespace StoryTeller.Core.Model
{
    public class Story
    {
        public string Language { get; set; }
        public string Title { get; set; }
        public StoryChapter[] Chapters { get; set; }
    }
}
