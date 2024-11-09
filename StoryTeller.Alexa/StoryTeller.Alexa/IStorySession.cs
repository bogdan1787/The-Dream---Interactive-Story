using StoryTeller.Alexa.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Alexa
{
    public interface IStorySession
    {
        Task OpenStoryAsync(string userId, string sessionId, string story);
        Task<string> GetStoryAsync(string userId, string sessionId);
    }
}
