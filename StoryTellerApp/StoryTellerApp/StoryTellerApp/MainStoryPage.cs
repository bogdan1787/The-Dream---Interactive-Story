using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Vibrate;
using StoryTeller.Logic;
using StoryTeller.Model;
using Xamarin.Forms;

namespace StoryTellerApp
{
    public class MainStoryPage : ContentPage
    {
        private readonly StoryReader _reader;
        private DateTime _lastVibration;
        private StackLayout ContentPage => (StackLayout)((ScrollView)Content).Content;

        public MainStoryPage(bool continueStory = false)
        {
            var story = StoryFactory.GetStory();
            _reader = new StoryReader(story, continueStory);
            this.Title = story.Title;

            Content = new ScrollView() { Content =  new StackLayout() };
            ((ScrollView)Content).Scrolled += (o, e) =>
            {
                if (!(_lastVibration == null) && !((DateTime.Now - _lastVibration).TotalMinutes > 2)) return;
                var random = new Random();
                if (random.Next(0, 10) > 5)
                {
                    CrossVibrate.Current.Vibration(TimeSpan.FromSeconds(0.5));
                    _lastVibration = DateTime.Now;
                }
            };
            
            Read();
        }

        private void Read()
        {
            ContentPage.Children.Clear();
            var chapter = _reader.Read();

            ContentPage.Children.Add(new Label() { Text = chapter.Text, FontSize = 20 });
            if (chapter.Decisions?.Length > 0)
            {
                var random = new Random(chapter.GetHashCode());
                foreach (var storyChapterDecision in chapter.Decisions.OrderBy(d => random.Next()))
                {
                    var decisionButton = new Button() { Text = storyChapterDecision.Text };
                    decisionButton.Clicked += async (s, e) =>
                    {
                        _reader.Decide(storyChapterDecision.Decision);
                        await FadeOutOtherDecisions(decisionButton);
                        Read();
                    };
                    ContentPage.Children.Add(decisionButton);
                }
                return;
            }

            if (chapter is StoryEndingChapter)
            {
                var continueButton = new Button() { Text = "Final" };
                continueButton.Clicked += async (s, e) => { _reader.Close(); await Navigation.PopAsync(); };
                ContentPage.Children.Add(continueButton);
            }
            else
            {
                var continueButton = new Button() { Text = "Continuă" };
                continueButton.Clicked += (s, e) =>
                {
                    Read();
                };
                ContentPage.Children.Add(continueButton);
            }
        }

        private Task FadeOutOtherDecisions(Button decisionButton)
        {
            foreach (var contentPageChild in ContentPage.Children)
            {
                if (contentPageChild is Button button && contentPageChild != decisionButton)
                {
                    return button.FadeTo(0, 1000);
                }
            }
            return Task.Delay(1);
        }
    }
}