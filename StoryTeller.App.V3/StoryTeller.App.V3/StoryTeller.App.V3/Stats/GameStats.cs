using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoryTeller.App.V3.Stats
{
    public class GameStats
    {
        public bool PlayedOnce { get; set; }

        public bool WatchedRewardAd { get; set; }

        public static GameStats GetStats()
        {
            try
            {
                var data = Preferences.Get("gameStats", string.Empty);
                if (string.IsNullOrWhiteSpace(data))
                    return new GameStats();

                var gameStats = JsonConvert.DeserializeObject<GameStats>(data);
                return gameStats;
            }
            catch
            {
                return new GameStats();
            }
        }

        public static void SetPlayedOnce()
        {
            var stats = GetStats();
            if (stats.PlayedOnce) return;
            stats.PlayedOnce = true;
            var data = JsonConvert.SerializeObject(stats);
            Preferences.Set("gameStats", data);
        }
    }
}
