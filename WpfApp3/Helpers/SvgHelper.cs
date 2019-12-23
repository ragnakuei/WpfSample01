using System.IO;
using System.Windows;
using System.Windows.Media;
using DevExpress.Utils.Svg;
using DevExpress.Xpf.Core.Native;

namespace WpfApp3.Helpers
{
    public static class SvgHelper
    {
        public static ImageSource FromFilePathToImageSource(string svgFilePath)
        {
            var svgStream = File.Open(svgFilePath, FileMode.Open, FileAccess.Read);
            var svgImage = SvgLoader.LoadFromStream(svgStream);
            var size = new Size(svgImage.Width * ScreenHelper.ScaleX, svgImage.Height * ScreenHelper.ScaleX);
            return WpfSvgRenderer.CreateImageSource(svgImage, size, null, null, true);
        }
    }
}