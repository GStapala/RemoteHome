using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RemoteHomeForms.Pages.Menu;
using RemoteHomeForms.Views;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            Title = "Master Detail Page";
            var menuPage = new MenuPage();
            MasterBehavior = MasterBehavior.Split;
            menuPage.MenuListView.ItemSelected += (sender, args) => NavigateTo(args.SelectedItem as MenuViewModel);
            Master = menuPage;
            //First page to go
            Detail = new NavigationPage(new Audio());
            Title = "Root page test";
        }

        void NavigateTo(MenuViewModel menuViewModel)
        {
            Page displayPage = (Page) Activator.CreateInstance(menuViewModel.PageType);

            Detail = new NavigationPage(displayPage);

            //Crashes on large screens - the menu is always on the screen
            IsPresented = false;
        }
    }
}
