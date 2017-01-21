using System.Net.Http;
using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHome.Pages.Temperature
{
    public class TemperatureService : ITemperatureService
    {
        private readonly HttpClient client;

        public TemperatureService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; //Lower then int.max (default)
        }

        public async Task SwitchPower(bool value)
        {
        }

        public async Task<BaseResponse<bool>> GetPowerSwichStatus()
        {
            return new BaseResponse<bool>();
        }

        public async Task<HouseTemperatureModel> GetTemperatureInAllRooms()
        {
            return new HouseTemperatureModel();
        }

        public Task SetTemperature(HouseTemperatureModel house)
        {
            return null;
        }
    }
}