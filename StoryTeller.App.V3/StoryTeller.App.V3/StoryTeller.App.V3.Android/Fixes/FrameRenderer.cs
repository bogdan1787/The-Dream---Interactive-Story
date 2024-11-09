using Android.Content;
using StoryTeller.App.V2.Droid.Fixes;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Frame), typeof(CustomFrameRenderer))]
namespace StoryTeller.App.V2.Droid.Fixes
{
    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context)
        {

        }

    }
}