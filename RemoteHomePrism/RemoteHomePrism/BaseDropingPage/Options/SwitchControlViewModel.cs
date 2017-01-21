using System.Windows.Input;

namespace RemoteHomePrism.BaseDropingPage.Options
{
    public class SwitchControlViewModel : OptionBaseViewModel
    {
        private string _smallIcon;
        private bool _isToggled;
        public ICommand SwitchCommand { get; set; }

        public bool IsToggled
        {
            get { return _isToggled; }
            set { SetProperty(ref _isToggled, value); }
        }

        public string SmallIcon
        {
            get { return _smallIcon; }
            set { SetProperty(ref _smallIcon, value); }
        }
    }
}