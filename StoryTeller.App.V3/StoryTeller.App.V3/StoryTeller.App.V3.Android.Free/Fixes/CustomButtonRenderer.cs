
using Android.Content;
using StoryTeller.App.V2.Droid.Fixes;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace StoryTeller.App.V2.Droid.Fixes
{
    public class CustomButtonRenderer : Xamarin.Forms.Platform.Android.ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {

        }
    }
}
