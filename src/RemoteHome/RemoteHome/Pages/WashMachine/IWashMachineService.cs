using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteHomePCL.Models;
using RemoteHomePCL.Models.Enums;

namespace RemoteHome.Pages.WashMachine
{
    public interface IWashMachineService
    {
        Task SwitchPower(bool value);
        Task<BaseResponse<bool>> GetPowerSwichStatus();
        Task<List<WashMachineProgramsEnum>> GetAllPrograms();
        Task StartWashing(WashMachineProgramsEnum pickedProgram);
        Task<double> GetCurrentProgress();
        string GetCurrentStatus();
    }
}