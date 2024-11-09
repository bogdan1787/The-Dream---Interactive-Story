using System.IO;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;

namespace StoryTeller.App.V3.UI.SKCanvasTemplates
{
    public class FirstScreenSKCanvasView : SKCanvasView
    {

        public FirstScreenSKCanvasView()
        {
            this.PaintSurface += FirstScreenSKCanvasView_PaintSurface;
            this.HeightRequest = 200;
        }

        private void FirstScreenSKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var svg = LoadSvg("1stscreen.svg");
            var surface = e.Surface;
            var canvas = surface.Canvas;

            var width = e.Info.Width;
            var height = e.Info.Height;

            // clear the surface
            canvas.Clear(SKColors.Transparent);

            // the page is not visible yet
            if (svg == null)
                return;

            // calculate the scaling need to fit to screen
            var scaleX = width / svg.Picture.CullRect.Width;
            var scaleY = height / svg.Picture.CullRect.Height;
            var matrix = SKMatrix.CreateScale(scaleX, scaleY);

            using (var paint = new SKPaint())
            {
                paint.ColorFilter = SKColorFilter.CreateBlendMode(
                    SKColors.White,       // the color, also `(SKColor)0xFFFF0000` is valid
                    SKBlendMode.SrcIn); // use the source color
                // draw the svg
                canvas.DrawPicture(svg.Picture, ref matrix, paint);
            }
        }

        private SKSvg LoadSvg(string svgName)
        {
            // create a new SVG object
            var svg = new SKSvg();

            // load the SVG document from a stream
            using (var stream = GetImageStream(svgName))
                svg.Load(stream);

            return svg;
        }

        private static Stream GetImageStream(string svgName)
        {
            var type = typeof(FirstScreenSKCanvasView).GetTypeInfo();
            var assembly = type.Assembly;

            var abc = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.UI.Images.{svgName}");
            return abc;
        }
    }
}
