using RemoteHomePCL.Models;
using RemoteHomePrism.Styles;

namespace RemoteHomePrism.BaseDropingPage
{
    public class DropPageViewModel : BasePageViewModel
    {
        public DropingPageStyle Style { get; set; }

        protected void SetStyle(DropingPageStyle style)
        {
            Style = style;
        }
    }
}