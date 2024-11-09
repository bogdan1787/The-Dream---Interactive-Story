using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SkiaSharp;
using StoryTeller.App.V3.Configurations;
using StoryTeller.App.V3.Helpers;
using StoryTeller.App.V3.Sounds.Effects;
using StoryTeller.App.V3.Stats;
using StoryTeller.App.V3.UI;
using StoryTeller.App.V3.UI.SKCanvasTemplates;
using StoryTeller.App.V3.Web;
using StoryTeller.Core.Logic;
using StoryTeller.Core.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace StoryTeller.App.V3.Story.Pages
{
    public class MainStoryPage : BasePage
    {
        private readonly StoryReader _reader;
        private const int TimeToShowTapAnywereToContinue = 20; //seconds
        private Timer _timerTapAnywhere;
        private string _percentage;

        public MainStoryPage(bool continueStory = false)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var story = StoryFactory.GetStory(LanguageOption.Language, "The dream");
            _reader = new StoryReader(story, new Bookmark(), continueStory);
            this.Title = story.Title;


            InitializeTimerTapAnywhere();
            GenerateContentLayout();
        }

        private void InitializeTimerTapAnywhere()
        {
            _timerTapAnywhere = new Timer(state =>
                {
                    var continueCanvas = Find<TopBarSkCanvasView>();
                    if (continueCanvas == null) return;

                    var allButtons = StoryStackLayout.Children.Where(d => d is Button);
                    var text = allButtons.All(d => Convert.ToInt32(d.Opacity) == 0)
                        ? "Tap anywhere to continue"
                        : "Choose...";
                    continueCanvas.SetText(text);

                    _timerTapAnywhere.Change(TimeSpan.FromHours(10), TimeSpan.FromHours(10));

                }, this, TimeSpan.FromSeconds(TimeToShowTapAnywereToContinue),
                TimeSpan.FromSeconds(TimeToShowTapAnywereToContinue));
        }

        private StackLayout StoryStackLayout
        {
            get
            {
                if (!(Content is AbsoluteLayout contentAbsoluteLayout)) return null;
                if (!(contentAbsoluteLayout.Children[1] is StackLayout contentStackLayout)) return null;
                if (!(contentStackLayout.Children.Count > 1 && contentStackLayout.Children[1] is ScrollView scrollview)) return null;
                if (!(scrollview.Content is AbsoluteLayout absoluteLayout)) return null;
                if (!(absoluteLayout.Children.Last() is StackLayout stackLayout)) return null;
                return stackLayout;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _timerTapAnywhere?.Dispose();
            _timerTapAnywhere = null;

            InitializeViews();
        }

        protected override void OnAppearing()
        {
            base.OnDisappearing();
            if (_timerTapAnywhere == null)
            {
                InitializeTimerTapAnywhere();
            }
            InitializeViews();
        }

        protected override List<SKColor> GetBackgroundColors()
        {
            var colors = SkColorsHelper.GetBackgroundColors(_reader.GetStoryDecisionColors());
            return colors;
        }

        public async Task Read()
        {
            var currentFontSize = GameOptions.Instance.GameFontSize();
            await TurnPage();
            SkCanvasView?.InvalidateSurface();
            var chapter = _reader.Read();
            StoryStackLayout.Children.Clear();


            chapter.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ForEach(t =>
            {
                if (string.IsNullOrWhiteSpace(t)) return;

                const string beginItalic = "<i>";
                const string endItalic = "</i>";
                const string beginBold = "<b>";
                const string endBold = "</b>";
                const string tagRegex = @"[^<>]+|<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>";

                var fs = new FormattedString();
                var matchesImgSrc = Regex.Matches(t, tagRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var first = true;
                foreach (Match m in matchesImgSrc)
                {
                    var formattedText = m.Value;
                    var fontAttributes = FontAttributes.None;
                    if (formattedText.Contains(beginItalic) && formattedText.Contains(beginBold))
                    {
                        fontAttributes = FontAttributes.Italic | FontAttributes.Bold;
                    }
                    else if (formattedText.Contains(beginItalic))
                    {
                        fontAttributes = FontAttributes.Italic;
                    }
                    else if (formattedText.Contains(beginBold))
                    {
                        fontAttributes = FontAttributes.Bold;
                    }
                    formattedText = (first ? "        " : string.Empty) + formattedText.Replace(beginItalic, string.Empty).Replace(endItalic, string.Empty)
                        .Replace(beginBold, string.Empty).Replace(endBold, string.Empty);
                    fs.Spans.Add(new Span { Text = formattedText, ForegroundColor = Color.White, FontSize = currentFontSize, FontAttributes = fontAttributes });
                    first = false;
                }

                var label = new Label() { FormattedText = fs, Opacity = 0, InputTransparent = false };
                StoryStackLayout.Children.Add(label);
            });

            if (chapter.Number == 1)
            {
                StoryStackLayout.Children.Insert(0, new FirstScreenSKCanvasView());
            }

            PopulateActions(chapter, StoryStackLayout);
            //var continueCanvas = new ContinueTapSkCanvasView() { Opacity = 0, IsVisible = false };
            //stackLayout.Children.Add(continueCanvas);
            AddGestureTapRecognizer();

            var scrollView = Find<ScrollView>();
            var firstLabel = Find<Label>();
            if (firstLabel != null)
            {
                StoryStackLayout.HeightRequest = firstLabel.Height;
            }
            await Task.WhenAll(firstLabel?.FadeTo(1, 500), scrollView?.FadeTo(1, 500));
            var heightRequestSum = StoryStackLayout.Children.Where(d => Convert.ToInt32(d.Opacity) == 1).Sum(d => d.Height + d.Margin.VerticalThickness + StoryStackLayout.Spacing);
            StoryStackLayout.HeightRequest = heightRequestSum;
        }

        private void PopulateActions(StoryChapter chapter, StackLayout stackLayout)
        {
            if (PopulateDecisions(chapter, stackLayout)) return;
            PopulateStoryFlow(chapter, stackLayout);
            StoryStackLayout.HeightRequest = StoryStackLayout.Children.Sum(d => d.Height + d.Margin.VerticalThickness + StoryStackLayout.Spacing);
        }

        private void PopulateStoryFlow(StoryChapter chapter, StackLayout stackLayout)
        {
            var currentFontSize = GameOptions.Instance.GameFontSize();
            if (chapter.Number == _reader.LastChapter || chapter.Final)
            {
                Task.Factory.StartNew(async () =>
                {
                    _percentage = await PlayersDecisionsWeb();
                });
                var endButton = new Button()
                {
                    Text = LanguageOption.Language == "EN" ? "The End" : "Final",
                    BackgroundColor = Color.Transparent,
                    BorderWidth = 2,
                    CornerRadius = 5,
                    BorderColor = Color.White,
                    TextColor = Color.White,
                    IsVisible = true,
                    Opacity = 0,
                    IsEnabled = false,
                    FontSize = currentFontSize
                };
                endButton.Clicked += async (s, e) =>
                {
                    GameStats.SetPlayedOnce();
                    endButton.IsEnabled = false;
                    if (!string.IsNullOrWhiteSpace(_percentage) && int.TryParse(_percentage, out _))
                    {
                        await DisplayAlert("You are not alone",
                            $"{_percentage}% of all players have chosen the same path", "OK");
                    }
                    _reader.Close();
                    await Navigation.PopAsync();
                };
                stackLayout.Children.Add(endButton);
            }
            else
            {
                var continueButton = new Button()
                {
                    Text = LanguageOption.Language == "EN" ? "Continue" : "Continuă",
                    BackgroundColor = Color.Transparent,
                    BorderWidth = 2,
                    CornerRadius = 5,
                    BorderColor = Color.White,
                    TextColor = Color.White,
                    IsVisible = true,
                    Opacity = 0,
                    IsEnabled = false,
                    FontSize = currentFontSize
                };
                continueButton.Clicked += async (s, e) => { await Read(); };
                stackLayout.Children.Add(continueButton);
            }
        }

        private async Task<string> PlayersDecisionsWeb()
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var httpClient = new HttpClient
                    {
                        BaseAddress = new Uri("https://storytellerbackend20190109045029.azurewebsites.net/")
                    };
                    httpClient.DefaultRequestHeaders.Add("x-functions-key",
                        "KxSKmgUbcRx0HC6OmP/MyjaBYWdYYqGibJ0Kcp649dprkWo4YhrAWA==");
                    var bodyContent = JsonConvert.SerializeObject(new DecisionsTakenStatisticsEntity()
                    {
                        Application = AppInfo.Name,
                        Version = AppInfo.VersionString,
                        DecisionsTaken = _reader.DecisionsTaken.DecisionsAsString
                    });
                    await httpClient.PostAsync(@"/api/InsertDecisions", new StringContent(bodyContent));
                    var result =
                        await httpClient.PostAsync(@"/api/DecisionsStatisticsGet", new StringContent(bodyContent));
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsStringAsync();

                    }
                }
            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }

        private bool PopulateDecisions(StoryChapter chapter, StackLayout stackLayout)
        {
            if (!(chapter.Decisions?.Length > 0)) return false;
            var currentFontSize = GameOptions.Instance.GameFontSize() - 1;
            var random = new Random(chapter.GetHashCode());
            foreach (var storyChapterDecision in chapter.Decisions.OrderBy(d => random.Next()))
            {
                var decisionButton = new Button()
                {
                    Text = storyChapterDecision.Text,
                    BackgroundColor = Color.Transparent,
                    BorderWidth = 2,
                    CornerRadius = 5,
                    BorderColor = GameOptions.Instance.GameHintsEnabled() ? storyChapterDecision.Decision == 'a' ? Color.Red : Color.Green : Color.White,
                    TextColor = Color.White,
                    IsVisible = true,
                    Opacity = 0,
                    IsEnabled = false,
                    FontSize = currentFontSize
                };
                decisionButton.Clicked += async (s, e) =>
                {
                    new SoundHelper().Play(SoundEffect.ChurchBellTubular);
                    lock (_reader)
                    {
                        if (stackLayout.Children.Any(d => d is Button button && button.ClassId == "Decided")) return;
                        decisionButton.ClassId = "Decided";
                    }
                    _reader.Decide(storyChapterDecision.Decision);
                    await FadeOutOtherDecisions(decisionButton);
                    await Read();
                };
                stackLayout.Children.Add(decisionButton);
            }

            return true;
        }

        private async Task TurnPage()
        {
            var scrollView = Find<ScrollView>();
            var continueCanvas = Find<TopBarSkCanvasView>();
            continueCanvas?.Rewind();
            if (scrollView != null) await scrollView.FadeTo(0, 500);
        }

        private Task FadeOutOtherDecisions(Button decisionButton)
        {
            if (!(decisionButton.Parent is StackLayout stackLayout)) return Task.Delay(1);
            var buttonsToFade = new List<Task>();
            foreach (var contentPageChild in stackLayout.Children)
            {
                if (contentPageChild is Button button && contentPageChild != decisionButton)
                {
                    buttonsToFade.Add(button.FadeTo(0, 500));
                }
            }

            if (buttonsToFade.Count > 0) return Task.WhenAll(buttonsToFade.ToArray());
            return Task.Delay(1);
        }

        private void GenerateContentLayout()
        {
            var stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(12, 0, 12, 0)
            };

            var scrollView = new ScrollView()
            {
                Content = new AbsoluteLayout
                {
                    Children =
                    {
                        stackLayout
                    }
                },
                IsClippedToBounds = true,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };

            var contentStackLayout = new StackLayout()
            {
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            contentStackLayout.Children.Add(new TopBarSkCanvasView());
            contentStackLayout.Children.Add(scrollView);
            var noAds = Preferences.Get("NoAds", false);
            if (!noAds && App.AdsView != null)
            {
                contentStackLayout.Children.Add(App.AdsView);
            }

            var absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.Add(SkCanvasView);
            absoluteLayout.Children.Add(contentStackLayout);

            SetContent(absoluteLayout);

            AbsoluteLayout.SetLayoutBounds(contentStackLayout, new Rectangle(1, 1, 1, 1));
            AbsoluteLayout.SetLayoutFlags(contentStackLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(SkCanvasView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(SkCanvasView, AbsoluteLayoutFlags.All);
        }

        private void AddGestureTapRecognizer()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += Tgr_Tapped;

            foreach (var cView in GetAllViews())
            {
                cView.GestureRecognizers.Clear();
                cView.GestureRecognizers.Add(tgr);
            }
        }

        private async void Tgr_Tapped(object sender, EventArgs e)
        {
            if (StoryStackLayout == null) return;
            var continueCanvas = Find<TopBarSkCanvasView>();
            var tasks = new List<Task>();

            _timerTapAnywhere?.Change(TimeSpan.FromSeconds(TimeToShowTapAnywereToContinue), TimeSpan.FromSeconds(TimeToShowTapAnywereToContinue));
            var notVisibleChildren = StoryStackLayout.Children.Where(d => Convert.ToInt32(d.Opacity) == 0).ToArray();
            if (notVisibleChildren.Length > 0)
            {
                var firstNotVisibleChild = notVisibleChildren[0];
                var viewsToBeVisible = new List<View>() { firstNotVisibleChild };
                if (firstNotVisibleChild is Button)
                {
                    var buttons = notVisibleChildren.Where(d => d is Button).ToArray();
                    viewsToBeVisible.AddRange(buttons);
                }
                viewsToBeVisible = viewsToBeVisible.Distinct().ToList();

                var heightRequestSum = StoryStackLayout.Children.Where(d => Convert.ToInt32(d.Opacity) == 1).Sum(d => d.Height + d.Margin.VerticalThickness + StoryStackLayout.Spacing);
                heightRequestSum += viewsToBeVisible.Sum(d => d.Height + d.Margin.VerticalThickness + StoryStackLayout.Spacing);
                StoryStackLayout.HeightRequest = heightRequestSum;

                var scrollView = Find<ScrollView>();
                tasks.Add(scrollView.ScrollToAsync(0, heightRequestSum, true));
                foreach (var view in viewsToBeVisible)
                {
                    view.IsEnabled = true;
                }

                tasks.AddRange(viewsToBeVisible.Select(d => d.FadeTo(1, 500)));

                if (firstNotVisibleChild is Label textLabel && _reader.CurrentChapterNumber > (_reader.LastChapter / 2))
                {
                    if (textLabel.FormattedText.Spans.Sum(d => d.Text.Length) > 300)
                    {
                        Console.WriteLine(textLabel.FormattedText.Spans.Sum(d => d.Text.Length));
                        new SoundHelper().Play(SoundEffect.FourWhispers);
                    }
                }
            }

            if (tasks.Count <= 0) return;

            var visible = StoryStackLayout.Children.Count(d => Convert.ToInt32(d.Opacity) == 1) + tasks.Count - 1;
            var percentage = visible /
                             (double)StoryStackLayout.Children.Count;
            continueCanvas?.SetMaxPathToDraw(percentage);
            continueCanvas?.SetText(string.Empty);
            await Task.WhenAll(tasks.ToArray());
        }
    }
}