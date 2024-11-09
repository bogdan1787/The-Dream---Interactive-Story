using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;
using StoryTeller.App.V3.Configurations;
using StoryTeller.App.V3.Sounds.Effects;

namespace StoryTeller.App.V3.Helpers
{
    public class SoundHelper : IDisposable
    {
        private const string EffectsAssemblyNamespace = "StoryTeller.App.V3.Sounds.Effects.";
        private ISimpleAudioPlayer _audioPlayer;
        private readonly SoundOptions _soundOptions;
        public SoundHelper()
        {
            _audioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            _soundOptions = SoundOptions.Instance;

        }

        public void Play(SoundEffect sound)
        {
            if (!_soundOptions.EffectsSoundEnabled()) return;
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var audioStream = assembly.GetManifestResourceStream(EffectsAssemblyNamespace + sound.SoundName);
            _audioPlayer.Load(audioStream);
            _audioPlayer.Volume = sound.Volume;
            _audioPlayer.Play();
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(Convert.ToInt32(_audioPlayer.Duration) * 1000);
                Dispose();
            });
        }


        public void Dispose()
        {
            _audioPlayer?.Dispose();
            _audioPlayer = null;
        }
    }
}
