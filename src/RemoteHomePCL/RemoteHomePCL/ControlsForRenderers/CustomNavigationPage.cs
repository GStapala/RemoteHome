using Xamarin.Forms;

namespace RemoteHomePCL.ControlsForRenderers
{
    public class CustomNavigationPage : NavigationPage
    {
        public static readonly BindableProperty MainColorProperty =
            BindableProperty.Create<CustomNavigationPage, Color>(w => w.MainColor, Color.Accent);

        public static readonly BindableProperty SecondColorProperty =
            BindableProperty.Create<CustomNavigationPage, Color>(w => w.SecondColor, Color.Accent);

        public CustomNavigationPage(Page root) : base(root)
        {
        }

        public Color MainColor
        {
            get { return (Color) GetValue(MainColorProperty); }
            set { SetValue(MainColorProperty, value); }
        }

        public Color SecondColor
        {
            get { return (Color) GetValue(SecondColorProperty); }
            set { SetValue(SecondColorProperty, value); }
        }
    }
}