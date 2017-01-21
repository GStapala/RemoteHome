using System.Dynamic;

namespace RemoteHomeForms.ViewModels
{
    public class BaseContentViewModel
    {
        public string ImageSource { get; set; }
        public string TitleBase { get; set; }

        public BaseContentViewModel()
        {
            TitleBase = "title from base viewmodel";
        }
    }
}
