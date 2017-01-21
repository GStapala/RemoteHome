using Xamarin.Forms;

namespace RemoteHomeForms.Pages
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            Title = "RemoteHome";
            Icon = "home.png";
            BackgroundColor = Color.FromRgb(250, 150, 150);
            var label = new Label() { Text = "Welcome to app" };

            var menuLayout = new AbsoluteLayout()
            {
                IsVisible = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.Green,
            };

            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(.5, .5, 300, 30));

            var rightBox = new BoxView { Color = Color.Olive };
            AbsoluteLayout.SetLayoutBounds(rightBox, new Rectangle(1, .5, 50, 5));
            AbsoluteLayout.SetLayoutFlags(rightBox, AbsoluteLayoutFlags.PositionProportional);

            menuLayout.Children.Add(label);
            menuLayout.Children.Add(rightBox);

            Content = menuLayout;
        }
    }
}
