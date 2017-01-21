using System;
using Xamarin.Forms;

namespace RemoteHome.SideMenu
{
    public class MenuViewModel
    {
        public MenuViewModel(string iconSource, string title, Type type, Color actionBarColor)
        {
            IconSource = iconSource;
            Title = title;
            PageType = type;
            ActionBarColor = actionBarColor;
        }

        public string IconSource { get; set; }
        public string Title { get; set; }
        public Type PageType { get; set; }
        public Color ActionBarColor { get; set; }
    }
}