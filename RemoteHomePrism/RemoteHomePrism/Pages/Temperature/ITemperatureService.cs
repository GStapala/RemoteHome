using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHomePrism.Pages.Temperature
{
    public interface ITemperatureService
    {
        Task SwitchPower(bool value);
        Task<BaseResponse<bool>> GetPowerSwichStatus();
        Task<HouseTemperatureModel> GetTemperatureInAllRooms();
        Task SetTemperature(HouseTemperatureModel house);
    }
}