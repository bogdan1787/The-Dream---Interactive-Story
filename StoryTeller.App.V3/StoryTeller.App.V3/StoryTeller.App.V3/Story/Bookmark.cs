using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoryTeller.Core;
using StoryTeller.Core.Model;
using Xamarin.Essentials;

namespace StoryTeller.App.V3.Story
{
    public class Bookmark : IBookmark
    {
        public bool Exists()
        {
            return Preferences.Get("exists", false);
        }

        public int GetCurrentChapter()
        {
            return Preferences.Get("currentChapter", 1);
        }

        public DecisionsTaken GetDecisionsTaken()
        {
            var data = Preferences.Get("decisionsTaken", string.Empty);
            if (string.IsNullOrWhiteSpace(data)) return new DecisionsTaken();
            var decisionsTaken = DecisionsTaken.Load(data);
            return decisionsTaken;
        }

        public void Save(int currentChapter, DecisionsTaken decisionsTaken)
        {
            Preferences.Set("exists", true);
            Preferences.Set("currentChapter", currentChapter);
            Preferences.Set("decisionsTaken", decisionsTaken.ToString());
        }

        public void Delete()
        {
            Preferences.Remove("exists");
        }
    }
}
