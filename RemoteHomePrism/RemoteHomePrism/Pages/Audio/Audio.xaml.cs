using Xamarin.Forms;

namespace RemoteHomePrism.Pages.Audio
{
    public partial class Audio : ContentPage
    {
        public Audio()
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