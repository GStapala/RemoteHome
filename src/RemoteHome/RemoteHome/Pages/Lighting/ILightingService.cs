using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHome.Pages.Lighting
{
    public interface ILightingService
    {
        Task SwitchPower(bool value);
        Task<BaseResponse<bool>> GetPowerSwichStatus();
    }
}