using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using StoryTeller.App.V3.Interfaces;
using Xamarin.Forms;

namespace StoryTeller.App.V3.UI.SKCanvasTemplates
{
    public class TopBarSkCanvasView : SKCanvasView, IDisposable, IInitialize
    {
        private bool _rewind = false;
        private bool _up = true;
        private float _phase;
        private string _text = string.Empty;
        public Timer Timer { get; set; }
        private readonly Random _random;
        private List<Tuple<int, int>> _randomPath;
        private int _pathDrawn = 1;
        private int _maxPathToDraw = 10;

        public TopBarSkCanvasView()
        {
            this.PaintSurface += TopBarSkCanvasView_PaintSurface;
            this.HeightRequest = 50;
            _random = new Random();
            Initialize();
        }

        private void GenerateRandomPath(int width, int height)
        {
            _randomPath = new List<Tuple<int, int>>();
            var x = 0;
            while (x < width)
            {
                x += _random.Next(10, 30);
                _randomPath.Add(Tuple.Create(x, _random.Next(height - 20, height)));
            }
        }

        private void TopBarSkCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            canvas.Clear();

            using (var paint = new SKPaint()
            {
                Color = SKColors.White,
                Style = SKPaintStyle.StrokeAndFill,
                StrokeCap = SKStrokeCap.Round,
                StrokeJoin = SKStrokeJoin.Round,
                StrokeWidth = 2
            })
            {
                if (_randomPath == null) GenerateRandomPath(info.Width, info.Height);
                var path = new SKPath();
                path.MoveTo(0, info.Height);
                foreach (var pathPart in _randomPath.Take(_pathDrawn))
                {
                    path.LineTo(pathPart.Item1, pathPart.Item2);
                }

                if (_pathDrawn < _maxPathToDraw)
                    _pathDrawn += 1;

                if (_rewind && _pathDrawn > _maxPathToDraw)
                    _pathDrawn -= 1;

                // draw the path
                paint.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, 3);
                canvas.DrawPath(path, paint);

                if (_phase >= 1)
                {
                    _up = false;
                }

                if (_phase <= 0)
                {
                    _up = true;
                }

                if (_up)
                {
                    _phase = _phase + (float)0.01;
                }
                else
                {
                    _phase = _phase - (float)0.01;
                }
                paint.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, 2 + _phase * 2);

                if (!string.IsNullOrWhiteSpace(_text))
                {
                    paint.TextSize = 64.0f;
                    // Find the text bounds
                    var textBounds = new SKRect();
                    paint.MeasureText(_text, ref textBounds);

                    // Calculate offsets to center the text on the screen
                    var xText = info.Width / 2f - textBounds.MidX;
                    var yText = info.Height / 2f - textBounds.MidY;

                    canvas.DrawText(_text, xText, yText, paint);
                }
            }
        }

        public void Dispose()
        {
            Timer?.Dispose();
            Timer = null;
        }

        public void SetText(string text)
        {
            _text = text;
            _phase = 3;
            this.InvalidateSurface();
        }

        public void SetMaxPathToDraw(double percentage)
        {
            if (_randomPath == null) return;
            _rewind = false;
            _maxPathToDraw = Convert.ToInt32(_randomPath.Count * percentage);
        }

        public void Initialize()
        {
            Timer = new Timer(state =>
                {
                    var view = (SKCanvasView)state;
                    if (view.Opacity > 0.01f)
                    {
                        Device.BeginInvokeOnMainThread(() => { view.InvalidateSurface(); });
                    }

                }, this, TimeSpan.FromMilliseconds(10),
                TimeSpan.FromMilliseconds(10));
        }

        public void Rewind()
        {
            if (_randomPath == null) return;
            _maxPathToDraw = 10;
            _rewind = true;
        }
    }
}
