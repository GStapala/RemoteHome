using System.Threading.Tasks;
using RemoteHome.Droid.Renderers;
using RemoteHomePCL.ControlsForRenderers;
using RemoteHomePCL.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(NavigationPageHeaderRenderer))]

namespace RemoteHome.Droid.Renderers
{
    /// <summary>
    ///     Changes top bar color
    /// </summary>
    public class NavigationPageHeaderRenderer : NavigationRenderer
    {
        private static Color prevBarColor = Color.Black;

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            var navPageHeader = (CustomNavigationPage) Element;
            ChangeCurrentToNewColor(navPageHeader, navPageHeader.MainColor, 1);
        }

        /// <summary>
        ///     Interpolates one color into another throuh unit of time
        /// </summary>
        private async void ChangeCurrentToNewColor(CustomNavigationPage contextActionBar, Color colorToChange, int delay)
        {
            for (var i = 0; i < 50; i++)
            {
                var color = ColorInterpolator.InterpolateColor(new[] {prevBarColor, colorToChange}, i / 50d);
                contextActionBar.BarBackgroundColor = color;
                await Task.Delay(delay);
            }
            prevBarColor = colorToChange;
        }
    }
}