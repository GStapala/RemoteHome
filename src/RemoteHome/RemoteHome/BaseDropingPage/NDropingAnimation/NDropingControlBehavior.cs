using System;
using Xamarin.Forms;

namespace RemoteHome.BaseDropingPage.NDropingAnimation
{
    public class NDropingControlBehavior : Behavior<NDropingControl>
    {
        private NDropingControl _bindableObject;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            _bindableObject = bindable as NDropingControl;
            if (_bindableObject != null)
                _bindableObject.ShowAnimationEvent += ShowAnimation;
        }

        private async void ShowAnimation(object sender, EventArgs e)
        {
            var control = sender as NDropingControl;
            if (control == null) return;
            if (control.ShowAnimation)
            {
                //Layout the image above the screen so the image could move from above the screen
                await _bindableObject.TranslateTo(0, -control.Height, 1);
                //var position = new Rectangle(0, control.Height, control.Width, control.Height * 4);
                await _bindableObject.TranslateTo(0, control.Height * 2, 1100, new Easing(x => x));
            }
        }
    }
}