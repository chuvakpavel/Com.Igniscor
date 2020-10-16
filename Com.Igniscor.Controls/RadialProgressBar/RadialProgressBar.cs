using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace Com.Controls.RadialProgressBar
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
            MinPercentageValue,
            BindingMode.OneWay,
            PercentageValue_OnValidateValue,
            RadialProgressBar_OnPropertyChanged);

        public float PercentageValue
        {
            get => (float) GetValue(PercentageValueProperty);
            set => SetValue(PercentageValueProperty, value);
        }

        private static bool PercentageValue_OnValidateValue(BindableObject bindable, object value) =>
            value != null && (float) value >= MinPercentageValue &&
            (float) value <= MaxPercentageValue;

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

            if (!SweepAngle.Equals(MinAngle) &&
                (SweepAngle % MaxAngle).Equals(MinAngle))
            {
                switch (PercentageValue)
                {
                    case MaxPercentageValue:
                    {
                        DrawCircle(canvas, info, barWidth, StartAngle, SweepAngle, startColor,
                            endColor);

                        break;
                    }
                    case MinPercentageValue:
                    {
                        DrawCircle(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);

                        break;
                    }
                    default:
                    {
                        var percentageSweepAngle = (float) Math.Floor(SweepAngle * PercentageValue);

                        DrawCircle(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);
                        DrawArc(canvas, info, barWidth, StartAngle, percentageSweepAngle,
                            startColor, endColor);

                        break;
                    }
                }
            }
            else
            {
                switch (PercentageValue)
                {
                    case MaxPercentageValue:
                    {
                        DrawArc(canvas, info, barWidth, StartAngle, SweepAngle, startColor,
                            endColor);

                        break;
                    }
                    case MinPercentageValue:
                    {
                        DrawArc(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);

                        break;
                    }
                    default:
                    {
                        var percentageSweepAngle = (float) Math.Floor(SweepAngle * PercentageValue);

                        DrawArc(canvas, info, barWidth, StartAngle, SweepAngle,
                            startBackgroundColor, endBackgroundColor);
                        DrawArc(canvas, info, barWidth, StartAngle, percentageSweepAngle,
                            startColor, endColor);

                        break;
                    }
                }
            }
        }

        #region Drawing
        internal const float MinPercentageValue = 0;
        internal const float MaxPercentageValue = 1;
        internal const float MinAngle = 0;
        internal const float MaxAngle = 360;

        internal static void DrawCircle(SKCanvas canvas, SKImageInfo info, float barWidth, float startAngle,
            float sweepAngle, SKColor startColor, SKColor endColor)
        {
            var center = new SKPoint(info.Width / 2f, info.Height / 2f);

            using var path = CreateCirclePath(info.Width, info.Height, barWidth);
            using var paint = CreatePaint(center, startAngle, sweepAngle, startColor, endColor);

            canvas.DrawPath(path, paint);
        }

        internal static void DrawArc(SKCanvas canvas, SKImageInfo info, float barWidth, float startAngle,
            float sweepAngle, SKColor startColor, SKColor endColor)
        {
            var center = new SKPoint(info.Width / 2f, info.Height / 2f);

            using var path = CreateArcPath(info.Width, info.Height, barWidth, startAngle, sweepAngle, center);
            using var paint = CreatePaint(center, startAngle, sweepAngle, startColor, endColor);

            canvas.DrawPath(path, paint);
        }

        private static SKPath CreateCirclePath(int width, int height, float barWidth)
        {
            var path = new SKPath { FillType = SKPathFillType.EvenOdd };
            {
                var center = new SKPoint(width / 2f, height / 2f);

                var outerRect = new SKRect(0, 0, width, height);
                var innerRect = new SKRect(barWidth, barWidth, width - barWidth, height - barWidth);

                path.MoveTo(center);
                path.AddOval(outerRect);
                path.AddOval(innerRect);

                path.Transform(SKMatrix.CreateRotationDegrees(90, center.X, center.Y));

                path.Close();

                return path;
            }
        }

        private static SKPath CreateArcPath(int width, int height, float barWidth, float startAngle, float sweepAngle,
            SKPoint center)
        {
            var path = new SKPath { FillType = SKPathFillType.EvenOdd };
            {
                var startX1 = center.X + (float)(center.X * Math.Cos(DegreesToRadians(startAngle)));
                var startY1 = center.X + (float)(center.Y * Math.Sin(DegreesToRadians(startAngle)));

                var startX2 = center.X + (float)((center.X - barWidth) * Math.Cos(DegreesToRadians(startAngle)));
                var startY2 = center.Y + (float)((center.Y - barWidth) * Math.Sin(DegreesToRadians(startAngle)));

                var endX1 = center.X + (float)(center.X * Math.Cos(DegreesToRadians(sweepAngle + startAngle)));
                var endY1 = center.Y + (float)(center.Y * Math.Sin(DegreesToRadians(sweepAngle + startAngle)));

                var start1 = new SKPoint(startX1, startY1);
                var end1 = new SKPoint(endX1, endY1);
                var start2 = new SKPoint(startX2, startY2);

                var outerRect = new SKRect(0, 0, width, height);
                var innerRect = new SKRect(barWidth, barWidth, width - barWidth, height - barWidth);

                path.MoveTo(start1);
                path.LineTo(start2);
                path.ArcTo(innerRect, startAngle, sweepAngle, false);
                path.LineTo(end1);
                path.ArcTo(outerRect, startAngle, sweepAngle, false);

                path.Transform(SKMatrix.CreateRotationDegrees(90, center.X, center.Y));

                path.Close();

                return path;
            }
        }

        private static SKPaint CreatePaint(SKPoint center, float startAngle, float sweepAngle, SKColor startColor,
            SKColor endColor)
        {
            var matrixRotationAngle = startAngle + 90;

            var matrix = SKMatrix.CreateRotationDegrees(matrixRotationAngle, center.X, center.Y);

            var shader = SKShader.CreateSweepGradient(new SKPoint(center.X, center.Y), new[] { startColor, endColor },
                null, SKShaderTileMode.Clamp, MinAngle, sweepAngle, matrix);

            return new SKPaint
            {
                IsAntialias = true,
                Shader = shader
            };
        }

        private static float DegreesToRadians(float angleInDegrees) =>
            (float)(angleInDegrees * Math.PI / 180);
        #endregion
    }
}