
namespace Com.Igniscor.DevProject.ViewModels
{
    public class GradientProgressBarSampleViewModel : BaseViewModel
    {
        public float PercentageValue { get; set; } = 0.75f;
        public float FontSize { get; set; } = 40f;
        public float OuterCornerRadius { get; set; } = 10f;
        public float InnerCornerRadius { get; set; } = 10f;

        public string FontName { get; set; } = "SansitaSwashed-Regular.ttf";

        public float BorderWidth { get; set; } = 20f;
        private string borderColorHex;
        public string BorderColorHex
        {
            get
            {
                return borderColorHex;
            }
            set
            {
                if (value.Length == 9)
                {
                    borderColorHex = value;
                    BorderColor = SkiaSharp.SKColor.Parse(borderColorHex);
                }
            }
        }
        public SkiaSharp.SKColor BorderColor { get; set; }

        public GradientProgressBarSampleViewModel()
        {
        }
    }
}
