using Xamarin.Forms;

namespace RemoteHomePCL.ControlsForRenderers
{
    public class MyMasterDetailPage : MasterDetailPage
    {
        public static readonly BindableProperty DrawerWidthProperty = BindableProperty.Create("DrawerWidth", typeof(int),
            typeof(MyMasterDetailPage), 500);

        public int DrawerWidth
        {
            get { return (int) GetValue(DrawerWidthProperty); }
            set { SetValue(DrawerWidthProperty, value); }
        }
    }
}