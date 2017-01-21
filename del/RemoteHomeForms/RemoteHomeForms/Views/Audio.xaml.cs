using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteHomeForms.Views
{
    [XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class Audio : ContentPage
    {
        public Audio()
        {
            InitializeComponent();
            Title = "Test from audio view";
        }
    }
}
