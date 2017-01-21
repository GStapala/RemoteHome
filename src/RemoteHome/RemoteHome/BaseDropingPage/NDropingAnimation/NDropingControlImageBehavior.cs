using System;
using Xamarin.Forms;

namespace RemoteHome.BaseDropingPage.NDropingAnimation
{
    internal class NDropingControlImageBehavior : Behavior<NDropingControlImage>
    {
        private NDropingControlImage _bindableObject;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            _bindableObject = bindable as NDropingControlImage;
            if (_bindableObject != null)
                _bindableObject.ShowAnimationEvent += ShowAnimation;
        }

        private async void ShowAnimation(object sender, EventArgs e)
        {
            var control = sender as NDropingControlImage;
            if (control == null) return;
            var baseDelta = control.Height * 1.1;

            if (control.ShowAnimation)
            {
                var a = 2; //for better look of easing
                //Layout the image above the screen so the image could move from above the screen
                await _bindableObject.LayoutTo(new Rectangle(0, -control.Height, control.Width, control.Height), 1);

                var position = new Rectangle(0, 0, control.Width, control.Height);
                await _bindableObject.LayoutTo(position, 1300, new Easing(x =>
                {
                    ChangeDelta(control, baseDelta, x);
                    return (x - 1) * (x - 1) * ((a + 1) * (x - 1) + a) + 1;
                }));
            }
        }

        private static void ChangeDelta(NDropingControlImage control, double baseDelta, double x)
        {
            control.Delta = baseDelta - ((x - 1) * (x - 1) * ((2 + 1) * (x - 1) + 2) + 1) * baseDelta;
        }
    }
}