using System.Windows.Input;
using RemoteHomePrism.BaseDropingPage.Options;

namespace RemoteHomePrism.Pages.Lighting
{
    public class Room1GridViewModel : OptionBaseViewModel
    {
        public ICommand Switch1Command { get; set; }
        public ICommand Switch2Command { get; set; }
        public ICommand Switch3Command { get; set; }

        public SwitchControlViewModel Switch1 { get; set; }
        public SwitchControlViewModel Switch2 { get; set; }
        public SwitchControlViewModel Switch3 { get; set; }

        public Room1GridViewModel()
        {
            Padding = 0;
            Switch1 = new SwitchControlViewModel
            {
                Text = "Desk",
                SwitchCommand = Switch1Command,
                SmallIcon = ImageSources.DeskLamp,
                Padding = 0
            };
            Switch2 = new SwitchControlViewModel
            {
                Text = "Ceiling",
                SwitchCommand = Switch2Command,
                SmallIcon = ImageSources.Light0,
                Padding = 0
            };
            Switch3 = new SwitchControlViewModel
            {
                Text = "Room Entrence",
                SwitchCommand = Switch3Command,
                SmallIcon = ImageSources.Lamp,
                Padding = 0
            };
        }
    }
}