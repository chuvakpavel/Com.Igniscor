using Com.Igniscor.Controls.Helpers;
using SkiaSharp;
using System.IO;
using Android.App;

namespace Com.Igniscor.Controls.Android
{
    public class AssetsHelperService : IAssetsHelper
    {
        public SKTypeface GetSkiaTypefaceFromAssetFont(string fontName)
        {
            SkiaSharp.SKTypeface typeFace;

            var assetManager = Application.Context.Assets;
            using (var asset = assetManager.Open("Fonts/" + fontName))
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
