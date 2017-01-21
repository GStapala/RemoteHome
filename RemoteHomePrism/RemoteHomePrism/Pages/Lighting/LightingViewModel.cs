using Prism.Commands;
using RemoteHomePrism.BaseDropingPage;
using RemoteHomePrism.BaseDropingPage.Options;
using RemoteHomePrism.Properties;
using RemoteHomePrism.Styles;

namespace RemoteHomePrism.Pages.Lighting
{
    public class LightingViewModel : DropPageViewModel
    {
        public SwitchControlViewModel MainSwitch { get; }
        public Room1GridViewModel Room1 { get; }
        public Room2GridViewModel Room2 { get; }
        public Room3GridViewModel Room3 { get; }
        public string RoomTitle1 { get; } = "Bedroom 1";
        public string RoomTitle2 { get; } = "Kitchen";
        public string RoomTitle3 { get; } = "Livingroom";
        private readonly ILightingService _service;

        public LightingViewModel(ILightingService service)
        {
            _service = service;
            Title = Resources.PageLightingTitle;
            SetStyle(new LightingStyle());

            MainSwitch = new SwitchControlViewModel
            {
                Text = "On/Off",
                BackgroundColor = Style.ControlColors[0],
                SmallIcon = ImageSources.Power
            };
            Room1 = new Room1GridViewModel
            {
                BackgroundColor = Style.ControlColors[1],
                Switch1Command = new DelegateCommand(Switch1Room1)
            };
            Room2 = new Room2GridViewModel
            {
                BackgroundColor = Style.ControlColors[2]
            };
            Room3 = new Room3GridViewModel
            {
                BackgroundColor = Style.ControlColors[3]
            };
        }
      
        private void Switch1Room1()
        {
        }
    }
}