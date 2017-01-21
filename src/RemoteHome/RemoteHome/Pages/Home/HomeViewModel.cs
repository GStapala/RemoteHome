using RemoteHomePCL.Models;
using Xamarin.Forms;
using Resources = RemoteHome.Properties.Resources;

namespace RemoteHome.Pages.Home
{
    public class HomeViewModel : BasePageViewModel
    {
        public HomeCellViewModel AudioPage { get; }
        public HomeCellViewModel TemperaturePage { get; }
        public HomeCellViewModel LightingPage { get; }
        public HomeCellViewModel ShadesPage { get; }
        public HomeCellViewModel WashMachinePage { get; }
        public HomeCellViewModel AboutPage { get; }
        public Color BackgroundColor { get; }

        public HomeViewModel()
        {
            Title = Resources.PageHomeTitle;
            BackgroundColor = Color.FromHex("#FFFDE7");

            AudioPage = new HomeCellViewModel
            {
                BackgroundColor = Color.FromHex("#673ab7"),
                Icon = "audio.png",
                PageName = Resources.PageAudioTitle,
            };
            TemperaturePage = new HomeCellViewModel
            {
                BackgroundColor = Color.FromHex("#4CAF50"),
                Icon = "temperature.png",
                PageName = Resources.PageTemperatureTitle
            };
            LightingPage = new HomeCellViewModel
            {
                BackgroundColor = Color.FromHex("#FFEB3B"),
                Icon = "lights.png",
                PageName = Resources.PageLightingTitle
            };
            ShadesPage = new HomeCellViewModel
            {
                BackgroundColor = Color.FromHex("#3F51B5"),
                Icon = "shades.png",
                PageName = Resources.PageShadesTitle
            };
            WashMachinePage = new HomeCellViewModel
            {
                BackgroundColor = Color.FromHex("#2196f3"),
                Icon = "washmachine.png",
                PageName = Resources.PageWashMachineTitle
            };
            AboutPage = new HomeCellViewModel
            {
                BackgroundColor = Color.FromHex("#2196f3"),
                Icon = "aboutus.png",
                PageName = Resources.PageAboutTitle
            };
        }
    }
}