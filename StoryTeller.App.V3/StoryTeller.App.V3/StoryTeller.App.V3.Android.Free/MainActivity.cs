using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using StoryTeller.App.AdsWrapper.V3;

namespace StoryTeller.App.V3.Droid.Free
{
    [Activity(Label = "The Dream - Interactive Story", Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(Android.Graphics.Color.Black);
            }

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            try
            {
                base.OnCreate(bundle);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

         
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(false, BannerAdView.GetView()));
        }
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}

