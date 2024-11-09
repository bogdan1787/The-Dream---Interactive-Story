using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using StoryTeller.App.V3.Configurations;
using StoryTeller.App.V3.Interfaces;
using StoryTeller.App.V3.Stats;
using StoryTeller.App.V3.UI;
using Xamarin.Forms;

namespace StoryTeller.App.V3.Story.Pages
{
    public class OptionsPage : BasePage
    {
        public OptionsPage()
        {
            this.Title = "Options";
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
                Text = "Options",
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                TextColor = Color.White
            });

            var backgroundMusicSwitch = new Switch()
            {
                IsToggled = SoundOptions.Instance.BackgroundSoundEnabled()
            };
            backgroundMusicSwitch.Toggled += (s, e) => { SoundOptions.Instance.TriggerBackgroundSound(); };
            stackLayout.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label()
                    {
                        TextColor = Color.White,
                        Text = "Background music",
                        WidthRequest = 250,
                        FontSize = 20
                    },
                    backgroundMusicSwitch
                }
            });

            var soundEffectsSwitch = new Switch()
            {
                IsToggled = SoundOptions.Instance.EffectsSoundEnabled()
            };
            soundEffectsSwitch.Toggled += (s, e) => { SoundOptions.Instance.TriggerEffectsSound(); };
            stackLayout.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label()
                    {
                        TextColor = Color.White,
                        Text = "Sound effects",
                        WidthRequest = 250,
                        FontSize = 20
                    },
                    soundEffectsSwitch
                }
            });

            stackLayout.Children.Add(new BoxView() { HeightRequest = 20 });

            var currentFontSize = GameOptions.Instance.GameFontSize();
            var storyTextLabel = new Label()
            {
                TextColor = Color.White,
                Text = "Story sample text",
                WidthRequest = 300,
                FontSize = currentFontSize,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var fontSizeBar = new Slider(10, 30, currentFontSize);
            fontSizeBar.ValueChanged += (s, e) =>
            {
                GameOptions.Instance.SetGameFontSize(e.NewValue);
                storyTextLabel.FontSize = e.NewValue;
            };
            stackLayout.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label()
                    {
                        TextColor = Color.White,
                        Text = "Story Font size",
                        WidthRequest = 250,
                        FontSize = 20
                    },
                    fontSizeBar
                }
            });
            stackLayout.Children.Add(storyTextLabel);


            stackLayout.Children.Add(new BoxView() { HeightRequest = 20 });
            var gameStats = GameStats.GetStats();

            AddGameHintsDecisionView(gameStats, stackLayout);



            AbsoluteLayout.SetLayoutBounds(SkCanvasView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(SkCanvasView, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(stackLayout, new Rectangle(0.5, 0.5, -1, -1));
            AbsoluteLayout.SetLayoutFlags(stackLayout, AbsoluteLayoutFlags.PositionProportional);
        }

        private static void AddGameHintsDecisionView(GameStats gameStats, StackLayout stackLayout)
        {
            var switchView = new Switch()
            {
                IsToggled = GameOptions.Instance.GameHintsEnabled()
            };

            switchView.Toggled += (s, e) => { GameOptions.Instance.TriggerGameHints(); };
            if (!gameStats.PlayedOnce)
            {
                stackLayout.Children.Add(new Label()
                {
                    TextColor = GameStats.GetStats().PlayedOnce ? Color.White : Color.Gray,
                    Text = "This option will be unlocked after you finish the story for the first time",
                    WidthRequest = 300,
                    FontSize = 15,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                switchView.IsEnabled = false;
            }

            stackLayout.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label()
                    {
                        TextColor = gameStats.PlayedOnce ? Color.White : Color.Gray,
                        Text = "Decision hints",
                        WidthRequest = 250,
                        FontSize = 20
                    },
                    switchView
                }
            });
        }

        protected override void PaintSurfaceAfterBackground(SKCanvas canvas, SKPaintSurfaceEventArgs events)
        {
            var info = events.Info;
            var surface = events.Surface;
            using (var path = SKPath.ParseSvgPathData(SvgDrawings.MusicalNote.Path))
            {
                var strokePaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.White,
                    StrokeWidth = 20,
                    StrokeJoin = SKStrokeJoin.Round
                };


                canvas.Translate(info.Width / 1.9f, info.Height / 4f * 3.5f);
                var scale = (info.Width / SvgDrawings.MusicalNote.Scale) / 100f;
                canvas.Scale(scale, -scale);
                canvas.RotateDegrees(180);
                canvas.DrawPath(path, strokePaint);
            }
        }
    }
}