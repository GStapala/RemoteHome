using System;
using Xamarin.Forms;

namespace RemoteHome.BaseDropingPage.Options
{
    internal class OptionsGridBehaviour : Behavior<OptionsGridLayout>
    {
        private OptionsGridLayout _bindableObject;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            _bindableObject = bindable as OptionsGridLayout;
            if (_bindableObject != null)
                _bindableObject.ShowAnimationEvent += ShowAnimation;
        }

        private async void ShowAnimation(object sender, EventArgs e)
        {
            var control = sender as OptionsGridLayout;
            if (control == null) return;

            if (control.ShowAnimation)
            {
                //await bindableObject.LayoutTo(new Rectangle(0, 2 * control.Height, control.Width, control.Height), 1);
                await _bindableObject.TranslateTo(0, 2 * control.Height, 1);
                await _bindableObject.TranslateTo(0, 0, 1350, Easing.SinOut);
            }
        }
    }
}