using System;
using Xamarin.Forms;

namespace RemoteHome.BaseDropingPage.Options
{
    internal class OptionsGridLayout : Grid
    {
        public event EventHandler<EventArgs> ShowAnimationEvent;
        public static readonly BindableProperty ShowAnimationProperty = BindableProperty.Create("ShowAnimation",typeof(bool), typeof(OptionsGridLayout), false, propertyChanged: IsShowAnimationPropertyChanged);

        public bool ShowAnimation
        {
            get { return (bool) GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }

        private static void IsShowAnimationPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = bindable as OptionsGridLayout;
            if (control == null) return;
            control.ShowAnimation = (bool) newvalue;
            control.ShowAnimationEvent?.Invoke(control, new EventArgs());
        }
    }
}