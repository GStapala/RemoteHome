using System.Windows.Input;
using RemoteHome.BaseDropingPage.Options;

namespace RemoteHome.Pages.Lighting
{
    public class Room3GridViewModel : OptionBaseViewModel
    {
        public ICommand Switch1Command { get; set; }
        public ICommand Switch2Command { get; set; }
        public ICommand Switch3Command { get; set; }
        public ICommand Switch4Command { get; set; }

        public SwitchControlViewModel Switch1 { get; set; }
        public SwitchControlViewModel Switch2 { get; set; }
        public SwitchControlViewModel Switch3 { get; set; }
        public SwitchControlViewModel Switch4 { get; set; }

        public Room3GridViewModel()
        {
            Switch1 = new SwitchControlViewModel
            {
                Text = "Ceiling",
                SwitchCommand = Switch1Command,
                SmallIcon = RemoteHome.ImageSources.Lamp
            };
            Switch2 = new SwitchControlViewModel
            {
                Text = "Desk",
                SwitchCommand = Switch2Command,
                SmallIcon = RemoteHome.ImageSources.DeskLamp
            };
            Switch3 = new SwitchControlViewModel
            {
                Text = "Ceiling corner",
                SwitchCommand = Switch3Command,
                SmallIcon = RemoteHome.ImageSources.Light0
            };
            Switch4 = new SwitchControlViewModel
            {
                Text = "Table",
                SwitchCommand = Switch4Command,
                SmallIcon = RemoteHome.ImageSources.TableLamp
            };
        }
    }
}