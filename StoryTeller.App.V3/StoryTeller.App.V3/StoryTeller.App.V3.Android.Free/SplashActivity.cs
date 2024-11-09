using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using StoryTeller.App.V3.Droid.Free;
using System.Threading;
using System.Threading.Tasks;

namespace StoryTeller.App.V3.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(Android.Graphics.Color.Black);
            }
            base.OnCreate(savedInstanceState, persistentState);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            var startupWork = new Task(SimulateStartup);
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        void SimulateStartup()
        {
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-5186050242016519~3145506191");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}