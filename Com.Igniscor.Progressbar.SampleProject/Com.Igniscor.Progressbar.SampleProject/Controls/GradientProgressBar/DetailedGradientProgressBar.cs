using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace Com.Igniscor.Progressbar.SampleProject.Controls.GradientProgressBar
{
    public class DetailedGradientProgressBar : GradientProgressBar
    {
        #region Bindable Properties

        #region FontSize Property

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(float),
            typeof(DetailedGradientProgressBar),
            12f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            OnPropertyChangedInvalidate);

        public float FontSize
        {
            get => (float) GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion FontSize Property

        #region StringFormat Property

        public static readonly BindableProperty StringFormatProperty = BindableProperty.Create(
            nameof(StringFormat),
            typeof(string),
            typeof(DetailedGradientProgressBar),
            "{0:0%}",
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public string StringFormat
        {
            get => (string) GetValue(StringFormatProperty);
            set => SetValue(StringFormatProperty, value);
        }

        #endregion StringFormat Property

        #region PrimaryTextColor Property

        public static readonly BindableProperty PrimaryTextColorProperty = BindableProperty.Create(
            nameof(PrimaryTextColor),
            typeof(Color),
            typeof(DetailedGradientProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color PrimaryTextColor
        {
            get => (Color) GetValue(PrimaryTextColorProperty);
            set => SetValue(PrimaryTextColorProperty, value);
        }

        #endregion PrimaryTextColor Property

        #region SecondaryTextColor Property

        public static readonly BindableProperty SecondaryTextColorProperty = BindableProperty.Create(
            nameof(SecondaryTextColor),
            typeof(Color),
            typeof(DetailedGradientProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color SecondaryTextColor
        {
            get => (Color) GetValue(SecondaryTextColorProperty);
            set => SetValue(SecondaryTextColorProperty, value);
        }

        #endregion SecondaryTextColor Property

        #endregion Bindable Properties

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;
            var info = e.Info;

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

            var textSize = FontSize * scale;

            ProgressBarHelper.DrawText(canvas, Orientation, e.Info, percentageWidth, textSize,
                PercentageValue, StringFormat, PrimaryTextColor.ToSKColor(), SecondaryTextColor.ToSKColor());
        }
    }
}