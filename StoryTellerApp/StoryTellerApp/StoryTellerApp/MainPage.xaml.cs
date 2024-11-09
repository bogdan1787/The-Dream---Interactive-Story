using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryTeller.Logic;
using StoryTeller.Logic.Interfaces;
using StoryTeller.Model;
using Xamarin.Forms;

namespace StoryTellerApp
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = Title = "Story Teller - Main";
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainStoryPage());
        }

        private async void CreditsButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreditsPage());
        }

        private async void ContinueButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainStoryPage(true));
        }

        protected override void OnAppearing()
        {
            var story = StoryFactory.GetStory();
            var reader = new StoryReader(story);
            //this.ContinueButton.IsEnabled = reader.ExistsLastSavedState();
            base.OnAppearing();
        }
    }
}
