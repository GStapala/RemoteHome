﻿using System;
using Xamarin.Forms;

namespace RemoteHomePCL.Helpers.Sound
{
    public static class SoundPlayer
    {
        private const int samplingRate = 22050;

        // Hard-coded for monaural, 16-bit-per-sample PCM
        public static void PlaySound(double frequency = 440, int duration = 250)
        {
            var shortBuffer = new short[samplingRate * duration / 1000];
            var angleIncrement = frequency / samplingRate;
            double angle = 0; // normalized 0 to 1

            for (var i = 0; i < shortBuffer.Length; i++)
            {
                // Define triangle wave
                double sample;

                // 0 to 1
                if (angle < 0.25)
                    sample = 4 * angle;

                // 1 to -1
                else if (angle < 0.75)
                    sample = 4 * (0.5 - angle);

                // -1 to 0
                else
                    sample = 4 * (angle - 1);

                shortBuffer[i] = (short) (32767 * sample);
                angle += angleIncrement;

                while (angle > 1)
                    angle -= 1;
            }

            var byteBuffer = new byte[2 * shortBuffer.Length];
            Buffer.BlockCopy(shortBuffer, 0, byteBuffer, 0, byteBuffer.Length);

            DependencyService.Get<IPlatformSoundPlayer>().PlaySound(samplingRate, byteBuffer);
        }

        //Plays sound from resources
        public static void PlaySound(string assetName)
        {
            DependencyService.Get<IPlatformSoundPlayer>().PlaySound(assetName);
        }
    }
}