using Android.Graphics;
using RemoteHome.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(ProgressRenderer))]

namespace RemoteHome.Droid.Renderers
{
    /// <summary>
    ///     Changes design of progress control
    /// </summary>
    public class ProgressRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            Control.ProgressDrawable.SetColorFilter(Color.Green, PorterDuff.Mode.SrcIn);
        }
    }
}