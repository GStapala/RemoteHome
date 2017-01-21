using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Practices.Unity;
using NControl.Droid;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace RemoteHome.Droid
{
    [Activity(Label = "RemoteHome", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.tabs;
            //ToolbarResource = Resource.Layout.toolbar;
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            NControlViewRenderer.Init();
            LoadApplication(new App());

            if ((int) Build.VERSION.SdkInt >= 21)
                ActionBar.SetIcon(null);
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {
            }
        }
    }
}