using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHomeServerAPI.Services
{
    public class AudioService : IAudioService
    {
        private static readonly List<SongModel> _playList = new List<SongModel>();
        private static readonly CancellationTokenSource _progressCancellationTokenSource = new CancellationTokenSource();
        private static CancellationToken _cancelationToken;
        private static SongModel _currentSong = new SongModel();
        private static bool _power;

        public AudioService()
        {
            _playList.Add(new SongModel {Title = "Electro Swing Collection", Time = TimeSpan.FromMilliseconds(2500)});
            _playList.Add(new SongModel {Title = "Techno Mix", Time = TimeSpan.FromMilliseconds(3500)});
            _playList.Add(new SongModel {Title = "CantinaPop", Time = TimeSpan.FromMilliseconds(6500)});
            _playList.Add(new SongModel {Title = "RockRock", Time = TimeSpan.FromMilliseconds(2700)});

            _cancelationToken = _progressCancellationTokenSource.Token;
        }

        public BaseResponse<bool> SwitchPower(bool value)
        {
            _power = value;
            if (!_power)
            {
                _currentSong.Progress = 0;
                _progressCancellationTokenSource.Cancel(true);
            }

            return new BaseResponse<bool> {ObjectReturn = _power};
        }

        public BaseResponse<bool> PowerSwitchStatus()
        {
            return new BaseResponse<bool> {ObjectReturn = _power};
        }

        public BaseResponse<List<SongModel>> GetAllSongs()
        {
            return new BaseResponse<List<SongModel>> {ObjectReturn = _playList};
        }

        public async void Start(SongModel song)
        {
            //Play song on some audio equipment
            await Task.Run(async () =>
            {
                _currentSong = song;
                while (_power)
                    try
                    {
                        for (var i = 0; i < song.Time.Milliseconds; i++)
                        {
                            if (_progressCancellationTokenSource.IsCancellationRequested)
                                return;
                            await Task.Delay(1000);
                            _currentSong.Progress = i;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
            });
        }

        public void Stop()
        {
            _currentSong = new SongModel();
            _progressCancellationTokenSource.Cancel();
        }

        public void Pause()
        {
            //TODO
            _progressCancellationTokenSource.Cancel();
        }

        public BaseResponse<SongModel> GetCurrentSong()
        {
            return new BaseResponse<SongModel> {ObjectReturn = _currentSong};
        }
    }
}