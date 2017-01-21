using RemoteHome.Styles;
using RemoteHomePCL.Models;

namespace RemoteHome.BaseDropingPage
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