namespace RemoteHomePrism.BaseDropingPage.Options
{
    public class StatusControlViewModel : OptionBaseViewModel
    {
        private string _infoText = "-";

        public string InfoText
        {
            get { return _infoText; }
            set { SetProperty(ref _infoText, value); }
        }
    }
}