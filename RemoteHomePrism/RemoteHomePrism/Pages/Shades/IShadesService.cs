﻿using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHomePrism.Pages.Shades
{
    public interface IShadesService
    {
        Task SwitchPower(bool value);
        Task<BaseResponse<bool>> GetPowerSwichStatus();
        Task<HouseShadesModel> GetShadesInAllRooms();
        Task SetShades(HouseShadesModel house);
    }
}