using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoryTeller.Logic.Interfaces;
using StoryTeller.Model;
using Xamarin.Forms;

namespace StoryTeller.Logic
{
    public class StoryReader
    {
        private readonly Story _story;
        public int CurrentChapterNumber { get; set; }
        public DecisionsTaken DecisionsTaken { get; set; }
        public int LastChapter => _story.Chapters.Select(d => d.Number).Max();
        public string SaveFileName => _story.Title.Replace(" ", string.Empty) + ".dat";

        public StoryReader(Story story, bool loadLastSavedState = false)
        {
            _story = story;
            DecisionsTaken = new DecisionsTaken();
            if (loadLastSavedState)
                LoadLastSavedState();
        }

        public StoryChapter Read()
        {
            DependencyService.Get<IFile>().SaveFile(SaveFileName, $"{CurrentChapterNumber}" + Environment.NewLine + DecisionsTaken);

            var decision = DecisionsTaken.Get(CurrentChapterNumber);

            StoryChapter chapter;
            CurrentChapterNumber++;
            if (LastChapter > CurrentChapterNumber)
            {
                chapter = _story.Chapters.FirstOrDefault(d =>
                    d.Number == CurrentChapterNumber && (decision == char.MaxValue || d.Decision == decision));
            }
            else
            {
                chapter = _story.Chapters.FirstOrDefault(d => d.Number == CurrentChapterNumber && DecisionsTaken.Equals(((StoryEndingChapter)d).DecisionsTaken));
                if (chapter == null)
                {
                    chapter = _story.Chapters.FirstOrDefault(d => d.Number == CurrentChapterNumber && ((StoryEndingChapter)d).DecisionsTaken == null);
                }
            }

            return chapter;
        }

        public void Decide(char decision)
        {
            DecisionsTaken.Add(CurrentChapterNumber, decision);

        }

        public void Close()
        {
            DependencyService.Get<IFile>().DeleteFile(SaveFileName);
        }

        private void LoadLastSavedState()
        {
            var data = DependencyService.Get<IFile>().LoadFile(SaveFileName);
            if (string.IsNullOrWhiteSpace(data)) return;
            var lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (int.TryParse(lines[0], out var currentChapter))
            {
                CurrentChapterNumber = currentChapter;
            }

            if (lines.Length > 1)
            {
                DecisionsTaken = DecisionsTaken.Load(string.Join(Environment.NewLine, lines.Skip(1).ToList()));
            }
        }

        public bool ExistsLastSavedState()
        {
            return DependencyService.Get<IFile>().FileExists(SaveFileName);
        }
    }
}
