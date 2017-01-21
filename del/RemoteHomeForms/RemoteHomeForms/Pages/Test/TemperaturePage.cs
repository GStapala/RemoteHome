using RemoteHomeForms.Pages.Base;
using RemoteHomeForms.Pages.Menu;
using RemoteHomeForms.ViewModels;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Test
{
    public class TestPage : BasePageLayout
    {
        public TestPage() : base(new BaseContentViewModel() {ImageSource = "icon.png"})
        {
            Title = "Test";
            Icon = "temperature.png";
            BackgroundColor = Color.FromRgb(200, 100, 150);

            ContentViewModel = new BaseContentViewModel()
            {
                TitleBase = "Test t",
                ImageSource = "icon.png"
            };

            BindingContext = ContentViewModel;
            
        }
    }
}