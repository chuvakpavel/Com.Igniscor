using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace TrashBox.Controls.GradientRadialProgressBar
{
    public class RadialProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region StartAngle Property

        public static readonly BindableProperty StartAngleProperty = BindableProperty.Create(
            nameof(StartAngle),
            typeof(float),
            typeof(RadialProgressBar),
            0f,
            BindingMode.OneWay,
            propertyChanged: RadialProgressBar_OnPropertyChanged);

        public float StartAngle
        {
            get => (float) GetValue(StartAngleProperty);
            set => SetValue(StartAngleProperty, value);
        }

        #endregion StartAngle Property

        #region SweepAngle Property

        public static readonly BindableProperty SweepAngleProperty = BindableProperty.Create(
            nameof(SweepAngle),
            typeof(float),
            typeof(RadialProgressBar),
            90f,
            BindingMode.OneWay,
            propertyChanged: RadialProgressBar_OnPropertyChanged);

        public float SweepAngle
        {
            get => (float) GetValue(SweepAngleProperty);
            set => SetValue(SweepAngleProperty, value);
        }

        #endregion SweepAngle Property

        #region PercentageValue Property

        public static readonly BindableProperty PercentageValueProperty = BindableProperty.Create(
            nameof(PercentageValue),
            typeof(float),
            typeof(RadialProgressBar),
            RadialProgressBarHelper.MinPercentageValue,
            BindingMode.OneWay,
            PercentageValue_OnValidateValue,
            RadialProgressBar_OnPropertyChanged);

        public float PercentageValue
        {
            get => (float) GetValue(PercentageValueProperty);
            set => SetValue(PercentageValueProperty, value);
        }

        private static bool PercentageValue_OnValidateValue(BindableObject bindable, object value) =>
            value != null && (float) value >= RadialProgressBarHelper.MinPercentageValue &&
            (float) value <= RadialProgressBarHelper.MaxPercentageValue;

        #endregion PercentageValue Property

        #region BarWidth Property

        public static readonly BindableProperty BarWidthProperty = BindableProperty.Create(
            nameof(BarWidth),
            typeof(float),
            typeof(RadialProgressBar),
            10f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            RadialProgressBar_OnPropertyChanged);

        public float BarWidth
        {
            get => (float) GetValue(BarWidthProperty);
            set => SetValue(BarWidthProperty, value);
        }

        #endregion BarWidth Property

        #region StartProgressColor Property

        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            nameof(StartColor),
            typeof(Color),
            typeof(RadialProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            RadialProgressBar_OnPropertyChanged);

        public Color StartColor
        {
            get => (Color) GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }

        #endregion StartProgressColor Property

        #region EndProgressColor Property

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            nameof(EndColor),
            typeof(Color),
            typeof(RadialProgressBar),
            Color.Black,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            RadialProgressBar_OnPropertyChanged);

        public Color EndColor
        {
            get => (Color) GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        #endregion EndProgressColor Property

        #region StartBackgroundColor Property

        public static readonly BindableProperty StartBackgroundColorProperty = BindableProperty.Create(
            nameof(StartBackgroundColor),
            typeof(Color),
            typeof(RadialProgressBar),
            Color.Red,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            RadialProgressBar_OnPropertyChanged);

        public Color StartBackgroundColor
        {
            get => (Color) GetValue(StartBackgroundColorProperty);
            set => SetValue(StartBackgroundColorProperty, value);
        }

        #endregion StartBackgroundColor Property

        #region EndBackgroundColor Property

        public static readonly BindableProperty EndBackgroundColorProperty = BindableProperty.Create(
            nameof(EndBackgroundColor),
            typeof(Color),
            typeof(RadialProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            RadialProgressBar_OnPropertyChanged);

        public Color EndBackgroundColor
        {
            get => (Color) GetValue(EndBackgroundColorProperty);
            set => SetValue(EndBackgroundColorProperty, value);
        }

        #endregion EndBackgroundColor Property

        #endregion Bindable Properties

        private static void RadialProgressBar_OnPropertyChanged(BindableObject bindable, object oldValue,
            object newValue) =>
            ((SKCanvasView) bindable).InvalidateSurface();

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear();

            var startColor = StartColor.ToSKColor();
            var endColor = EndColor.ToSKColor();
            var startBackgroundColor = StartBackgroundColor.ToSKColor();
            var endBackgroundColor = EndBackgroundColor.ToSKColor();
            var scale = CanvasSize.Width / (float) Width;
            var barWidth = BarWidth * scale;

            if (barWidth > info.Width / 2f)
            {
                barWidth = info.Width / 2f;
            }

            if (!SweepAngle.Equals(RadialProgressBarHelper.MinAngle) &&
                (SweepAngle % RadialProgressBarHelper.MaxAngle).Equals(RadialProgressBarHelper.MinAngle))
            {
                switch (PercentageValue)
                {
                    case RadialProgressBarHelper.MaxPercentageValue:
                    {
                        RadialProgressBarHelper.DrawCircle(canvas, info, barWidth, StartAngle, SweepAngle, startColor,
                            endColor);

                        break;
                    }
                    case RadialProgressBarHelper.MinPercentageValue:
                    {
                        RadialProgressBarHelper.DrawCircle(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);

                        break;
                    }
                    default:
                    {
                        var percentageSweepAngle = (float) Math.Floor(SweepAngle * PercentageValue);

                        RadialProgressBarHelper.DrawCircle(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);
                        RadialProgressBarHelper.DrawArc(canvas, info, barWidth, StartAngle, percentageSweepAngle,
                            startColor, endColor);

                        break;
                    }
                }
            }
            else
            {
                switch (PercentageValue)
                {
                    case RadialProgressBarHelper.MaxPercentageValue:
                    {
                        RadialProgressBarHelper.DrawArc(canvas, info, barWidth, StartAngle, SweepAngle, startColor,
                            endColor);

                        break;
                    }
                    case RadialProgressBarHelper.MinPercentageValue:
                    {
                        RadialProgressBarHelper.DrawArc(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);

                        break;
                    }
                    default:
                    {
                        var percentageSweepAngle = (float) Math.Floor(SweepAngle * PercentageValue);

                        RadialProgressBarHelper.DrawArc(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);
                        RadialProgressBarHelper.DrawArc(canvas, info, barWidth, StartAngle, percentageSweepAngle,
                            startColor, endColor);

                        break;
                    }
                }
            }
        }
    }
}