using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Igniscor.Controls.Helpers
{
    public interface IAssetsHelper
    {
        SKTypeface GetSkiaTypefaceFromAssetFont(string fontName);
    }
}
