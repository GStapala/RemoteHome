using System;
using Xamarin.Forms;

namespace RemoteHomePrism.BaseDropingPage.Options
{
    internal class OptionsRelativeBehaviour : Behavior<OptionsRelativeLayout>
    {
        private OptionsRelativeLayout _bindableObject;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            _bindableObject = bindable as OptionsRelativeLayout;
            if (_bindableObject != null)
                _bindableObject.ShowAnimationEvent += ShowAnimation;
        }

        private async void ShowAnimation(object sender, EventArgs e)
        {
            var control = sender as OptionsRelativeLayout;
            if (control == null) return;

            if (control.ShowAnimation)
            {
                await _bindableObject.TranslateTo(0, 2 * control.Height, 1);
                await _bindableObject.TranslateTo(0, 0, 1350, Easing.SinOut);
            }
        }
    }
}