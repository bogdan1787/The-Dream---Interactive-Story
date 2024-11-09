using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using StoryTeller.App.V3.Helpers;
using StoryTeller.App.V3.Interfaces;
using Xamarin.Forms;

namespace StoryTeller.App.V3.UI
{

    public class BasePage : ContentPage
    {
        protected readonly SKCanvasView SkCanvasView;
        private IEnumerable<View> _allViews;
        private readonly List<SKPoint> _touchLocations;
        private readonly Timer _timer;
        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            SkCanvasView = new SKCanvasView();
            SkCanvasView.PaintSurface += SkCanvasView_OnPaintSurface;
            SkCanvasView.EnableTouchEvents = true;
            SkCanvasView.Touch += SkCanvasView_Touch;
            _touchLocations = new List<SKPoint>();
            _timer = new Timer { Interval = 10 };
            _timer.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SkCanvasView.InvalidateSurface();
            if (_touchLocations.Count > 0)
            {
                _touchLocations.RemoveAt(0);
            }
            if (_touchLocations.Count == 0)
            {
                _timer.Stop();
            }
        }

        private void SkCanvasView_Touch(object sender, SKTouchEventArgs e)
        {
            _touchLocations.Add(e.Location);
            if (_touchLocations.Count > 20)
            {
                _touchLocations.RemoveAt(0);
            }
            e.Handled = true;
            SkCanvasView.InvalidateSurface();
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                if (e.Location == _touchLocations.Last())
                {
                    _timer.Start();
                }
            });

        }

        protected virtual List<SKColor> GetBackgroundColors()
        {
            var colors = SkColorsHelper.GetBackgroundColors(null);
            return colors;
        }

        private void SkCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            // clear the canvas / view

            var colors = GetBackgroundColors();

            var startPoint = new SKPoint(0, 0);
            var endPoint = new SKPoint(info.Width, 0);

            var shader = SKShader.CreateLinearGradient(startPoint, endPoint, colors.ToArray(), null, SKShaderTileMode.Clamp);

            canvas.Clear();

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Shader = shader
            };
            canvas.DrawRect(new SKRect(0, 0, info.Width, info.Height), paint);

            if (_touchLocations.Count > 1)
            {
                using (var paint2 = new SKPaint())
                {
                    paint2.Shader = SKShader.CreateRadialGradient(
                        _touchLocations.Last(),
                        10,
                        new SKColor[] { SKColors.Black, SKColors.White },
                        null,
                        SKShaderTileMode.Mirror);
                    for (var i = 0; i < _touchLocations.Count - 2; i++)
                    {
                        canvas.DrawLine(_touchLocations[i], _touchLocations[i + 1], paint2);
                    }
                }
            }

            PaintSurfaceAfterBackground(canvas, e);
        }

        protected virtual void PaintSurfaceAfterBackground(SKCanvas canvas, SKPaintSurfaceEventArgs events)
        {

        }

        internal void DisposeViews()
        {
            foreach (var child in GetAllViews())
            {
                if (child is IDisposable dispChild)
                    dispChild.Dispose();
            }
        }

        internal void InitializeViews()
        {
            foreach (var child in GetAllViews())
            {
                if (child is IInitialize initChild)
                    initChild.Initialize();
            }
        }

        internal IEnumerable<View> GetAllViews()
        {
            _allViews = GetAllViews(Content);
            return _allViews;
        }

        private IEnumerable<View> GetAllViews(View view)
        {
            if (view == null) return new List<View>();

            var localList = new List<View> { view };
            var type = view.GetType();
            var props = type.GetProperties().Where(d => d.Name == "Children");
            var propertyInfos = props as PropertyInfo[] ?? props.ToArray();
            foreach (var prop in propertyInfos)
            {
                var value = prop?.GetValue(view, null);
                IEnumerable<View> childViews;
                if (value is IReadOnlyList<View> list)
                {
                    childViews = list.AsEnumerable();
                }
                else if (value is IReadOnlyList<Element> readList)
                {
                    childViews = readList.Cast<View>();
                }
                else
                {
                    childViews = value as IEnumerable<View>;
                }

                if (childViews == null) break;
                foreach (var childView in childViews)
                {
                    localList.AddRange(GetAllViews(childView));
                }
            }

            return localList.Distinct();
        }

        internal T Find<T>() where T : View
        {
            foreach (var allView in GetAllViews())
            {
                if (allView is T t)
                    return t;
            }

            return default(T);
        }

        internal void SetContent(View view)
        {
            _allViews = null;
            Content = view;
        }
    }
}
