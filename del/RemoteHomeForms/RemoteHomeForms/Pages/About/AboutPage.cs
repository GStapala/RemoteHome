using Xamarin.Forms;

namespace RemoteHomeForms.Pages.About
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Title = "About";
            Icon = "about.png";
            BackgroundColor = Color.FromRgb(255, 243, 224);
            var layout = new AbsoluteLayout();

            var labelCredits = new Label()
            {
                Text = "Credits:",
                FontSize = 22,
            };
            AbsoluteLayout.SetLayoutBounds(labelCredits, new Rectangle(.1, .1, .8, .05));
            AbsoluteLayout.SetLayoutFlags(labelCredits, AbsoluteLayoutFlags.All);

            var labelIcons = new Label() { Text = "Icons : Designed by Freepik and distributed by Flaticon", FontSize = 14};
            //var rightBox = new BoxView { Color = Color.Olive };
            //AbsoluteLayout.SetLayoutBounds(rightBox, new Rectangle(1, .5, 50, 5));
            //AbsoluteLayout.SetLayoutFlags(rightBox, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelIcons, new Rectangle(.35, .15, .9, .1));
            AbsoluteLayout.SetLayoutFlags(labelIcons, AbsoluteLayoutFlags.All);

            var myLabelCredits = new Label() { Text = "Implementation : Grzegorz Stapala", FontSize = 14};
            AbsoluteLayout.SetLayoutBounds(myLabelCredits, new Rectangle(.35, .185, .9, .1));
            AbsoluteLayout.SetLayoutFlags(myLabelCredits, AbsoluteLayoutFlags.All);

            layout.Children.Add(labelCredits);
            layout.Children.Add(labelIcons);
            layout.Children.Add(myLabelCredits);

            Content = layout;
        }
    }
}
