using System.Windows.Input;
using RemoteHome.BaseDropingPage.Options;

namespace RemoteHome.Pages.Audio
{
    public class ButtonsGridViewModel : OptionBaseViewModel
    {
        private string _pasue = "-";
        private string _start = "-";
        private string _stop = "-";
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand PauseCommand { get; set; }

        public string Stop
        {
            get { return _stop; }
            set { SetProperty(ref _stop, value); }
        }

        public string Pause
        {
            get { return _pasue; }
            set { SetProperty(ref _pasue, value); }
        }

        public string Start
        {
            get { return _start; }
            set { SetProperty(ref _start, value); }
        }
    }
}