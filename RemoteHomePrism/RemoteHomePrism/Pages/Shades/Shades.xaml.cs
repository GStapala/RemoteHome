using Xamarin.Forms;

namespace RemoteHomePrism.Pages.Shades
{
    public partial class Shades : ContentPage
    {
        public Shades()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            nControl.ShowAnimation = true;
            nControlImage.ShowAnimation = true;
            optionsGrid.ShowAnimation = true;
        }
    }
}