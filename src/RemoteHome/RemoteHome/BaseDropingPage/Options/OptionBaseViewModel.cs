using Prism.Mvvm;
using Xamarin.Forms;

namespace RemoteHome.BaseDropingPage.Options
{
    public class OptionBaseViewModel : BindableBase
    {
        private Color _backgroundColor = Color.Transparent;
        private int _padding;
        private Color _textColor = Color.Black;
        private string _text = "No title";

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { SetProperty(ref _backgroundColor, value); }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set { SetProperty(ref _textColor, value); }
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public int Padding
        {
            get { return _padding; }
            set { SetProperty(ref _padding, value); }
        }
    }
}