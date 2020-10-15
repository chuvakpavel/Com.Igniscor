using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace TrashBox.Controls.GradientProgressBar
{
    public class GradientProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region Orientation Property

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
            nameof(Orientation),
            typeof(ProgressBarOrientation),
            typeof(GradientProgressBar),
            ProgressBarOrientation.Horizontal,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public ProgressBarOrientation Orientation
        {
            get => (ProgressBarOrientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        #endregion Orientation Property

        #region PecentageValue Property

        public static readonly BindableProperty PercentageValueProperty = BindableProperty.Create(
            nameof(PercentageValue),
            typeof(float),
            typeof(GradientProgressBar),
            0f,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public float PercentageValue
        {
            get => (float) GetValue(PercentageValueProperty);
            set => SetValue(PercentageValueProperty, value);
        }

        #endregion PecentageValue Property

        #region OuterCornerRadius Property

        public static readonly BindableProperty OuterCornerRadiusProperty = BindableProperty.Create(
            nameof(OuterCornerRadius),
            typeof(float),
            typeof(GradientProgressBar),
            5f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            OnPropertyChangedInvalidate);

        public float OuterCornerRadius
        {
            get => (float) GetValue(OuterCornerRadiusProperty);
            set => SetValue(OuterCornerRadiusProperty, value);
        }

        #endregion OuterCornerRadius Property

        #region InnerCornerRadiusProperty

        public static readonly BindableProperty InnerCornerRadiusProperty = BindableProperty.Create(
            nameof(InnerCornerRadius),
            typeof(float),
            typeof(GradientProgressBar),
            5f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            OnPropertyChangedInvalidate);

        public float InnerCornerRadius
        {
            get => (float) GetValue(InnerCornerRadiusProperty);
            set => SetValue(InnerCornerRadiusProperty, value);
        }

        #endregion InnerCornerRadiusProperty

        #region StartProgressColor Property

        public static readonly BindableProperty StartProgressColorProperty = BindableProperty.Create(
            nameof(StartProgressColor),
            typeof(Color),
            typeof(GradientProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color StartProgressColor
        {
            get => (Color) GetValue(StartProgressColorProperty);
            set => SetValue(StartProgressColorProperty, value);
        }

        #endregion StartProgressColor Property

        #region EndProgressColor Property

        public static readonly BindableProperty EndProgressColorProperty = BindableProperty.Create(
            nameof(EndProgressColor),
            typeof(Color),
            typeof(GradientProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color EndProgressColor
        {
            get => (Color) GetValue(EndProgressColorProperty);
            set => SetValue(EndProgressColorProperty, value);
        }

        #endregion EndProgressColor Property

        #region StartBackgroundColor Property

        public static readonly BindableProperty StartBackgroundColorProperty = BindableProperty.Create(
            nameof(StartBackgroundColor),
            typeof(Color),
            typeof(GradientProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

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
            typeof(GradientProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color EndBackgroundColor
        {
            get => (Color) GetValue(EndBackgroundColorProperty);
            set => SetValue(EndBackgroundColorProperty, value);
        }

        #endregion EndBackgroundColor Property

        #endregion Bindable Properties

        protected static void OnPropertyChangedInvalidate(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != newValue)
            {
                ((SKCanvasView) bindable)?.InvalidateSurface();
            }
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear();

            float scale;
            int percentageWidth;

            switch (Orientation)
            {
                case ProgressBarOrientation.Horizontal:
                {
                    scale = CanvasSize.Width / (float) Width;
                    percentageWidth = (int) Math.Floor(info.Width * PercentageValue);

                    break;
                }
                case ProgressBarOrientation.Vertical:
                {
                    scale = CanvasSize.Height / (float) Height;
                    percentageWidth = (int) Math.Floor(info.Height * PercentageValue);

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var outerCornerRadius = OuterCornerRadius * scale;
            var innerCornerRadius = InnerCornerRadius * scale;

            ProgressBarHelper.SetClip(canvas, info, outerCornerRadius);

            ProgressBarHelper.DrawBackground(canvas, Orientation, e.Info, outerCornerRadius,
                StartBackgroundColor.ToSKColor(), EndBackgroundColor.ToSKColor());
            ProgressBarHelper.DrawProgress(canvas, Orientation, e.Info, percentageWidth,
                innerCornerRadius, StartProgressColor.ToSKColor(), EndProgressColor.ToSKColor());
        }
    }
}