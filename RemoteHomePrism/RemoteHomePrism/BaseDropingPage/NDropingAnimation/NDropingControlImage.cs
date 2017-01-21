using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;
using Color = NGraphics.Color;
using Point = NGraphics.Point;

namespace RemoteHomePrism.BaseDropingPage.NDropingAnimation
{
    /// <summary>
    ///     Draws hexagon like image, menu pictogram in the top middle
    ///     Draws under a droping animation that changes through time
    ///     Woks with NDropingControlBehavior
    /// </summary>
    internal class NDropingControlImage : NControlView
    {
        public double Delta { get; set; }
        public event EventHandler<EventArgs> ShowAnimationEvent;
        private readonly Image _imgCell;
        public static readonly BindableProperty BackgroundTopColorProperty =BindableProperty.Create("BackgroundTopColor", typeof(Color), typeof(NDropingControlImage), Colors.Black,propertyChanged: BackgroundTopColorPropertyChanged);
        public static readonly BindableProperty HexColorProperty = BindableProperty.Create("HexColor", typeof(Color),typeof(NDropingControlImage), Colors.Black, propertyChanged: HexColorPropertyChanged);
        public static readonly BindableProperty HexPenColorProperty = BindableProperty.Create("HexPenColor",typeof(Color), typeof(NDropingControlImage), Colors.Black, propertyChanged: HexPenColorColorPropertyChanged);
        public static readonly BindableProperty ShowAnimationProperty = BindableProperty.Create("ShowAnimation",typeof(bool), typeof(NDropingControlImage), false, propertyChanged: IsShowAnimationPropertyChanged);
        public static readonly BindableProperty IconProperty = BindableProperty.Create("Icon", typeof(string),typeof(NDropingControlImage), "bathroom.png", propertyChanged: ImageChanged);

        public NDropingControlImage()
        {
            var layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            _imgCell = new Image
            {
                Source = Icon
            };

            layout.Children.Add(_imgCell);
            Content = layout;
        }

        public bool ShowAnimation
        {
            get { return (bool) GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }

        public string Icon
        {
            get { return (string) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public Color BackgroundTopColor
        {
            get { return (Color) GetValue(BackgroundTopColorProperty); }
            set { SetValue(BackgroundTopColorProperty, value); }
        }

        public Color HexColor
        {
            get { return (Color) GetValue(HexColorProperty); }
            set { SetValue(HexColorProperty, value); }
        }

        public Color HexPenColor
        {
            get { return (Color) GetValue(HexPenColorProperty); }
            set { SetValue(HexPenColorProperty, value); }
        }

        private static void BackgroundTopColorPropertyChanged(BindableObject bindable, object oldvalue, object newValue)
        {
            var control = bindable as NDropingControlImage;
            if (control == null) return;
            control.BackgroundTopColor = (Color) newValue;
        }

        private static void HexColorPropertyChanged(BindableObject bindable, object oldvalue, object newValue)
        {
            var control = bindable as NDropingControlImage;
            if (control == null) return;
            control.HexColor = (Color) newValue;
        }

        private static void HexPenColorColorPropertyChanged(BindableObject bindable, object oldvalue, object newValue)
        {
            var control = bindable as NDropingControlImage;
            if (control == null) return;
            control.HexPenColor = (Color) newValue;
        }

        private static void IsShowAnimationPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = bindable as NDropingControlImage;
            if (control == null) return;
            control.ShowAnimation = (bool) newvalue;
            control.ShowAnimationEvent?.Invoke(control, new EventArgs());
        }

        private static void ImageChanged(BindableObject bindable, object oldvalue, object newValue)
        {
            var control = bindable as NDropingControlImage;
            if (control == null) return;
            control.Icon = (string) newValue;
            control._imgCell.Source = (string) newValue;
        }

        //rect = current controll bounds (inside grid)
        public override void Draw(ICanvas canvas, Rect rect)
        {
            //Draws droping animation - with bottom side curved - changed by behaviour
            DrawDroping(canvas, rect);
            //Draws image hexagon under the icon
            DrawHex(canvas, rect);
        }

        private void DrawDroping(ICanvas canvas, Rect rect)
        {
            var width = rect.Width;
            var height = rect.Height; //its already half of the screen becouse of the grid
            var startingY = -height * 4;
            canvas.DrawPath(new PathOp[]
            {
                new MoveTo(0, startingY),
                new LineTo(0, height),
                new CurveTo(
                    new Point(0, height),
                    new Point(width / 2, height + Delta),
                    new Point(width, height)
                ),
                new LineTo(width, height),
                new LineTo(width, startingY)
            }, null, new SolidBrush(BackgroundTopColor));
        }

        private void DrawHex(ICanvas canvas, Rect rect)
        {
            var zeroPointX = rect.Width / 2f;
            var zeroPointY = rect.Height / 2f;
            var alhpa = 140;
            var beta = 165;

            canvas.DrawPath(new PathOp[]
            {
                new MoveTo(zeroPointX - alhpa, zeroPointY - alhpa), //left upper
                new LineTo(zeroPointX, zeroPointY - beta),
                new LineTo(zeroPointX + alhpa, zeroPointY - alhpa),
                new LineTo(zeroPointX + alhpa, zeroPointY + alhpa),
                new LineTo(zeroPointX, zeroPointY + beta),
                new LineTo(zeroPointX - alhpa, zeroPointY + alhpa),
                new ClosePath()
            }, new Pen(HexPenColor, 45), new SolidBrush(HexColor));
        }
    }
}