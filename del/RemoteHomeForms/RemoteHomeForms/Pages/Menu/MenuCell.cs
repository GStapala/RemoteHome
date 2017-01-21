using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Menu
{
    /// <summary>
    /// Template for side menu item in list view
    /// </summary>
    public class MenuCell : ViewCell
    {
        public MenuCell()
        {
            var icon = new Image
            {
                IsVisible = true,
                Opacity = 0.7,
                HeightRequest = 20,
                WidthRequest = 20
            };
            icon.SetBinding(Image.SourceProperty, "IconSource");

            var label = new Label
            {
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            label.SetBinding(Label.TextProperty, "Text");

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                Spacing = 20,
            };

            layout.Children.Add(icon);
            layout.Children.Add(label);

            View = layout;
        }
    }
}
