using System;
using System.Globalization;
using Android.Graphics;

namespace RemoteHomePrism.Droid.Extensions
{
    public static class ColorExtension
    {
        public static Color GetColorFromHex(this string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6) throw new Exception("Color not valid");
            return Color.Rgb(
                int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber),
                int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber),
                int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber));
        }
    }
}