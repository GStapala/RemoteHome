using RemoteHome.BaseDropingPage;
using RemoteHome.BaseDropingPage.Options;
using RemoteHome.Properties;
using RemoteHome.Styles;

namespace RemoteHome.Pages.Shades
{
    public class ShadesViewModel : DropPageViewModel
    {
        private readonly IShadesService _service;

        public SwitchControlViewModel MainSwitch { get; }
        public ShadesCellViewModel Bedroom0 { get; }
        public ShadesCellViewModel Bedroom1 { get; }
        public ShadesCellViewModel Bedroom2 { get; }
        public ShadesCellViewModel Garage { get; }
        public ShadesCellViewModel LivingRoom { get; }
        public ShadesCellViewModel Kitchen { get; }

        public ShadesViewModel(IShadesService service)
        {
            _service = service;
            Title = Resources.PageShadesTitle;
            SetStyle(new ShadesStyle());

            Kitchen = new ShadesCellViewModel
            {
                Icon = RemoteHome.ImageSources.Kitchen,
                ShadesValue = 25,
                RoomName = "Kitchen",
                BackgroundColor = Style.ControlColors[1]
            };
            LivingRoom = new ShadesCellViewModel
            {
                Icon = RemoteHome.ImageSources.LivingRoom,
                ShadesValue = 0,
                RoomName = "Living room",
                BackgroundColor = Style.ControlColors[3]
            };
            Garage = new ShadesCellViewModel
            {
                Icon = RemoteHome.ImageSources.Garage,
                ShadesValue = 0,
                RoomName = "Garage",
                BackgroundColor = Style.ControlColors[3]
            };
            Bedroom1 = new ShadesCellViewModel
            {
                Icon = RemoteHome.ImageSources.Bedroom,
                ShadesValue = 100,
                RoomName = "Bedroom 1",
                BackgroundColor = Style.ControlColors[1]
            };
            Bedroom0 = new ShadesCellViewModel
            {
                Icon = RemoteHome.ImageSources.Bedroom,
                ShadesValue = 55,
                RoomName = "Bedroom 2",
                BackgroundColor = Style.ControlColors[1]
            };
            Bedroom2 = new ShadesCellViewModel
            {
                Icon = RemoteHome.ImageSources.Bedroom,
                ShadesValue = 100,
                RoomName = "Bedroom 3",
                BackgroundColor = Style.ControlColors[3]
            };
            MainSwitch = new SwitchControlViewModel
            {
                Text = "On/Off",
                BackgroundColor = Style.ControlColors[0],
                SmallIcon = RemoteHome.ImageSources.Power
            };
        }
    }
}