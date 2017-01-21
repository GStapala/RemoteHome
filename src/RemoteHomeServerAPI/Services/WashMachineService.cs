using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using RemoteHomePCL.Models;
using RemoteHomePCL.Models.Enums;
using RemoteHomeServerAPI.Exceptions;

namespace RemoteHomeServerAPI.Services
{
    public class WashMachineService : IWashMachineService
    {
        private readonly List<WashMachineProgramsEnum> _activePrograms;

        private readonly ILog _logger;
        private static CancellationToken _cancellationToken;
        private static bool _power;
        private static double _progress;
        private CancellationTokenSource _progressCancellationTokenSource = new CancellationTokenSource();

        public WashMachineService(ILog logger)
        {
            _logger = logger;
            _activePrograms = new List<WashMachineProgramsEnum>
            {
                WashMachineProgramsEnum.Program,
                WashMachineProgramsEnum.Colors,
                WashMachineProgramsEnum.Fast,
                WashMachineProgramsEnum.Sport,
                WashMachineProgramsEnum.Wool
            };

            _cancellationToken = _progressCancellationTokenSource.Token;
        }

        public void SwitchPower(bool value)
        {
            _logger.Debug($"Changing power switch from {_power}");
            _power = value;
            _logger.Debug($"Changed power switch to {_power}");
            if (!_power)
            {
                _progressCancellationTokenSource.Cancel();
                _progressCancellationTokenSource.Dispose();
                _progressCancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _progressCancellationTokenSource.Token;
                _progress = 0;
            }
        }

        public BaseResponse<bool> PowerSwitchStatus()
        {
            return new BaseResponse<bool> {ObjectReturn = _power};
        }

        public BaseResponse<List<WashMachineProgramsEnum>> GetAllPrograms()
        {
            if (_activePrograms.Count > 0)
                return new BaseResponse<List<WashMachineProgramsEnum>> {ObjectReturn = _activePrograms};
            return new BaseResponse<List<WashMachineProgramsEnum>>
            {
                ErrorMessage = "No programs found",
                ObjectReturn = new List<WashMachineProgramsEnum>()
            };
        }

        public double GetProgress()
        {
            return _progress;
        }

        public async void StartWashing(WashMachineProgramsEnum program)
        {
            if (_progress > 0)
            {
                _logger.Debug($"Wash machine started while previous program didnt end");
                throw new WashMachineInProgressException("Washing already in progress");
            }

            _logger.Debug($"Wash machine started washing with program : {program}");
            //Run washing machine :)
            await Task.Run(async () =>
            {
                while (_power)
                    for (var i = 0; i < 100; i++)
                    {
                        if (_cancellationToken.IsCancellationRequested)
                        {
                            _logger.Debug("Washing canceled");
                            return;
                        }
                        await Task.Delay(1000);
                        _progress = i;
                    }
            });
        }
    }
}