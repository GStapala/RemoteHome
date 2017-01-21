using NGraphics;
using Color = Xamarin.Forms.Color;

namespace RemoteHomePrism.Styles
{
    //https://material.google.com/style/color.html#color-color-palette
    /// <summary>
    ///     Model for page style
    /// </summary>
    public class DropingPageStyle
    {
        public Color TitleColor { get; private set; } = Color.Black;
        public Color BackgroundColor { get; private set; } = Color.Black;
        public NGraphics.Color DropColor { get; private set; } = Colors.Black;
        public NGraphics.Color DropColorPen { get; private set; } = Colors.Black;
        public NGraphics.Color BackgroundTopColor { get; private set; } = Colors.Black;
        public NGraphics.Color HexColor { get; private set; } = Colors.Black;
        public NGraphics.Color HexPenColor { get; private set; } = Colors.Black;
        public string IconPath { get; private set; } = "icon.png";
        public Color[] ControlColors { get; private set; } = {Color.Black, Color.White};

        /// <summary>
        ///     Set styles from material.io
        /// </summary>
        /// <param name="titleColor">700</param>
        /// <param name="backgroundColor">900</param>
        /// <param name="dropColor">700</param>
        /// <param name="dropColorPen">600</param>
        /// <param name="backgroundTopColor">500</param>
        /// <param name="hexColor">300</param>
        /// <param name="hexPenColor">400</param>
        /// <param name="iconPath"></param>
        /// <param name="controlsColors">100-900</param>
        /// <returns></returns>
        public DropingPageStyle SetStyle(Color titleColor, Color backgroundColor, NGraphics.Color dropColor,
            NGraphics.Color dropColorPen, NGraphics.Color backgroundTopColor, NGraphics.Color hexColor,
            NGraphics.Color hexPenColor, string iconPath, Color[] controlsColors)
        {
            TitleColor = titleColor; //700
            BackgroundColor = backgroundColor; //900
            DropColor = dropColor; //700
            DropColorPen = dropColorPen; //600
            BackgroundTopColor = backgroundTopColor; //500
            HexColor = hexColor; //300
            HexPenColor = hexPenColor; //400
            IconPath = iconPath;
            ControlColors = controlsColors; //100->900

            return this;
        }
    }
}