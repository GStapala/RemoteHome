using Xamarin.Forms;

namespace RemoteHome.Styles
{
    //https://material.google.com/style/color.html#color-color-palette

    /// <summary>
    ///     Blue
    /// </summary>
    public class WashMachineStyle : DropingPageStyle
    {
        public WashMachineStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#0d47a1"), new NGraphics.Color("#1976d2"),
                new NGraphics.Color("#1e88e5"),
                new NGraphics.Color("#2196f3"), new NGraphics.Color("#64b5f6"), new NGraphics.Color("#42a5f5"),
                "washmachine.png", new[]
                {
                    Color.FromHex("#bbdefb"), Color.FromHex("#90caf9"), Color.FromHex("#64b5f6"),
                    Color.FromHex("#42a5f5"),
                    Color.FromHex("#bbdefb")
                }); //ToDO last 
        }
    }

    /// <summary>
    ///     Deep purple
    /// </summary>
    public class AudioStyle : DropingPageStyle
    {
        public AudioStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#311b92"), new NGraphics.Color("#512da8"),
                new NGraphics.Color("#5e35b1"),
                new NGraphics.Color("#673ab7"), new NGraphics.Color("#9575cd"), new NGraphics.Color("#7e57c2"),
                "audio.png",
                new[]
                {
                    Color.FromHex("#d1c4e9"), Color.FromHex("#b39ddb"), Color.FromHex("#9575cd"),
                    Color.FromHex("#7e57c2")
                });
        }
    }

    public class AboutStyle : DropingPageStyle
    {
        public AboutStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#0d47a1"), new NGraphics.Color("#1976d2"),
                new NGraphics.Color("#1e88e5"),
                new NGraphics.Color("#2196f3"), new NGraphics.Color("#64b5f6"), new NGraphics.Color("#42a5f5"),
                "washmachine.png",
                new[]
                {
                    Color.FromHex("#bbdefb"), Color.FromHex("#90caf9"), Color.FromHex("#64b5f6"),
                    Color.FromHex("#42a5f5")
                });
        }
    }

    public class CameraStyle : DropingPageStyle
    {
        public CameraStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#0d47a1"), new NGraphics.Color("#1976d2"),
                new NGraphics.Color("#1e88e5"),
                new NGraphics.Color("#2196f3"), new NGraphics.Color("#64b5f6"), new NGraphics.Color("#42a5f5"),
                "washmachine.png",
                new[]
                {
                    Color.FromHex("#bbdefb"), Color.FromHex("#90caf9"), Color.FromHex("#64b5f6"),
                    Color.FromHex("#42a5f5")
                });
        }
    }

    //Indygo
    public class ShadesStyle : DropingPageStyle
    {
        public ShadesStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#1A237E"), new NGraphics.Color("#303F9F"),
                new NGraphics.Color("#3949AB"),
                new NGraphics.Color("#3F51B5"), new NGraphics.Color("#7986CB"), new NGraphics.Color("#5C6BC0"),
                "shades.png",
                new[]
                {
                    Color.FromHex("#C5CAE9"), Color.FromHex("#9FA8DA"), Color.FromHex("#7986CB"),
                    Color.FromHex("#5C6BC0")
                });
        }
    }

    ///Green
    public class TemperatureStyle : DropingPageStyle
    {
        public TemperatureStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#1B5E20"), new NGraphics.Color("#388E3C"),
                new NGraphics.Color("#43A047"),
                new NGraphics.Color("#4CAF50"), new NGraphics.Color("#81C784"), new NGraphics.Color("#66BB6A"),
                "temperature.png", new[]
                {
                    Color.FromHex("#C8E6C9"), Color.FromHex("#A5D6A7"), Color.FromHex("#81C784"),
                    Color.FromHex("#66BB6A"),
                    Color.FromHex("#4CAF50"),
                    Color.FromHex("#43A047")
                });
        }
    }

    //Yellow
    public class LightingStyle : DropingPageStyle
    {
        public LightingStyle()
        {
            SetStyle(Color.FromHex("#000000"), Color.FromHex("#F57F17"), new NGraphics.Color("#FBC02D"),
                new NGraphics.Color("#FDD835"),
                new NGraphics.Color("#FFEB3B"), new NGraphics.Color("#FFF176"), new NGraphics.Color("#FFEE58"),
                "lights.png", new[]
                {
                    Color.FromHex("#FFF9C4"),
                    Color.FromHex("#FFF59D"),
                    Color.FromHex("#FFF176"),
                    Color.FromHex("#FFEE58")
                });
        }
    }
}