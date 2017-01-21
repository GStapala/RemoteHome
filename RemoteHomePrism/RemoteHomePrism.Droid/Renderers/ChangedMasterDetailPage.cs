using RemoteHomePCL.ControlsForRenderers;
using RemoteHomePrism.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(MyMasterDetailPage), typeof(ChangedMasterDetailPage))]

namespace RemoteHomePrism.Droid.Renderers
{
    public class ChangedMasterDetailPage : MasterDetailRenderer
    {
        public override void AddView(View child)
        {
            var page = (MyMasterDetailPage) Element;
            var p = (LayoutParams) child.LayoutParameters;
            p.Width = page.DrawerWidth;
            base.AddView(child);
        }
    }
}