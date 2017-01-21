using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RemoteHomePCL.Interfaces;
using RemoteHomePCL.Models;
using RemoteHomePrism.Properties;

namespace RemoteHomePrism.Pages.Lighting
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