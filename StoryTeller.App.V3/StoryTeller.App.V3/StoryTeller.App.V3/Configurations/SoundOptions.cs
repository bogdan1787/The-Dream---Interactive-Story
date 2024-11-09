using System;
using StoryTeller.App.V3.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoryTeller.App.V3.Configurations
{
    public class SoundOptions
    {
        private static readonly object _locker = new object();
        private static SoundOptions _instance;
        public static SoundOptions Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new SoundOptions();
                        }
                    }
                }

                return _instance;
            }
        }

        public void TriggerBackgroundSound()
        {
            var backgroundSound = Preferences.Get("backgroundSound", true);
            Preferences.Set("backgroundSound", !backgroundSound);
            OnOptionsModified();
        }

        public void TriggerEffectsSound()
        {
            var effectsSound = Preferences.Get("effectsSound", true);
            Preferences.Set("effectsSound", !effectsSound);
            OnOptionsModified();
        }

        public bool BackgroundSoundEnabled()
        {
            return Preferences.Get("backgroundSound", true);
        }

        public bool EffectsSoundEnabled()
        {
            return Preferences.Get("effectsSound", true);
        }

        public event EventHandler OptionsModified;

        protected virtual void OnOptionsModified()
        {
            OptionsModified?.Invoke(this, EventArgs.Empty);
        }
    }
}
