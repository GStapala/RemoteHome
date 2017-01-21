using Xamarin.Forms;

namespace RemoteHome.Pages.Temperature
{
    public partial class Temperature : ContentPage
    {
        public Temperature()
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