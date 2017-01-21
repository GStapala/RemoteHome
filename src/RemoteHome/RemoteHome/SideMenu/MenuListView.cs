using System.Collections.Generic;
using Xamarin.Forms;

namespace RemoteHome.SideMenu
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuViewModel> data = new MenuListData();
            VerticalOptions = LayoutOptions.FillAndExpand;

            ItemTemplate = new DataTemplate(() => new MenuCell());
            ItemsSource = data;
            SelectedItem = data[0];
        }
    }
}