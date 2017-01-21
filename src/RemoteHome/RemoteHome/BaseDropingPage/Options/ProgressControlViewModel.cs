namespace RemoteHome.BaseDropingPage.Options
{
    public class ProgressControlViewModel : OptionBaseViewModel
    {
        private string _percentage = "0%";
        private double _progress;

        public double Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        public string Percentage
        {
            get { return _percentage; }
            set { SetProperty(ref _percentage, value); }
        }
    }
}