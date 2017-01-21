using System;
using Android.Graphics;
using RemoteHome.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CustomFontLabelRenderer))]

namespace RemoteHome.Droid.Renderers
{
    public class CustomFontLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (!string.IsNullOrEmpty(e.NewElement?.FontFamily))
                try
                {
                    var typeface = Typeface.CreateFromAsset(Forms.Context.Assets, e.NewElement.FontFamily + ".ttf");
                    Control.SetTypeface(typeface, TypefaceStyle.Normal);
                }
                catch (Exception ex)
                {
                    // An exception means that the custom font wasn't found.
                    // Typeface.CreateFromAsset throws an exception when it didn't find a matching font.
                    // When it isn't found we simply do nothing, meaning it reverts back to default.
                }
        }
    }
}