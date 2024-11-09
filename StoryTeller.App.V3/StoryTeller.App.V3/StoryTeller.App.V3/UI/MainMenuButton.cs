using Xamarin.Forms;

namespace StoryTeller.App.V3.UI
{
    public class MainMenuButton : Button
    {
        public MainMenuButton(string content)
        {
            BackgroundColor = Color.Transparent;
            BorderWidth = 2;
            CornerRadius  = 5;
            BorderColor = Color.White;
            TextColor = Color.White;
            Text = content;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.CenterAndExpand;
            WidthRequest = 200;
            Margin = new Thickness(0, 2, 0, 0);
        }
    }
}
