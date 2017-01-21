using System;
using RemoteHomePCL.ControlsForRenderers;
using RemoteHomePrism.SideMenu;
using Xamarin.Forms;

namespace RemoteHomePrism
{
    public class RootPage : MyMasterDetailPage
    {
        public RootPage()
        {
            Title = "Master Detail Page";
            var menuPage = new MenuPage();
            menuPage.MenuListView.ItemSelected += (sender, args) => NavigateTo(args.SelectedItem as MenuViewModel);
            Master = menuPage;

            var homeMenuViewModel = (MenuViewModel) menuPage.MenuListView.SelectedItem;
            var displayPage = (Page) Activator.CreateInstance(homeMenuViewModel.PageType);
            Detail = new CustomNavigationPage(displayPage) {MainColor = homeMenuViewModel.ActionBarColor};
        }

        private void NavigateTo(MenuViewModel menuViewModel)
        {
            var displayPage = (Page) Activator.CreateInstance(menuViewModel.PageType);

            Detail  = new CustomNavigationPage(displayPage) {MainColor = menuViewModel.ActionBarColor};

            //Crashes on large screens - the menu is always on the screen.
            IsPresented = false;
        }
    }
}