using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using RemoteHomePCL.Extension;
using RemoteHomePCL.Models.Enums;
using RemoteHomePrism.BaseDropingPage;
using RemoteHomePrism.BaseDropingPage.Options;
using RemoteHomePrism.Properties;
using RemoteHomePrism.Styles;

namespace RemoteHomePrism.Pages.WashMachine
{
    public class WashMachineViewModel : DropPageViewModel
    {
        private readonly IWashMachineService _service;

        public SwitchControlViewModel PowerSwitch { get; }
        public DropdownControlViewModel<StringModel> ProgramsDropdown { get; }
        public ProgressControlViewModel ProgressWashMachine { get; }
        public ButtonTextControlViewModel StartButton { get; }

        public WashMachineViewModel(IWashMachineService service)
        {
            _service = service;
            Title = Resources.PageWashMachineTitle;
            SetStyle(new WashMachineStyle());

            PowerSwitch = new SwitchControlViewModel
            {
                Text = Resources.PageWashMachinePower,
                BackgroundColor = Style.ControlColors[0],
                SwitchCommand = new DelegateCommand(ChangePower),
                SmallIcon = ImageSources.Power
            };
            ProgramsDropdown = new DropdownControlViewModel<StringModel>
            {
                Text = Resources.PageWashMachineCurrentProgram,
                BackgroundColor = Style.ControlColors[1],
            };
            StartButton = new ButtonTextControlViewModel
            {
                Text = Resources.PageWashMachineStart,
                BackgroundColor = Style.ControlColors[2],
                ClickCommand = new DelegateCommand(StartWash),
                ButtonText = Resources.PageWashMachineStart
            };
            ProgressWashMachine = new ProgressControlViewModel
            {
                Text = Resources.PageWashMachineProgress,
                BackgroundColor = Style.ControlColors[3]
            };

            PowerSwichServerStatusAutoUpdate();
            Task.Run(async () => await GetAllPrograms());

            PowerSwitch.PropertyChanged += (sender, args) =>
            {
                if ((args.PropertyName == "IsToggled") & (ProgramsDropdown.Selected.Text.ToEnum<WashMachineProgramsEnum>() != WashMachineProgramsEnum.Program))
                    StartButton.ButtonEnabled = PowerSwitch.IsToggled;
            };
        }

        private async void PowerSwichServerStatusAutoUpdate()
        {
            //hax - Something is wrong with framework?. If PowerSwitch.IsToggled changes it fires the Toggle Event. If it is changed in constructor it cannot find the EventCommand like it didnt hook it but if there is any Task.Delay it works.
            while (true)
            {
                //TODO change to Pub/Sub - wcf?
                await Task.Delay(500);
                var serverStatus = (await _service.GetPowerSwichStatus()).ObjectReturn;
                PowerSwitch.IsToggled = serverStatus;
                var progress = await _service.GetCurrentProgress();
                ProgressWashMachine.Progress = progress / 100d;
                ProgressWashMachine.Percentage = string.Concat(progress, "%");
            }
        }

        private async Task GetAllPrograms()
        {
            var items = await _service.GetAllPrograms();
            if (items != null)
            {
                ProgramsDropdown.Items = items.Select(s => new StringModel {ProgramEnum = s}).ToList();
                ProgramsDropdown.Selected = ProgramsDropdown.Items.ToList()[1];//FirstOrDefault();
             }
        }

        public async void ChangePower()
        {
            await _service.SwitchPower(PowerSwitch.IsToggled);
        }

        public async void StartWash()
        {
            var pickedProgram = ProgramsDropdown.Selected.ProgramEnum;
            if (PowerSwitch.IsToggled && (pickedProgram != WashMachineProgramsEnum.Program))
                await _service.StartWashing(pickedProgram);
        }
    }
}