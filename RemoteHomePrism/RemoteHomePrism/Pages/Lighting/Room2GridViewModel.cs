using System.Windows.Input;
using RemoteHomePrism.BaseDropingPage.Options;

namespace RemoteHomePrism.Pages.Lighting
{
    public class Room2GridViewModel : OptionBaseViewModel
    {
        public ICommand Switch1Command { get; set; }
        public ICommand Switch2Command { get; set; }

        public SwitchControlViewModel Switch1 { get; set; }
        public SwitchControlViewModel Switch2 { get; set; }

        public Room2GridViewModel()
        {
            Switch1 = new SwitchControlViewModel
            {
                Text = "Lamp",
                SwitchCommand = Switch1Command,
                SmallIcon = ImageSources.Lamp
            };
            Switch2 = new SwitchControlViewModel
            {
                Text = "Lantern",
                SwitchCommand = Switch2Command,
                SmallIcon = ImageSources.Lantern
            };
        }
    }
}