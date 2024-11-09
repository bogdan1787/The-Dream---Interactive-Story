using MarcTron.Plugin.Controls;
using System;
using Xamarin.Forms;

namespace StoryTeller.App.AdsWrapper.V3
{
    public class BannerAdView
    {
        public static View GetView()
        {
            var adsView = new MTAdView();
            adsView.AdsId = "ca-app-pub-5186050242016519/1501252030";
#if DEBUG
            adsView.AdsId = "ca-app-pub-3940256099942544/6300978111";
#endif
            adsView.PersonalizedAds = true;
            adsView.HeightRequest = 50;
            return adsView;
            //contentStackLayout.Children.Add(adsView);
        }
    }
}
