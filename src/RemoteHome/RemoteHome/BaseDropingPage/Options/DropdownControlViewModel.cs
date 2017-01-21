using System.Collections.Generic;
using Prism.Commands;
using RemoteHomePCL.Interfaces;

namespace RemoteHome.BaseDropingPage.Options
{
    public class DropdownControlViewModel<T> : OptionBaseViewModel where T : IText
    {
        private IEnumerable<T> _items = new List<T>();

        private T _selected;
        public DelegateCommand SelectedIndexChangedCommand { get; set; }

        public IEnumerable<T> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public T Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }
    }
}