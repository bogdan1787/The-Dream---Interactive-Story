using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.App.V3.Interfaces
{
    public interface IRewardVideoAd
    {
        void Initialize(string adUnitId);

        void Show();

        bool Rewarded();

        bool Finished();
    }
}
