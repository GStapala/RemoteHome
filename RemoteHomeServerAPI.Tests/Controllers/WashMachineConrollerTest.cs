using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using RemoteHomePCL.Models;
using RemoteHomePCL.Models.Enums;
using RemoteHomeServerAPI.Controllers;
using RemoteHomeServerAPI.Exceptions;
using RemoteHomeServerAPI.Services;
using RemoteHomeServerAPI.Tests.Attributes;

namespace RemoteHomeServerAPI.Tests.Controllers
{
    [TestFixture]
    public class WashMachineConrollerTest
    {
        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IWashMachineService>();
            _washMachineController = new WashMachineController(_mockService.Object);
        }

        private WashMachineController _washMachineController;
        private Mock<IWashMachineService> _mockService;
        private const string ErrorMessage = "ERROR";

        [Test]
        public void CurrentProgress_ProgresNotStarted_ShouldReturnZero()
        {
            var expectedResult = 0d;
            _mockService.Setup(x => x.GetProgress()).Returns(0);

            var result = _mockService.Object.GetProgress();

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void GetAllPrograms_ShouldReturnEmptyListWithErrorMessage()
        {
            var enums = new List<WashMachineProgramsEnum>();
            _mockService.Setup(x => x.GetAllPrograms())
                .Returns(new BaseResponse<List<WashMachineProgramsEnum>>
                {
                    ObjectReturn = enums,
                    ErrorMessage = ErrorMessage
                });

            var result = _washMachineController.GetAllPrograms();

            Assert.IsTrue(result.AnyErrors && result.ObjectReturn.Count == 0);
        }

        [Test]
        public void GetAllPrograms_ShouldReturnsListOfAllPrograms()
        {
            var enums = new List<WashMachineProgramsEnum>
            {
                WashMachineProgramsEnum.Colors,
                WashMachineProgramsEnum.Fast
            };
            _mockService.Setup(x => x.GetAllPrograms())
                .Returns(new BaseResponse<List<WashMachineProgramsEnum>> {ObjectReturn = enums});

            var result = _washMachineController.GetAllPrograms();

            Assert.IsFalse(result.AnyErrors);
            Assert.AreEqual(enums, result.ObjectReturn);
        }


        [Test]
        public void PowerSwitchStatus_ShouldReturnFalse()
        {
            _mockService.Setup(x => x.PowerSwitchStatus()).Returns(new BaseResponse<bool> {ObjectReturn = false});
            _washMachineController.Request = new HttpRequestMessage();
            _washMachineController.Request.SetConfiguration(new HttpConfiguration());

            var result = _washMachineController.PowerSwitchStatus();
            BaseResponse<bool> typedresult;
            result.TryGetContentValue(out typedresult);

            Assert.IsFalse(typedresult.ObjectReturn);
        }

        [Test]
        public void PowerSwitchStatus_ShouldReturnTrue()
        {
            _mockService.Setup(x => x.PowerSwitchStatus()).Returns(new BaseResponse<bool> {ObjectReturn = true});
            _washMachineController.Request = new HttpRequestMessage();
            _washMachineController.Request.SetConfiguration(new HttpConfiguration());

            var result = _washMachineController.PowerSwitchStatus();
            BaseResponse<bool> typedresult;
            result.TryGetContentValue(out typedresult);

            Assert.IsTrue(typedresult.ObjectReturn);
        }

        [Test]
        [ExpectedException(typeof(WashMachineInProgressException))]
        public void StartWashing_WashMachineStartedWhenWasInProgess_ShouldThrowException()
        {
            var colorsProgram = WashMachineProgramsEnum.Colors;
            _mockService.Setup(x => x.StartWashing(colorsProgram)).Throws(new WashMachineInProgressException());

            _washMachineController.StartWashing(new MessageModel<WashMachineProgramsEnum>
            {
                MessageObject = colorsProgram
            });
            //Should fail becouse it didnt throw exception
            Assert.Fail();
        }
    }
}