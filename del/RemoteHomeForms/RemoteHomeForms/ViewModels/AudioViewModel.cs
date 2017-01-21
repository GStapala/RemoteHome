using Prism.Mvvm;

namespace RemoteHomeForms.ViewModels
{
    public class AudioViewModel : BindableBase
    {
        private string _title = "Audio from audioviewmodel";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public AudioViewModel()
        {
        }
    }
}
