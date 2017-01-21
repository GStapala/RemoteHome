namespace RemoteHomePCL.Helpers.Sound
{
    public interface IPlatformSoundPlayer
    {
        void PlaySound(int samplingRate, byte[] pcmData);
        void PlaySound(string assetName);
    }
}