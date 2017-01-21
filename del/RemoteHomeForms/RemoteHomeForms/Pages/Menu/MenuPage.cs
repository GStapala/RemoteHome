using System.Collections.Generic;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Menu
{
    public class MenuPage : ContentPage
    {
        public ListView MenuListView { get; set; }

        public MenuPage()
        {
            Icon = "icon.png";
            Title = "Menu Page";
            MenuListView = new MenuListView();

            var menuLayout = new AbsoluteLayout()
            {
                IsVisible = true,
                BackgroundColor = Color.White, //Color.FromRgb(169,185,186),
                Children = {  MenuListView },
            };

            Content = menuLayout;
        }
    }
}
