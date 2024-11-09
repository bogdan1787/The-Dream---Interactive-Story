using System;
using StoryTeller.App.V3.UI;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoryTeller.App.V3.Story.Pages
{
    public class CreditsPage : BasePage
    {
        private readonly int _titleFontSize = 25;
        private readonly int _textFontSize = 18;
        public CreditsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.Title = "Credits";
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
                Text = "CREDITS",
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = _titleFontSize,
                TextColor = Color.White
            });

            stackLayout.Children.Add(new Label()
            {
                Text = "Development by Bogdan Enache",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = _textFontSize,
                TextColor = Color.White
            });

            stackLayout.Children.Add(new Label()
            {
                Text = "Story by Dana Enache",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = _textFontSize,
                TextColor = Color.White
            });
            stackLayout.Children.Add(new Label()
            {
                Text = "Quality assurance by Petrica Stoica",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = _textFontSize,
                TextColor = Color.White
            });
            stackLayout.Children.Add(new BoxView() { HeightRequest = 20 });


            stackLayout.Children.Add(new Label()
            {
                Text = "SOUND",
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = _titleFontSize,
                TextColor = Color.White
            });

            var tubularSoundLabel = TubularSoundLabel();
            stackLayout.Children.Add(tubularSoundLabel);

            var universalPublicDomainDedicationLabel = UniversalPublicDomainDedicationLabel();
            stackLayout.Children.Add(universalPublicDomainDedicationLabel);



            AbsoluteLayout.SetLayoutBounds(SkCanvasView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(SkCanvasView, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(stackLayout, new Rectangle(0.5, 0.5, -1, -1));
            AbsoluteLayout.SetLayoutFlags(stackLayout, AbsoluteLayoutFlags.PositionProportional);
        }

        private Label TubularSoundLabel()
        {
            var fs = new FormattedString();
            var sp1 = new Span()
            {
                FontSize = _textFontSize,
                TextColor = Color.White,
                Text = @"TUBULAR 007",
                TextDecorations = TextDecorations.Underline
            };
            var sandyGestureRecognizer = new TapGestureRecognizer();
            sandyGestureRecognizer.Tapped += async (s, e) =>
            {
                await Launcher.OpenAsync(new Uri(@"https://freesound.org/people/sandyrb/sounds/110406/"));
            };
            sp1.GestureRecognizers.Add(sandyGestureRecognizer);

            fs.Spans.Add(sp1);

            fs.Spans.Add(new Span()
            {
                FontSize = _textFontSize,
                TextColor = Color.White,
                Text = @" part of pack Sandyrb Tubular Bells 02. ",
            });

            var sp = new Span()
            {
                FontSize = _textFontSize,
                TextColor = Color.White,
                Text = @"Attribution License",
                TextDecorations = TextDecorations.Underline
            };
            fs.Spans.Add(sp);
            var licenseGestureRecognizer = new TapGestureRecognizer();
            licenseGestureRecognizer.Tapped += async (s, e) =>
            {
              await Launcher.OpenAsync(new Uri(@"https://creativecommons.org/licenses/by/3.0/"));
            };
            sp.GestureRecognizers.Add(licenseGestureRecognizer);

            var label = new Label()
            {
                FormattedText = fs,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            return label;
        }

        private Label UniversalPublicDomainDedicationLabel()
        {
            var fs = new FormattedString();
            fs.Spans.Add(new Span()
            {
                FontSize = _textFontSize,
                TextColor = Color.White,
                Text = @"All other sounds are licensed as "
            });
            var sp = new Span()
            {
                FontSize = _textFontSize,
                TextColor = Color.White,
                Text = @"CC0 1.0 Universal (CC0 1.0) Public Domain Dedication",
                TextDecorations = TextDecorations.Underline
            };
            fs.Spans.Add(sp);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await Launcher.OpenAsync(new Uri(@"https://creativecommons.org/publicdomain/zero/1.0/"));
            };
            sp.GestureRecognizers.Add(tapGestureRecognizer);
            var label = new Label()
            {
                FormattedText = fs,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            return label;
        }
    }
}