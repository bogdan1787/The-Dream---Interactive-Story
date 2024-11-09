using System;
using StoryTeller.App.V3.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoryTeller.App.V3.Configurations
{
    public class GameOptions
    {
        private static readonly object _locker = new object();
        private static GameOptions _instance;
        public static GameOptions Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new GameOptions();
                        }
                    }
                }
                return _instance;
            }
        }
        public void TriggerGameHints()
        {
            var gameHints = Preferences.Get("gameHints", false);
            Preferences.Set("gameHints", !gameHints);
            OnOptionsModified();
        }

        public bool GameHintsEnabled()
        {
            return Preferences.Get("gameHints", false);
        }

        public void SetGameFontSize(double fontSize)
        {
            Preferences.Set("gameFontSize", fontSize);
        }

        public double GameFontSize()
        {
            var value = Preferences.Get("gameFontSize","20");

            if (double.TryParse(value, out var dValue))
            {
                return dValue;
            }

            return 20;
        }

        public event EventHandler OptionsModified;

        protected virtual void OnOptionsModified()
        {
            OptionsModified?.Invoke(this, EventArgs.Empty);
        }
    }
}
