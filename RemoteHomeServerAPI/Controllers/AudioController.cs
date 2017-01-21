using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RemoteHomePCL.Models;
using RemoteHomeServerAPI.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RemoteHomeServerAPI.Controllers
{
    public class AudioController : ApiController
    {
        private readonly IAudioService _service;

        public AudioController(IAudioService service)
        {
            _service = service;
        }

        [Route("Audio/GetAllSongs")]
        [HttpGet]
        public BaseResponse<List<SongModel>> GetAllSongs()
        {
            return _service.GetAllSongs();
        }

        [Route("Audio/PlaySong")]
        [HttpPost]
        public void PlaySong(MessageModel<SongModel> message)
        {
            _service.Start(message.MessageObject);
        }

        [Route("Audio/StopSong")]
        [HttpGet]
        public HttpResponseMessage StopSong()
        {
            _service.Stop();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("Audio/PauseSong")]
        [HttpGet]
        public HttpResponseMessage PauseSong()
        {
            _service.Pause();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("Audio/SwitchPower")]
        [HttpPost]
        public void SwitchPower(MessageModel<bool> message)
        {
            _service.SwitchPower(message.MessageObject);
        }

        [Route("Audio/PowerSwitchStatus")]
        [HttpGet]
        public HttpResponseMessage PowerSwitchStatus()
        {
            var result = _service.PowerSwitchStatus();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("Audio/GetCurrentSong")]
        [HttpGet]
        public HttpResponseMessage GetCurrentSong()
        {
            var result = _service.GetCurrentSong();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}