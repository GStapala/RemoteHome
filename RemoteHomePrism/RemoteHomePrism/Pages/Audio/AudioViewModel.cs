using System.Threading.Tasks;
using Prism.Commands;
using RemoteHomePCL.Models;
using RemoteHomePrism.BaseDropingPage;
using RemoteHomePrism.BaseDropingPage.Options;
using RemoteHomePrism.Properties;
using RemoteHomePrism.Styles;

namespace RemoteHomePrism.Pages.Audio
{
    public class AudioViewModel : DropPageViewModel
    {
        private readonly IAudioService _service;
        public SwitchControlViewModel PowerSwitch { get; }
        public StatusControlViewModel CurrentSong { get; }
        //Play, stop, pause
        public OptionBaseViewModel ButtonsGrid { get; }
        public DropdownControlViewModel<SongModel> AudioDropdown { get; }

        public AudioViewModel(IAudioService service)
        {
            _service = service;
            Title = Resources.PageAudioTitle;
            SetStyle(new AudioStyle());
            PowerSwitch = new SwitchControlViewModel
            {
                Text = Resources.PageAudioPower,
                BackgroundColor = Style.ControlColors[0],
                SwitchCommand = new DelegateCommand(ChangePower),
                SmallIcon = ImageSources.Power
            };
            CurrentSong = new StatusControlViewModel
            {
                Text = "Playing song :",
                BackgroundColor = Style.ControlColors[1]
            };
            ButtonsGrid = new ButtonsGridViewModel
            {
                Text = Resources.PageAudioPower,
                BackgroundColor = Style.ControlColors[2],
                Start = Resources.PageWashMachineStart,
                Pause = Resources.PageAudioPause,
                Stop = Resources.PageAudioStop,
                StartCommand = new DelegateCommand(StartSong),
                StopCommand = new DelegateCommand(StopSong),
                PauseCommand = new DelegateCommand(PauseSong)
            };

            AudioDropdown = new DropdownControlViewModel<SongModel>
            {
                BackgroundColor = Style.ControlColors[3],
                Text = Resources.PageAudioChoseAudio
            };

            Task.Run(async () => await GetAllTitles());
            Task.Run(async () => await AutoUpdate());
        }

        private async void StartSong()
        {
            var pickedSong = AudioDropdown.Selected;
            if (PowerSwitch.IsToggled)
                await _service.Play(pickedSong);
        }

        private async void StopSong()
        {
            await _service.Stop();
        }

        private async void PauseSong()
        {
            await _service.Pause();
        }

        private async Task GetAllTitles()
        {
            var items = await _service.GetAllSongs();
            if (items != null)
            {
                AudioDropdown.Items = items;
                if (items.Count > 0)
                    AudioDropdown.Selected = items[0];
            }
        }

        private async void ChangePower()
        {
            await _service.SwitchPower(PowerSwitch.IsToggled);
        }

        private async Task AutoUpdate()
        {
            //hax - Something is wrong with framework?. If PowerSwitch.IsToggled changes it fires the Toggle Event. If it is changed in constructor it cannot find the EventCommand like it didnt hook it but if there is any Task.Delay it works.
            while (true)
            {
                //TODO change to Pub/Sub - wcf?
                await Task.Delay(500);
                var powerSwitch = (await _service.GetPowerSwichStatus()).ObjectReturn;
                PowerSwitch.IsToggled = powerSwitch;
                var currentSong = await _service.GetCurrentSong();
                if (currentSong.ObjectReturn != null)
                    CurrentSong.InfoText = string.Concat(currentSong.ObjectReturn.Progress, "s - ",
                        currentSong.ObjectReturn.Title);
            }
        }
    }
}