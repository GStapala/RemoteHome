using System;
using Xamarin.Forms;

namespace RemoteHomePCL.Helpers
{
    public class ColorInterpolator
    {
        public static Color InterpolateColor(Color[] colors, double x)
        {
            double r = 0.0, g = 0.0, b = 0.0;
            var total = 0.0;
            var step = 1.0 / (colors.Length - 1);
            var mu = 0.0;
            var sigma_2 = 0.035;

            foreach (var color in colors)
            {
                total += Math.Exp(-(x - mu) * (x - mu) / (2.0 * sigma_2)) / Math.Sqrt(2.0 * Math.PI * sigma_2);
                mu += step;
            }

            mu = 0.0;
            foreach (var color in colors)
            {
                var percent = Math.Exp(-(x - mu) * (x - mu) / (2.0 * sigma_2)) / Math.Sqrt(2.0 * Math.PI * sigma_2);
                mu += step;

                r += color.R * percent / total;
                g += color.G * percent / total;
                b += color.B * percent / total;
            }

            return new Color(r, g, b, 255);
        }
    }
}