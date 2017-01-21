using System.Net.Http;
using System.Threading.Tasks;
using RemoteHomePCL.Models;

namespace RemoteHome.Pages.Shades
{
    public class ShadesService : IShadesService
    {
        private readonly HttpClient client;

        public ShadesService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; //Lower then int.max (default)
        }

        public async Task SwitchPower(bool value)
        {
            return;
        }

        public async Task<BaseResponse<bool>> GetPowerSwichStatus()
        {
            return null;
        }

        Task<HouseShadesModel> IShadesService.GetShadesInAllRooms()
        {
            return null;
        }

        public async Task SetShades(HouseShadesModel house)
        {
        }
    }
}