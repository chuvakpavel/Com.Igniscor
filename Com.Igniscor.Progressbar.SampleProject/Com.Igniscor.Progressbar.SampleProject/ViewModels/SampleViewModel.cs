using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Com.Igniscor.DevProject.ViewModels
{
    public class SampleViewModel : BaseViewModel
    {
        public float PercentageValue { get; set; }

        public SampleViewModel()
        {
            TimerCallback tm = new TimerCallback(UpdateProgress);
            Timer timer = new Timer(tm, 0, 0, 30);
        }

        public void UpdateProgress(object obj)
        {
            if (PercentageValue > 0.99f)
            {
                PercentageValue = 0.0f;
            }
            PercentageValue = PercentageValue + 0.01f;
        }
    }
}
