using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RemoteHomeForms.Pages.Menu
{
    public class MenuFooterCell : ViewCell
    {
        public MenuFooterCell()
        {
            var stackLayout = new StackLayout();

            var label = new Label() {Text = "Additional options"};
            var button = new Button();

            View = stackLayout;
        }
    }
}
