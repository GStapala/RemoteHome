using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RemoteHome.Properties;
using RemoteHomePCL.Interfaces;
using RemoteHomePCL.Models;

namespace RemoteHome.Pages.Audio
{
    public class AudioService : IAudioService
    {
        private readonly HttpClient client;
        private ILogger _logger;

        public AudioService(ILogger _logger)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; //Lower then int.max (default)
        }

        public async Task SwitchPower(bool value)
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.AudioBaseUri, "SwitchPower"));
                var message = new MessageModel<bool> { MessageObject = value };
                HttpContent messageConverted = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                await client.PostAsync(uri, messageConverted);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
            }
        }

        public async Task<BaseResponse<bool>> GetPowerSwichStatus()
        {
            var uri = new Uri(string.Concat(Resources.AudioBaseUri, "PowerSwitchStatus"));
            try
            {
                var response = await client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<BaseResponse<bool>>(response);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch status didnt return a value {e}");
                return new BaseResponse<bool> { ObjectReturn = false };
            }
        }

        public async Task<List<SongModel>> GetAllSongs()
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.AudioBaseUri, "GetAllSongs"));
                var response = await client.GetStringAsync(uri);
                var deserialized = JsonConvert.DeserializeObject<BaseResponse<List<SongModel>>>(response);
                if (deserialized.AnyErrors)
                    return deserialized.ObjectReturn;

                throw new Exception("Couldnt get response from server. /n" + deserialized.ErrorMessage);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Power switch error {e}");
                return new List<SongModel>();
            }
        }

        public async Task Play(SongModel songModel)
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.AudioBaseUri, "PlaySong"));
                var message = new MessageModel<SongModel> { MessageObject = songModel };
                HttpContent messageConverted = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                await client.PostAsync(uri, messageConverted);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Play button error {e}");
            }
        }

        public async Task Stop()
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.AudioBaseUri, "Stop"));
                await client.PostAsync(uri, null);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Stop button error {e}");
            }
        }

        public async Task Pause()
        {
            try
            {
                var uri = new Uri(string.Concat(Resources.AudioBaseUri, "Pause"));
                await client.PostAsync(uri, null);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"Pouse button error {e}");
            }
        }

        public async Task<BaseResponse<SongModel>> GetCurrentSong()
        {
            var uri = new Uri(string.Concat(Resources.AudioBaseUri, "GetCurrentSong"));
            try
            {
                var response = await client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<BaseResponse<SongModel>>(response);
            }
            catch (Exception e)
            {
                //TODO Toast message for user
                _logger.Log($"GetCurrentSong error {e}");
                return new BaseResponse<SongModel>();
            }
        }
    }
}