using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;
using Color = NGraphics.Color;
using Point = NGraphics.Point;

namespace RemoteHomePrism.BaseDropingPage.NDropingAnimation
{
    /// <summary>
    ///     Draws droping animation beind a page. From top to bottom.
    /// </summary>
    public class NDropingControl : NControlView
    {
        public double Delta { get; set; }
        public event EventHandler<EventArgs> ShowAnimationEvent;
        public static readonly BindableProperty DropColorProperty = BindableProperty.Create("DropColor", typeof(Color), typeof(NDropingControl), new Color(1, .3, .3, 1));
        public static readonly BindableProperty DropColorPenProperty = BindableProperty.Create("DropColorPen", typeof(Color), typeof(NDropingControl), new Color(1, .3, .3, 1));
        public static readonly BindableProperty ShowAnimationProperty = BindableProperty.Create("ShowAnimation", typeof(bool), typeof(NDropingControl), false, propertyChanged: ShowAnimationPropertyChanged);

        public bool ShowAnimation
        {
            get { return (bool)GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }

        public Color DropColor
        {
            get { return (Color)GetValue(DropColorProperty); }
            set { SetValue(DropColorProperty, value); }
        }

        public Color DropColorPen
        {
            get { return (Color)GetValue(DropColorPenProperty); }
            set { SetValue(DropColorPenProperty, value); }
        }

        private static void ShowAnimationPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = bindable as NDropingControl;
            if (control == null) return;
            control.ShowAnimation = (bool)newvalue;
            control.ShowAnimationEvent?.Invoke(control, new EventArgs());
        }

        public override void Draw(ICanvas canvas, Rect rect)
        {
            var width = rect.Width;
            var height = rect.Height; //its already half of the screen becouse of the grid
            var brush = new SolidBrush(DropColor);
            var startingY = -3 * height;
            canvas.DrawPath(new PathOp[]
            {
                new MoveTo(0, startingY),
                new LineTo(0, height),
                new CurveTo(
                    new Point(0, height),
                    new Point(width / 2, height + height / 4),
                    new Point(width, height)
                ),
                new LineTo(width, height),
                new LineTo(width, startingY),
                new ClosePath()
            }, new Pen(DropColorPen, 8), brush);
        }
    }
}