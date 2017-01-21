using System;
using System.Net.Http;
using System.Threading.Tasks;
using RemoteHomePCL.Interfaces;
using RemoteHomePCL.Models;

namespace RemoteHome.Pages.Lighting
{
    public class LightingService : ILightingService
    {
        private readonly HttpClient client;
        private ILogger _logger;

        public LightingService(ILogger logger)
        {
            _logger = logger;
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; //Lower then int.max (default)
        }

        public Task SwitchPower(bool value)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> GetPowerSwichStatus()
        {
            throw new NotImplementedException();
        }
    }
}