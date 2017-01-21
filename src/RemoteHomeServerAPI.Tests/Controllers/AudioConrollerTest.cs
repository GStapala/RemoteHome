using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using RemoteHomePCL.Models;
using RemoteHomeServerAPI.Controllers;
using RemoteHomeServerAPI.Services;

namespace RemoteHomeServerAPI.Tests.Controllers
{
    [TestFixture]
    public class AudioConrollerTest
    {
        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IAudioService>();
            _audioController = new AudioController(_mockService.Object);
        }

        private AudioController _audioController;
        private Mock<IAudioService> _mockService;
        private const string ErrorMessage = "ERROR";
        private readonly SongModel GoodSong = new SongModel {Title = "GOODSONG", Time = TimeSpan.MaxValue};

        [Test]
        public void GetAllSongs_ShouldReturnsListOfSongs()
        {
            var songs = new List<SongModel>
            {
                new SongModel {Title = "SONG1", Time = TimeSpan.MaxValue}
            };
            _mockService.Setup(x => x.GetAllSongs()).Returns(new BaseResponse<List<SongModel>> {ObjectReturn = songs});

            var result = _audioController.GetAllSongs();

            Assert.IsFalse(result.AnyErrors);
            Assert.AreEqual(songs, result.ObjectReturn);
        }

        [Test]
        public void GetCurrentSong_ProgresNotStarted_ShouldReturnEmptySongModel()
        {
            var emptySongModel = new SongModel();
            _mockService.Setup(x => x.GetCurrentSong())
                .Returns(new BaseResponse<SongModel> {ObjectReturn = emptySongModel});
            _audioController.Request = new HttpRequestMessage();
            _audioController.Request.SetConfiguration(new HttpConfiguration());

            var result = _audioController.GetCurrentSong();
            BaseResponse<SongModel> typedresult;
            result.TryGetContentValue(out typedresult);

            Assert.AreEqual(emptySongModel, typedresult.ObjectReturn);
        }

        [Test]
        public void PauseSong_ShouldReturnOkResponse()
        {
            _audioController.Request = new HttpRequestMessage();
            _audioController.Request.SetConfiguration(new HttpConfiguration());

            var result = _audioController.PauseSong();

            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }


        [Test]
        public void PowerSwitchStatus_ShouldReturnFalse()
        {
            _mockService.Setup(x => x.PowerSwitchStatus()).Returns(new BaseResponse<bool> {ObjectReturn = false});
            _audioController.Request = new HttpRequestMessage();
            _audioController.Request.SetConfiguration(new HttpConfiguration());

            var result = _audioController.PowerSwitchStatus();
            BaseResponse<bool> typedresult;
            result.TryGetContentValue(out typedresult);

            Assert.IsFalse(typedresult.ObjectReturn);
        }

        [Test]
        public void PowerSwitchStatus_ShouldReturnTrue()
        {
            _mockService.Setup(x => x.PowerSwitchStatus()).Returns(new BaseResponse<bool> {ObjectReturn = true});
            _audioController.Request = new HttpRequestMessage();
            _audioController.Request.SetConfiguration(new HttpConfiguration());

            var result = _audioController.PowerSwitchStatus();
            BaseResponse<bool> typedresult;
            result.TryGetContentValue(out typedresult);

            Assert.IsTrue(typedresult.ObjectReturn);
        }

        [Test]
        public void StopSong_ShouldReturnOkResponse()
        {
            _audioController.Request = new HttpRequestMessage();
            _audioController.Request.SetConfiguration(new HttpConfiguration());

            var result = _audioController.StopSong();

            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }
    }
}