using System.Collections.Generic;
using RemoteHomeForms.Pages.About;
using RemoteHomeForms.Pages.Camera;
using RemoteHomeForms.Pages.Lights;
using RemoteHomeForms.Pages.Security;
using RemoteHomeForms.Pages.Shades;
using RemoteHomeForms.Pages.Temperature;
using RemoteHomeForms.Pages.Test;
using RemoteHomeForms.Views;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Menu
{
    /// <summary>
    /// Items on side menu list (drawer)
    /// </summary>
    public class MenuListData : List<MenuViewModel>
    {
        public MenuListData()
        {
            Add(new MenuViewModel() { IconSource = "home.png", Text = "Home", PageType = typeof(HomePage)});
            Add(new MenuViewModel() { IconSource = "about.png", Text = "TestPage", PageType = typeof(TestPage) });
            Add(new MenuViewModel() { IconSource = "home.png", Text = "Audio", PageType = typeof(Audio) });
            Add(new MenuViewModel() { IconSource = "temperature.png", Text = "Temperature", PageType = typeof(TemperaturePage) });
            Add(new MenuViewModel() { IconSource = "camera.png", Text = "Security", PageType = typeof(SecurityPage) });
            Add(new MenuViewModel() { IconSource = "audio.png", Text = "Audio", PageType = typeof(Audio) });
            Add(new MenuViewModel() { IconSource = "lights.png", Text = "Lights", PageType = typeof(LightsPage) });
            Add(new MenuViewModel() { IconSource = "camera.png", Text = "Cameras", PageType = typeof(CameraPage) });
            Add(new MenuViewModel() { IconSource = "shades.png", Text = "Shades", PageType = typeof(ShadesPage) });
            Add(new MenuViewModel() { IconSource = "about.png", Text = "About", PageType = typeof(AboutPage) });
        }
    }
}
