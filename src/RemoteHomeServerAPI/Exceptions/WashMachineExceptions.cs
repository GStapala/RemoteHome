using System;

namespace RemoteHomeServerAPI.Exceptions
{
    public class WashMachineInProgressException : Exception
    {
        public WashMachineInProgressException()
        {
        }

        public WashMachineInProgressException(string message) : base(message)
        {
        }
    }
}