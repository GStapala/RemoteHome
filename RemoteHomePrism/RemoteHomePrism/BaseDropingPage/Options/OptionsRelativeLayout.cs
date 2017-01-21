using System;
using Xamarin.Forms;

namespace RemoteHomePrism.BaseDropingPage.Options
{
    internal class OptionsRelativeLayout : RelativeLayout
    {
        public event EventHandler<EventArgs> ShowAnimationEvent;
        public static readonly BindableProperty ShowAnimationProperty = BindableProperty.Create("ShowAnimation", typeof(bool), typeof(OptionsRelativeLayout), false, propertyChanged: IsShowAnimationPropertyChanged);

        public bool ShowAnimation
        {
            get { return (bool) GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }

        private static void IsShowAnimationPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = bindable as OptionsRelativeLayout;
            if (control == null) return;
            control.ShowAnimation = (bool) newvalue;
            control.ShowAnimationEvent?.Invoke(control, new EventArgs());
        }
    }
}