using SkiaSharp;
using System.Reflection;
using Xamarin.Forms;

namespace Com.Igniscor.Controls.Helpers
{
    public static class FontsHelper
    {
        static Assembly appAssembly;
        public static IAssetsHelper AssetsHelper;
        public static SKTypeface GetTypeface(string fullFontName)
        {
            if (string.IsNullOrEmpty(fullFontName))
                return SKTypeface.Default;

            SKTypeface result;

            var stream = appAssembly.GetManifestResourceStream(appAssembly.GetName().Name +"."+ fullFontName);
            if (stream == null)
            {
               result =  AssetsHelper.GetSkiaTypefaceFromAssetFont(fullFontName);
            }
            else
            {
                result = SKTypeface.FromStream(stream);
            }

            return result == null ? SKTypeface.Default : result;
        }

        public static void Init(Assembly assembly)
        {
            appAssembly = assembly;

            if(Device.RuntimePlatform == Device.Android)
            {
                AssetsHelper = new Android.AssetsHelperService();
            }
            else
            {
                AssetsHelper = new iOS.AssetsHelperService();
            }
        }
    }
}
