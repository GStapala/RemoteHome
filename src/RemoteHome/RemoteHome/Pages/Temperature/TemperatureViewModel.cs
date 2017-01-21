using RemoteHome.BaseDropingPage;
using RemoteHome.BaseDropingPage.Options;
using RemoteHome.Properties;
using RemoteHome.Styles;

namespace RemoteHome.Pages.Temperature
{
    public class TemperatureViewModel : DropPageViewModel
    {
        private readonly ITemperatureService _service;

        public SwitchControlViewModel MainSwitch { get; }
        public TemperatureCellViewModel Bedroom0 { get; }
        public TemperatureCellViewModel Bedroom1 { get; }
        public TemperatureCellViewModel Bedroom2 { get; }
        public TemperatureCellViewModel Garage { get; }
        public TemperatureCellViewModel LivingRoom { get; }
        public TemperatureCellViewModel Kitchen { get; }

        public TemperatureViewModel(ITemperatureService service)
        {
            _service = service;
            Title = Resources.PageTemperatureTitle;
            SetStyle(new TemperatureStyle());

            Kitchen = new TemperatureCellViewModel
            {
                Icon = RemoteHome.ImageSources.Kitchen,
                Temperature = "26",
                RoomName = "Kitchen",
                BackgroundColor = Style.ControlColors[1]
            };
            LivingRoom = new TemperatureCellViewModel
            {
                Icon = RemoteHome.ImageSources.LivingRoom,
                Temperature = "24",
                RoomName = "Living room",
                BackgroundColor = Style.ControlColors[3]
            };
            Garage = new TemperatureCellViewModel
            {
                Icon = RemoteHome.ImageSources.Garage,
                Temperature = "12",
                RoomName = "Garage",
                BackgroundColor = Style.ControlColors[3]
            };
            Bedroom1 = new TemperatureCellViewModel
            {
                Icon = RemoteHome.ImageSources.Bedroom,
                Temperature = "22",
                RoomName = "Bedroom 1",
                BackgroundColor = Style.ControlColors[1]
            };
            Bedroom0 = new TemperatureCellViewModel
            {
                Icon = RemoteHome.ImageSources.Bedroom,
                Temperature = "21",
                RoomName = "Bedroom 2",
                BackgroundColor = Style.ControlColors[1]
            };
            Bedroom2 = new TemperatureCellViewModel
            {
                Icon = RemoteHome.ImageSources.Bedroom,
                Temperature = "24",
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