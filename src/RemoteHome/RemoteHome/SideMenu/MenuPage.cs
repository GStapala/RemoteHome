using Xamarin.Forms;

namespace RemoteHome.SideMenu
{
    /// <summary>
    ///     Menu page - top button icon
    /// </summary>
    public class MenuPage : ContentPage
    {
        public ListView MenuListView { get; set; }
        public MenuPage()
        {
            Icon = "hamburger.png";
            Title = "Menu Page";
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(3, GridUnitType.Star)});
            grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(7, GridUnitType.Star)});
            MenuListView = new MenuListView();

            var menuLayout = new AbsoluteLayout
            {
                IsVisible = true,
                BackgroundColor = Color.White,
                Children = {MenuListView},
                Padding = new Thickness(10, 5, 5, 5)
            };
            var label = new Label
            {
                Text = "Remote Home",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontFamily = "AlfaSlabOneRegular",
                TextColor = Color.Black,
                FontSize = 20
            };
            var image = new Image
            {
                Source = "remote_control.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            var topLayout = new Grid
            {
                BackgroundColor = Color.FromHex("#FFA726")
            };
            topLayout.RowDefinitions.Add(new RowDefinition());
            topLayout.RowDefinitions.Add(new RowDefinition());
            topLayout.Children.Add(label, 0, 0);
            topLayout.Children.Add(image, 0, 1);


            grid.Children.Add(topLayout, 0, 0);
            grid.Children.Add(menuLayout, 0, 1);

            Content = grid;
        }
    }
}