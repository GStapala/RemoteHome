using System;
using RemoteHomePCL.Interfaces;

namespace RemoteHomePCL.Models
{
    public class SongModel : IText
    {
        public SongModel()
        {
            Title = "-";
        }

        public int Id { get; set; }
        public double Progress { get; set; }
        public string Title { get; set; }
        public TimeSpan Time { get; set; }
        public string Text => Title;
    }
}