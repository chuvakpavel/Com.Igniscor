using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Igniscor.DevProject.ViewModels
{
    public class GradientRadialProgressBarSampleViewModel : BaseViewModel
    {
        public float StartAngle { get; set; } = 180;
        public float SweepAngle { get; set; } = 360;
        public float PercentageValue { get; set; }
        public float BarWidth { get; set; } = 50f;
    }
}
