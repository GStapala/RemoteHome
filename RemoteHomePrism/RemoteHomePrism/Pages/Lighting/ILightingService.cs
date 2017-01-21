using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHomePrism.Pages.Lighting
{
    public interface ILightingService
    {
        Task SwitchPower(bool value);
        Task<BaseResponse<bool>> GetPowerSwichStatus();
    }
}