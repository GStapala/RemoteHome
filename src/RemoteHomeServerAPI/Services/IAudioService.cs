using System.Collections.Generic;
using RemoteHomePCL.Models;

namespace RemoteHomeServerAPI.Services
{
    public interface IAudioService
    {
        void Start(SongModel song);
        void Stop();
        void Pause();
        BaseResponse<bool> SwitchPower(bool value);
        BaseResponse<bool> PowerSwitchStatus();
        BaseResponse<List<SongModel>> GetAllSongs();
        BaseResponse<SongModel> GetCurrentSong();
    }
}