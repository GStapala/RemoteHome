using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHomePrism.Pages.Audio
{
    public interface IAudioService
    {
        Task SwitchPower(bool value);
        Task<BaseResponse<bool>> GetPowerSwichStatus();
        Task<List<SongModel>> GetAllSongs();
        Task<BaseResponse<SongModel>> GetCurrentSong();
        Task Play(SongModel song);
        Task Pause();
        Task Stop();
    }
}