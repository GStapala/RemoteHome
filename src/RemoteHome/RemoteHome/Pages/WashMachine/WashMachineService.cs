using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RemoteHome.Properties;
using RemoteHomePCL.Interfaces;
using RemoteHomePCL.Models;
using RemoteHomePCL.Models.Enums;

namespace RemoteHome.Pages.WashMachine
{
    public class WashMachineService : IWashMachineService
    {
        private readonly HttpClient _client;
        private ILogger _logger;

        public WashMachineService(ILogger logger)
        {
            _logger = logger;
            _client = new HttpClient();
        }

        public async Task SwitchPower(bool value)
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.WashMachineBaseUri, "SwitchPower"));
                var message = new MessageModel<bool> {MessageObject = value};
                HttpContent messageConverted = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                await _client.PostAsync(uri, messageConverted);
            
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
            }
        }

        public async Task<BaseResponse<bool>> GetPowerSwichStatus()
        {
            var uri = new Uri(string.Concat(Resources.WashMachineBaseUri, "PowerSwitchStatus"));
            try
            {
                var response = await _client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<BaseResponse<bool>>(response);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
                return new BaseResponse<bool> {ObjectReturn = false};
            }
        }


        public async Task<List<WashMachineProgramsEnum>> GetAllPrograms()
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.WashMachineBaseUri, "GetAllPrograms"));
                var response = await _client.GetStringAsync(uri);
                var deserialized = JsonConvert.DeserializeObject<BaseResponse<List<WashMachineProgramsEnum>>>(response);
                if (!deserialized.AnyErrors)
                    return deserialized.ObjectReturn;

                throw new Exception("Couldnt get response from server. /n" + deserialized.ErrorMessage);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
                return new List<WashMachineProgramsEnum>();
            }
        }

        public async Task StartWashing(WashMachineProgramsEnum pickedProgram)
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.WashMachineBaseUri, "StartWashing"));
                var message = new MessageModel<WashMachineProgramsEnum> {MessageObject = pickedProgram};
                HttpContent messageConverted = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8,
                    "application/json");
                await _client.PostAsync(uri, messageConverted);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
            }
        }

        public async Task<double> GetCurrentProgress()
        {
            var uri = new Uri(string.Concat(Resources.WashMachineBaseUri, "CurrentProgress"));
            try
            {
                var response = await _client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<double>(response);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
                return 0d;
            }
        }

        public string GetCurrentStatus()
        {
            return "TODO";
        }
    }
}