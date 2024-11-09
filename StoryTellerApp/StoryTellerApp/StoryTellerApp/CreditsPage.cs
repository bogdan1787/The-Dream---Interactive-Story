using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StoryTellerApp
{
    public class CreditsPage : ContentPage
    {
        public CreditsPage()
        {
            this.Title = "Credits";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label { Text = "CREDITS",FontAttributes = FontAttributes.Bold},
                    new Label { Text = "Game created by Bogdan Enache"},
                    new Label { Text = "Story by Dana Enache"}
                }
            };
        }
    }
}