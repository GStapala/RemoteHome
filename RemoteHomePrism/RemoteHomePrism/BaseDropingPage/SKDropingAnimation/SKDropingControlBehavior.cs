using System;
using Xamarin.Forms;

namespace RemoteHomePrism.BaseDropingPage.SKDropingAnimation
{
    public class SKDropingControlBehavior : Behavior<SKDropingControl>
    {
        private SKDropingControl bindableObject;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            bindableObject = bindable as SKDropingControl;
            if (bindableObject != null)
                bindableObject.ShowAnimationEvent += ShowAnimation;
        }

        private void ShowAnimation(object sender, EventArgs e)
        {
            var control = sender as SKDropingControl;
            if (control == null) return;

            if (control.IsShowAnimation)
            {
                //There is some problem with layoutTo. The rectangle it transforms is diffrent then the screen width/height. Don't know how it works.
                var a = 4; //for better look of easing
                var positionShow = new Rectangle(0, -200, 400, 600); //Dont know why 400 width is full screen
                bindableObject.LayoutTo(positionShow, 900,
                    new Easing(x => { return (x - 1) * (x - 1) * ((a + 1) * (x - 1) + a) + 1; }));
            }
        }
    }
}