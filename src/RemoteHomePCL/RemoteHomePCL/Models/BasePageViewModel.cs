using Prism.Mvvm;

namespace RemoteHomePCL.Models
{
    public abstract class BasePageViewModel : BindableBase
    {
        private string title = "No title";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}