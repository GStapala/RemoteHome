using Prism.Commands;

namespace RemoteHomePrism.BaseDropingPage.Options
{
    public class ButtonTextControlViewModel : OptionBaseViewModel
    {
        private bool _buttonEnabled;

        private string _buttonText;

        public DelegateCommand ClickCommand { get; set; }

        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set { SetProperty(ref _buttonEnabled, value); }
        }

        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }
    }
}