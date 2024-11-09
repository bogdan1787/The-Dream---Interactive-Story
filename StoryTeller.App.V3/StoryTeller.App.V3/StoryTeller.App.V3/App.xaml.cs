using System;
using System.Reflection;
using Plugin.SimpleAudioPlayer;
using StoryTeller.App.V3.Configurations;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace StoryTeller.App.V3
{
    public partial class App : Application
    {
        private readonly ISimpleAudioPlayer _audioPlayer;
        public static View AdsView;
        public App(bool noAds = true, View adsView = null)
        {
            Preferences.Set("NoAds", noAds);
            InitializeComponent();
            _audioPlayer = CrossSimpleAudioPlayer.Current;
            AdsView = adsView;
            MainPage = new NavigationPage(new MainMenuPage());
            SoundOptions.Instance.OptionsModified += Instance_OptionsModified;
        }

        private void Instance_OptionsModified(object sender, EventArgs e)
        {
            if (SoundOptions.Instance.BackgroundSoundEnabled() && !_audioPlayer.IsPlaying)
            {
                _audioPlayer.Play();
                _audioPlayer.Loop = true;
            }
            else if (!SoundOptions.Instance.BackgroundSoundEnabled() && _audioPlayer.IsPlaying)
            {
                _audioPlayer.Pause();
            }
        }

        protected override void OnStart()
        {
            if (_audioPlayer.IsPlaying) return;
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var audioStream = assembly.GetManifestResourceStream("StoryTeller.App.V3.Sounds." + "BackgroundMusic.mp3");
            _audioPlayer.Load(audioStream);
            if (SoundOptions.Instance.BackgroundSoundEnabled())
            {
                _audioPlayer.Play();
                _audioPlayer.Loop = true;
            }
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            _audioPlayer.Pause();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            if (SoundOptions.Instance.BackgroundSoundEnabled())
            {
                _audioPlayer.Play();
            }

            // Handle when your app resumes
        }
    }
}
