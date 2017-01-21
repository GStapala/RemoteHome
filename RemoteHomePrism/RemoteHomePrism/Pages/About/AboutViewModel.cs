using RemoteHomePCL.Models;
using RemoteHomePrism.Properties;
using Xamarin.Forms;

namespace RemoteHomePrism.Pages.About
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