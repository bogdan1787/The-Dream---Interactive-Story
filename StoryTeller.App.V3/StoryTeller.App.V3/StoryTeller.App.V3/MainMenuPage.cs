using System;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using StoryTeller.App.V3.Configurations;
using StoryTeller.App.V3.Interfaces;
using StoryTeller.App.V3.Story;
using StoryTeller.App.V3.Story.Pages;
using StoryTeller.App.V3.UI;
using StoryTeller.Core.Logic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoryTeller.App.V3
{
    public class MainMenuPage : BasePage
    {
        private readonly MainMenuButton _continueButton;
        public MainMenuPage()
        {
            var stackLayout = new StackLayout() { BackgroundColor = Color.Transparent };
            Content = new AbsoluteLayout
            {
                Children = {
                    SkCanvasView,
                    stackLayout
                }
            };

            stackLayout.Children.Add(new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                TextColor = Color.AliceBlue,
                Text = "The Dream"
            });
            _continueButton = new MainMenuButton("Continue")
            {
                IsVisible = false
            };
            stackLayout.Children.Add(_continueButton);
            _continueButton.Clicked += async (s, e) =>
            {
                var mainStoryPage = new MainStoryPage(true);
                await Navigation.PushAsync(mainStoryPage);
                await mainStoryPage.Read();
            };
            var newGameButton = new MainMenuButton("New game");
            stackLayout.Children.Add(newGameButton);
            newGameButton.Clicked += async (s, e) =>
            {
                var noAds = Preferences.Get("NoAds", false);
                if (!noAds)
                {
                    var acceptedAdsLocal = Preferences.Get("AcceptedAds", false);
                    if (!acceptedAdsLocal)
                    {
                        var action = await DisplayActionSheet("To continue playing you need to confirm that you have read our", "Buy game", "Confirm","Privacy Policy");
                        if(action == "Privacy Policy")
                        {
                            await Launcher.OpenAsync(new Uri(@"https://www.dabogames.com/the-dream-privacy-policy"));
                        }
                        else if(action == "Buy game")
                        {
                            await Launcher.OpenAsync(new Uri(@"https://play.google.com/store/apps/details?id=com.dabogames.StoryTeller.Game.V1"));
                        }
                        else if(action == "Confirm")
                        {
                            Preferences.Set("AcceptedAds", true);
                        }
                    }
                }
                var acceptedAds = Preferences.Get("AcceptedAds", false);
                if(noAds || acceptedAds)
                {
                    var mainStoryPage = new MainStoryPage();
                    await Navigation.PushAsync(mainStoryPage);
                    await mainStoryPage.Read();
                }
            };


            var optionsButton = new MainMenuButton("Options");
            stackLayout.Children.Add(optionsButton);
            optionsButton.Clicked += async (s, e) => await Navigation.PushAsync(new OptionsPage());

            var creditsButton = new MainMenuButton("Credits");
            stackLayout.Children.Add(creditsButton);
            creditsButton.Clicked += async (s, e) => await Navigation.PushAsync(new CreditsPage());

            AbsoluteLayout.SetLayoutBounds(SkCanvasView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(SkCanvasView, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(stackLayout, new Rectangle(0.5, 0.5, -1, -1));
            AbsoluteLayout.SetLayoutFlags(stackLayout, AbsoluteLayoutFlags.PositionProportional);
        }

        protected override void PaintSurfaceAfterBackground(SKCanvas canvas, SKPaintSurfaceEventArgs events)
        {
            var info = events.Info;
            using (var path = SKPath.ParseSvgPathData(SvgDrawings.Book.Path))
            {

                var strokePaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.White,
                    StrokeWidth = 20,
                    StrokeJoin = SKStrokeJoin.Round,
                };

                canvas.Translate(info.Width / 3f * 1.9f, info.Height / 4f * 3.50f);
                var scale = (info.Width / SvgDrawings.Book.Scale) / 100f;
                canvas.Scale(scale, -scale);
                canvas.DrawPath(path, strokePaint);
            }
        }

        protected override void OnAppearing()
        {
            var story = StoryFactory.GetStory(LanguageOption.Language, "The dream");
            var reader = new StoryReader(story, new Bookmark());
            _continueButton.IsVisible = reader.ExistsLastSavedState();

            base.OnAppearing();
        }
    }
}
