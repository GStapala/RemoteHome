using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RemoteHomePCL.Models;
using RemoteHomePCL.Models.Enums;
using RemoteHomeServerAPI.Services;

namespace RemoteHomeServerAPI.Controllers
{
    [RoutePrefix("api/WashMachine")]
    public class WashMachineController : ApiController
    {
        private readonly IWashMachineService _service;

        public WashMachineController(IWashMachineService service)
        {
            _service = service;
        }

        [Route("GetAllPrograms")]
        [HttpGet]
        public BaseResponse<List<WashMachineProgramsEnum>> GetAllPrograms()
        {
            return _service.GetAllPrograms();
        }

        [Route("StartWashing")]
        [HttpPost]
        public void StartWashing(MessageModel<WashMachineProgramsEnum> program)
        {
            _service.StartWashing(program.MessageObject);
        }

        [Route("SwitchPower")]
        //[Route("SwitchPower/{power}")]
        [HttpPost]
        public void SwitchPower(MessageModel<bool> model)
        {
            _service.SwitchPower(model.MessageObject);
        }

        [Route("PowerSwitchStatus")]
        [HttpGet]
        public HttpResponseMessage PowerSwitchStatus()
        {
            var result = _service.PowerSwitchStatus();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("CurrentProgress")]
        [HttpGet]
        public HttpResponseMessage CurrentProgress()
        {
            var result = _service.GetProgress();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}