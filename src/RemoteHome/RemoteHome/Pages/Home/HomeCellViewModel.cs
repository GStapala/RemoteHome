using System.Windows.Input;
using Xamarin.Forms;

namespace RemoteHome.Pages.Home
{
    public class HomeCellViewModel
    {
        public string Icon { get; set; }
        public string PageName { get; set; }
        public Color BackgroundColor { get; set; }
        public ICommand StackLayoutCommand { get; set; }
    }
}