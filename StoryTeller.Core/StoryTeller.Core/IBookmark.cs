using System;
using System.Collections.Generic;
using System.Text;
using StoryTeller.Core.Model;

namespace StoryTeller.Core
{
    public interface IBookmark
    {
        bool Exists();
        int GetCurrentChapter();
        DecisionsTaken GetDecisionsTaken();
        void Save(int currentChapter, DecisionsTaken decisionsTaken);
        void Delete();
    }
}
