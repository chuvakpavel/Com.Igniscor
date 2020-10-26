using Com.Igniscor.Controls.Helpers;
using Foundation;
using SkiaSharp;
using System.IO;
using Xamarin.Forms;

namespace Com.Igniscor.Controls.iOS
{
    public class AssetsHelperService : IAssetsHelper
    {
        public SKTypeface GetSkiaTypefaceFromAssetFont(string fontName)
        {
            string fontFile = Path.Combine(NSBundle.MainBundle.BundlePath, fontName);
            SkiaSharp.SKTypeface typeFace;

            using (var asset = File.OpenRead(fontFile))
            {
                var fontStream = new MemoryStream();
                asset.CopyTo(fontStream);
                fontStream.Flush();
                fontStream.Position = 0;
                typeFace = SKTypeface.FromStream(fontStream);
            }
            return typeFace;
        }
    }
}
