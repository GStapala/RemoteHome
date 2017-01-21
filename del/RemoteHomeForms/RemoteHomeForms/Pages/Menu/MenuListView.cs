using System.Collections.Generic;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Menu
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuViewModel> data = new MenuListData();

            VerticalOptions = LayoutOptions.FillAndExpand;
            
            var menuLabel = new Label()
            {
                Text = "Menu",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                BackgroundColor = Color.White// Color.FromRgb(37,53,54),

            };
            
            Header = menuLabel;
            //FooterTemplate 

            ItemTemplate = new DataTemplate(() => new MenuCell());
            ItemsSource = data;
            SelectedItem = data[0];
        }
    }
}