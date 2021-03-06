using System.ComponentModel;
using RemoteHome.Droid.Renderers;
using RemoteHomePCL.ControlsForRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(BindablePicker), typeof(CustomPickerRenderer))]

namespace RemoteHome.Droid.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        public override void AddView(View child)
        {
            var myPicker = (BindablePicker) Element;
            Element.TextColor = Color.Red;
            //LayoutParams p = (LayoutParams)child.LayoutParameters;
            //p.Width = page.DrawerWidth;
            base.AddView(child);
        }
    }
}