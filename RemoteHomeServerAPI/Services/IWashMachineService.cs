using System.Collections.Generic;
using RemoteHomePCL.Models;
using RemoteHomePCL.Models.Enums;

namespace RemoteHomeServerAPI.Services
{
    public interface IWashMachineService
    {
        void SwitchPower(bool value);
        void StartWashing(WashMachineProgramsEnum program);
        double GetProgress();
        BaseResponse<bool> PowerSwitchStatus();
        BaseResponse<List<WashMachineProgramsEnum>> GetAllPrograms();
    }
}