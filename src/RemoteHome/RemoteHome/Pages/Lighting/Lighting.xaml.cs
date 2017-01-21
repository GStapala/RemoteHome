using Xamarin.Forms;

namespace RemoteHome.Pages.Lighting
{
    public partial class Lighting : ContentPage
    {
        public Lighting()
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