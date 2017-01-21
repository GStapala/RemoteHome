using RemoteHome.Properties;
using RemoteHomePCL.Models;
using Xamarin.Forms;

namespace RemoteHome.Pages.About
{
    public class AboutViewModel : BasePageViewModel
    {
        public Color BackgroundColor { get; }

        public AboutViewModel()
        {
            Title = Resources.PageHomeTitle;
            BackgroundColor = Color.FromHex("#FFFDE7");
        }
    }
}