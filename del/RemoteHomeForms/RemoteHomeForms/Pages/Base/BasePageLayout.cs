using RemoteHomeForms.ViewModels;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Base
{
    /// <summary>
    /// This page is used as a parent layoyt page for all other pages
    /// </summary>
    public abstract class BasePageLayout : ContentPage
    {
        public BaseContentViewModel ContentViewModel
        {
            get { return BindingContext as BaseContentViewModel; }
            set { BindingContext = value; }
        }

        protected BasePageLayout(BaseContentViewModel baseContentViewModel)
        {
            BackgroundColor = Color.White;

            var layout = new AbsoluteLayout();

            var topBox = new BoxView()
            {
                BackgroundColor = Color.Green,
            };

            AbsoluteLayout.SetLayoutBounds(topBox, new Rectangle(0, 0, 1, 0.4));
            AbsoluteLayout.SetLayoutFlags(topBox, AbsoluteLayoutFlags.All);

            var topBoxIcon = new Image();

            topBoxIcon.Source.SetBinding(Image.SourceProperty, "ImageSource");
            AbsoluteLayout.SetLayoutBounds(topBoxIcon, new Rectangle(.5, .5, 0.3, 0.3));
            AbsoluteLayout.SetLayoutFlags(topBoxIcon, AbsoluteLayoutFlags.All);

            var topBoxTitle = new Label();

            topBoxTitle.SetBinding(Label.TextProperty, "Title");
            AbsoluteLayout.SetLayoutBounds(topBoxIcon, new Rectangle(.5, .5, 0.3, 0.3));
            AbsoluteLayout.SetLayoutFlags(topBoxIcon, AbsoluteLayoutFlags.All);

            var topBottomDelimiter = new BoxView()
            {
                BackgroundColor = Color.Black,
            };
            AbsoluteLayout.SetLayoutBounds(topBottomDelimiter, new Rectangle(4, 4, 1, 0.03));
            AbsoluteLayout.SetLayoutFlags(topBottomDelimiter, AbsoluteLayoutFlags.All);

            layout.Children.Add(topBox);
            layout.Children.Add(topBoxIcon);
            layout.Children.Add(topBottomDelimiter);

            Content = layout;
        }
    }
}
