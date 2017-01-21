using RemoteHomePCL.Interfaces;
using RemoteHomePCL.Models.Enums;

namespace RemoteHome.Pages.WashMachine
{
    public class StringModel : IText
    {
        public WashMachineProgramsEnum ProgramEnum { get; set; }
        public string Text => ProgramEnum.ToString();
    }
}