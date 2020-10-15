using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Igniscor.Progressbar.SampleProject.ViewModels
{
    public class GradientProgressBarSampleViewModel : BaseViewModel
    {
        public float PercentageValue { get; set; } = 0.75f;
        public float FontSize { get; set; } = 40f;
        public float OuterCornerRadius { get; set; } = 10f;
        public float InnerCornerRadius { get; set; } = 10f;
    }
}
