using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace Com.Igniscor.Controls.ProgressBar
{ 
    public partial class DetailedProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region Orientation Property

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
            nameof(Orientation),
            typeof(ProgressBarOrientation),
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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
            typeof(DetailedProgressBar),
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

        #region FontSize Property

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(float),
            typeof(DetailedProgressBar),
            12f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float)value >= 0,
            OnPropertyChangedInvalidate);

        public float FontSize
        {
            get => (float)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion FontSize Property

        #region StringFormat Property

        public static readonly BindableProperty StringFormatProperty = BindableProperty.Create(
            nameof(StringFormat),
            typeof(string),
            typeof(DetailedProgressBar),
            "{0:0%}",
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public string StringFormat
        {
            get => (string)GetValue(StringFormatProperty);
            set => SetValue(StringFormatProperty, value);
        }

        #endregion StringFormat Property

        #region PrimaryTextColor Property

        public static readonly BindableProperty PrimaryTextColorProperty = BindableProperty.Create(
            nameof(PrimaryTextColor),
            typeof(Color),
            typeof(DetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color PrimaryTextColor
        {
            get => (Color)GetValue(PrimaryTextColorProperty);
            set => SetValue(PrimaryTextColorProperty, value);
        }

        #endregion PrimaryTextColor Property

        #region SecondaryTextColor Property

        public static readonly BindableProperty SecondaryTextColorProperty = BindableProperty.Create(
            nameof(SecondaryTextColor),
            typeof(Color),
            typeof(DetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color SecondaryTextColor
        {
            get => (Color)GetValue(SecondaryTextColorProperty);
            set => SetValue(SecondaryTextColorProperty, value);
        }

        #endregion SecondaryTextColor Property

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

            canvas.Save();
            SKPath clipPath = new SKPath();

            var textSize = FontSize * scale;

            DrawBackground(canvas,clipPath, Orientation, ProgressTextPositionVertical, textSize, e.Info, outerCornerRadius,
                StartBackgroundColor.ToSKColor(), EndBackgroundColor.ToSKColor());
            SetClip(canvas,clipPath);

            DrawProgress(canvas, Orientation, ProgressTextPositionVertical, textSize, e.Info, percentageWidth,
                innerCornerRadius, StartProgressColor.ToSKColor(), EndProgressColor.ToSKColor());

            canvas.Restore();
            DrawTextWithPosition(canvas, Orientation,ProgressTextPosition,ProgressTextPositionVertical,FontName, e.Info, percentageWidth, textSize,
                PercentageValue, StringFormat, PrimaryTextColor.ToSKColor(), SecondaryTextColor.ToSKColor());
        }

        #region Drawing
        internal static void SetClip(SKCanvas canvas, SKImageInfo info, float outerCornerRadius)
        {
            var clipPath = CreateClipPath(info, outerCornerRadius);

            canvas.ClipPath(clipPath, SKClipOperation.Intersect, true);
        }

        internal static void DrawBackground(SKCanvas canvas, ProgressBarOrientation orientation, SKImageInfo info,
            float outerCornerRadius, SKColor startColor, SKColor endColor)
        {
            var backgroundBar = CreateRoundRect(info.Width, info.Height, outerCornerRadius);

            SKPoint startPoint;
            SKPoint endPoint;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        startPoint = new SKPoint(backgroundBar.Rect.Left, backgroundBar.Rect.Top);
                        endPoint = new SKPoint(backgroundBar.Rect.Right, backgroundBar.Rect.Top);

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        startPoint = new SKPoint(backgroundBar.Rect.Left, backgroundBar.Rect.Top);
                        endPoint = new SKPoint(backgroundBar.Rect.Left, backgroundBar.Rect.Bottom);

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
            }

            using var paint = new SKPaint
            {
                IsAntialias = true,
                Shader = SKShader.CreateLinearGradient(startPoint, endPoint, new[] { startColor, endColor },
                    new float[] { 0, 1 }, SKShaderTileMode.Clamp)
            };

            canvas.DrawRoundRect(backgroundBar, paint);
        }

        internal static void DrawProgress(SKCanvas canvas, ProgressBarOrientation orientation, SKImageInfo info,
            int percentage, float innerCornerRadius, SKColor startColor, SKColor endColor)
        {
            SKRoundRect progressBar;
            SKPoint startPoint;
            SKPoint endPoint;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        progressBar = CreateRoundRect(percentage, info.Height, innerCornerRadius);
                        startPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Top);
                        endPoint = new SKPoint(progressBar.Rect.Right, progressBar.Rect.Top);

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        progressBar = new SKRoundRect(new SKRect(0, info.Height - percentage, info.Width, info.Height),
                            innerCornerRadius, innerCornerRadius);
                        startPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Top);
                        endPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Bottom);

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
            }

            using var paint = new SKPaint
            {
                IsAntialias = true,
                Shader = SKShader.CreateLinearGradient(startPoint, endPoint,
                    new[] { startColor, endColor }, new float[] { 0, 1 }, SKShaderTileMode.Clamp)
            };

            canvas.DrawRoundRect(progressBar, paint);
        }

        internal static void DrawText(SKCanvas canvas, ProgressBarOrientation orientation, SKImageInfo info,
            int percentage, float textSize, float percentageValue, string format, SKColor primaryColor,
            SKColor secondaryColor)
        {
            var str = string.Format(format, percentageValue);

            var textPaint = new SKPaint
            {
                TextSize = textSize,
                IsAntialias = true,
                Color = percentageValue < 0.5f ? secondaryColor : primaryColor
            };

            var textBounds = new SKRect();

            textPaint.MeasureText(str, ref textBounds);

            float xText, yText;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        xText = percentageValue < 0.5f
                            ? (info.Width + percentage) / 2f - textBounds.MidX
                            : percentage / 2f - textBounds.MidX;

                        yText = info.Height / 2f - textBounds.MidY;

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        xText = info.Width / 2f - textBounds.MidX;

                        yText = percentageValue < 0.5f
                            ? (info.Height - percentage) / 2f - textBounds.MidY
                            : info.Height - (percentage / 2f + textBounds.MidY);

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
            }

            canvas.DrawText(str, xText, yText, textPaint);
        }

        private static SKPath CreateClipPath(SKImageInfo info, float cornerRadius)
        {
            var clip = new SKPath();

            clip.AddRoundRect(new SKRoundRect(new SKRect(0, 0, info.Width, info.Height), cornerRadius, cornerRadius));

            clip.Close();

            return clip;
        }

        private static SKRoundRect CreateRoundRect(int right, int bottom, float cornerRadius) =>
            new SKRoundRect(new SKRect(0, 0, right, bottom), cornerRadius, cornerRadius);
        #endregion
    }
}