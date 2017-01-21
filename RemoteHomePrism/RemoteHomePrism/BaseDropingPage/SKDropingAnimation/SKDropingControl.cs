using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace RemoteHomePrism.BaseDropingPage.SKDropingAnimation
{
    public class SKDropingControl : SKCanvasView
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.Create("Color", typeof(SKColor),
            typeof(SKDropingControl), SKColors.Red);

        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string),
            typeof(SKDropingControl), "Set up the title", propertyChanged: TitlePropertyChanged);

        public static readonly BindableProperty ShowAnimationProperty = BindableProperty.Create("ShowAnimation",
            typeof(bool), typeof(SKDropingControl), false, propertyChanged: IsShowAnimationPropertyChanged);

        public bool IsShowAnimation
        {
            get { return (bool) GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }

        public SKColor Color
        {
            get { return (SKColor) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public event EventHandler<EventArgs> ShowAnimationEvent;

        private static void IsShowAnimationPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = bindable as SKDropingControl;
            if (control == null) return;
            control.IsShowAnimation = (bool) newvalue;
            control.ShowAnimationEvent?.Invoke(control, new EventArgs());
        }

        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as SKDropingControl;
            if (control == null) return;
            control.Title = (string) newValue;
        }

        public void Draw(SKCanvas canvas, int width, int height)
        {
            //canvas.DrawColor(SKColors.White);


            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                //paint.Color = SKColors.White;
                paint.StrokeCap = SKStrokeCap.Round;
                //canvas.DrawPaint(paint);


                using (var path = new SKPath())
                {
                    float x = width;
                    var y = height * 4 / 5f;

                    path.MoveTo(0, -height);
                    path.LineTo(0, y);
                    path.CubicTo(0, y, x / 2, y + 150, x, y); //point on the right bottom
                    path.LineTo(width, y);
                    path.LineTo(width, -height);

                    //path.Close();

                    paint.Color = Color;
                    canvas.DrawPath(path, paint);
                }
            }

            using (var paint = new SKPaint())
            {
                paint.TextSize = 64.0f;
                paint.IsAntialias = true;
                paint.Color = SKColors.Red;
                paint.IsStroke = false;
                paint.Typeface = SKTypeface.FromFamilyName("BungeeHairline-Regular.ttf");

                var textMeasure = paint.MeasureText(Title);
                canvas.DrawText(Title, width / 2f - textMeasure / 2f, height / 2f, paint);
            }
        }
    }
}