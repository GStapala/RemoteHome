using Android.Media;
using RemoteHome.Droid.Depenency;
using RemoteHomePCL.Helpers.Sound;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(PlatformSoundPlayer))]

namespace RemoteHome.Droid.Depenency
{
    public class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        private IPlatformSoundPlayer _platformSoundPlayerImplementation;
        private AudioTrack previousAudioTrack;

        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            if (previousAudioTrack != null)
            {
                previousAudioTrack.Stop();
                previousAudioTrack.Release();
            }

            var audioTrack = new AudioTrack(Stream.Music,
                samplingRate,
                ChannelOut.Mono,
                Encoding.Pcm16bit,
                pcmData.Length * sizeof(short),
                AudioTrackMode.Static);

            audioTrack.Write(pcmData, 0, pcmData.Length);
            audioTrack.Play();

            previousAudioTrack = audioTrack;
        }

        //TODO Find out how to proper implement the mediaPlayer
        public void PlaySound(string assetName)
        {
            var player = new MediaPlayer();
            var fd = Application.Context.Assets.OpenFd(assetName);
            player.Prepared += (s, e) => { player.Start(); };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
            player.Completion += (sender, args) => player.Release();

            //Other option :

            //var path = new File(Environment.GetExternalStoragePublicDirectory("raw"), assetName);
            //MediaPlayer mp2 = null;
            //await Task.Run(async () =>
            //{
            //    mp2 = mp2 ?? new MediaPlayer()
            //    //mp2 = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.cartoon008);
            //    mp2.SetDataSource(path.AbsolutePath);
            //    mp2.Start();
            //    await Task.Delay(lenght);
            //});

            //mp2.Release();
        }
    }
}