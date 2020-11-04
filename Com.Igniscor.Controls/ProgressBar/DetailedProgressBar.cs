using Com.Igniscor.Controls.Helpers;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Globalization;
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
            get => (ProgressBarOrientation)GetValue(OrientationProperty);
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
            get => (float)GetValue(PercentageValueProperty);
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
            (bindable, value) => value != null && (float)value >= 0,
            OnPropertyChangedInvalidate);

        public float OuterCornerRadius
        {
            get => (float)GetValue(OuterCornerRadiusProperty);
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
            (bindable, value) => value != null && (float)value >= 0,
            OnPropertyChangedInvalidate);

        public float InnerCornerRadius
        {
            get => (float)GetValue(InnerCornerRadiusProperty);
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
            get => (Color)GetValue(StartProgressColorProperty);
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
            get => (Color)GetValue(EndProgressColorProperty);
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
            get => (Color)GetValue(StartBackgroundColorProperty);
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
            get => (Color)GetValue(EndBackgroundColorProperty);
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

        #region BorderWidth Property

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            nameof(BorderWidth),
            typeof(float),
            typeof(DetailedProgressBar),
            0f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float)value >= 0,
            OnPropertyChangedInvalidate);

        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        #endregion BorderWidth Property

        #region BorderColor Property

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor),
            typeof(SKColor),
            typeof(DetailedProgressBar));

        public SKColor BorderColor
        {
            get
            {
                return (SKColor)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        #endregion BorderColor Property

        #region ProgressTextPosition Property

        public static readonly BindableProperty ProgressTextPositionProperty = BindableProperty.Create(
          nameof(ProgressTextPosition),
          typeof(ProgressBarTextPosition),
          typeof(DetailedProgressBar),
          ProgressBarTextPosition.Attached,
          BindingMode.OneWay,
          (bindable, value) => value != null,
          OnPropertyChangedInvalidate);

        public ProgressBarTextPosition ProgressTextPosition
        {
            get => (ProgressBarTextPosition)GetValue(ProgressTextPositionProperty);
            set => SetValue(ProgressTextPositionProperty, value);
        }

        #endregion ProgressTextPosition Property

        #region ProgressTextOrientationProperty Property

        public static readonly BindableProperty ProgressTextOrientationProperty = BindableProperty.Create(
          nameof(ProgressTextOrientation),
          typeof(ProgressBarTextOrientation),
          typeof(DetailedProgressBar),
          ProgressBarTextOrientation.Start,
          BindingMode.OneWay,
          (bindable, value) => value != null,
          OnPropertyChangedInvalidate);

        public ProgressBarTextOrientation ProgressTextOrientation
        {
            get => (ProgressBarTextOrientation)GetValue(ProgressTextOrientationProperty);
            set => SetValue(ProgressTextOrientationProperty, value);
        }

        #endregion ProgressTextOrientationProperty Property

        #region FontName Property

        public static readonly BindableProperty FontNameProperty = BindableProperty.Create(
          nameof(FontName),
          typeof(string),
          typeof(DetailedProgressBar),
          string.Empty,
          BindingMode.OneWay,
          (bindable, value) => value != null,
          OnPropertyChangedInvalidate);

        public string FontName
        {
            get => (string)GetValue(FontNameProperty);
            set => SetValue(FontNameProperty, value);
        }

        #endregion FontName Property

        #endregion Bindable Properties

        private const int horizontaIndent = 5;
        private const float verticalMultiplier = 1.1f;

        protected static void OnPropertyChangedInvalidate(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != newValue)
            {
                ((SKCanvasView)bindable)?.InvalidateSurface();
            }
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear();

            float scale;
            int percentageWidth;
            float textSize;
            float textWidth;

            switch (Orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        scale = CanvasSize.Width / (float)Width;
                        textSize = FontSize * scale;
                        textWidth = GetTextWidth(StringFormat, textSize);
                        if (textSize > info.Height)
                        {
                            textSize = info.Height;
                            textWidth = GetTextWidth(StringFormat, textSize);
                        }
                        if (info.Height - BorderWidth > textSize)
                        {
                            //resize percentage column based on border size
                            percentageWidth = (int)Math.Floor(info.Width * PercentageValue * (info.Width - BorderWidth) / info.Width) + (int)BorderWidth / 2;
                        }
                        else
                        {
                            //resize percentage column based on text size
                            percentageWidth = (int)((int)Math.Floor(info.Width * PercentageValue * (info.Width - (info.Height - textSize)) / info.Width) + (info.Height - textSize) / 2);
                        }
                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        scale = CanvasSize.Height / (float)Height;
                        textSize = FontSize * scale;
                        textWidth = GetTextWidth(StringFormat, textSize);
                        if (textWidth > info.Width)
                        {
                            textWidth = info.Width;
                            textSize = GetMaxVerticalTextSize(StringFormat, textWidth, (int)textSize);
                        }
                        if (info.Width - BorderWidth > textWidth)
                        {
                            //resize percentage column based on border size
                            percentageWidth = (int)Math.Floor(info.Height * PercentageValue * (info.Height - BorderWidth) / info.Height) + (int)BorderWidth / 2;
                        }
                        else
                        {
                            //resize percentage column based on text size
                            percentageWidth = (int)((int)Math.Floor(info.Height * PercentageValue * (info.Height - (info.Width - textWidth)) / info.Height) + (info.Width - textWidth) / 2);
                        }
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var outerCornerRadius = OuterCornerRadius * scale;
            var innerCornerRadius = InnerCornerRadius * scale;

            canvas.Save();
            SKPath clipPath = new SKPath();

            DrawBackground(canvas, clipPath, Orientation, ProgressTextOrientation, textSize, textWidth, e.Info, outerCornerRadius,
                StartBackgroundColor.ToSKColor(), EndBackgroundColor.ToSKColor());
            SetClip(canvas, clipPath);

            DrawProgress(canvas, Orientation, ProgressTextOrientation, textSize, textWidth, e.Info, percentageWidth,
                innerCornerRadius, BorderWidth, StartProgressColor.ToSKColor(), EndProgressColor.ToSKColor());

            DrawBorder(canvas, info, Orientation, ProgressTextOrientation, outerCornerRadius,
                BorderWidth, textSize, textWidth, BorderColor);

            canvas.Restore();
            DrawTextWithPosition(canvas, Orientation, ProgressTextPosition, ProgressTextOrientation, FontName, e.Info, percentageWidth, textSize,
                PercentageValue, BorderWidth, StringFormat, PrimaryTextColor.ToSKColor(), SecondaryTextColor.ToSKColor());
        }

        #region Drawing
        internal static void SetClip(SKCanvas canvas, SKPath clipPath)
        {
            canvas.ClipPath(clipPath, SKClipOperation.Intersect, true);
        }

        internal static void DrawBackground(SKCanvas canvas, SKPath clipPath, ProgressBarOrientation orientation, ProgressBarTextOrientation textPositionVertical, float textSize, float textWidth, SKImageInfo info,
           float outerCornerRadius, SKColor startColor, SKColor endColor)
        {
            SKRoundRect backgroundBar;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        backgroundBar = textPositionVertical switch
                        {
                            ProgressBarTextOrientation.Start => CreateRoundRect(0, (int)(textSize + horizontaIndent), info.Width, info.Height, outerCornerRadius),
                            ProgressBarTextOrientation.Center => CreateRoundRect(info.Width, info.Height, outerCornerRadius),
                            ProgressBarTextOrientation.End => CreateRoundRect(info.Width, (int)(info.Height - textSize - horizontaIndent), outerCornerRadius),
                            _ => throw new ArgumentOutOfRangeException(nameof(textPositionVertical), textPositionVertical, null)
                        };

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        backgroundBar = textPositionVertical switch
                        {
                            ProgressBarTextOrientation.Start => CreateRoundRect((int)(textWidth * verticalMultiplier), 0, info.Width, info.Height, outerCornerRadius),
                            ProgressBarTextOrientation.Center => CreateRoundRect(info.Width, info.Height, outerCornerRadius),
                            ProgressBarTextOrientation.End => CreateRoundRect(info.Width - (int)(textWidth * verticalMultiplier), info.Height, outerCornerRadius),
                            _ => throw new ArgumentOutOfRangeException(nameof(textPositionVertical), textPositionVertical, null)
                        };

                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
            }


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

            clipPath.AddRoundRect(backgroundBar);
            canvas.DrawRoundRect(backgroundBar, paint);
        }

        internal static void DrawProgress(SKCanvas canvas, ProgressBarOrientation orientation, ProgressBarTextOrientation textPositionVertical,
            float textSize, float textWidth, SKImageInfo info, int percentage, float innerCornerRadius, float borderWidth, SKColor startColor, SKColor endColor)
        {
            SKRoundRect progressBar;
            SKPoint startPoint;
            SKPoint endPoint;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        switch (textPositionVertical)
                        {
                            case ProgressBarTextOrientation.Start:
                                {
                                    var indent = (info.Height - textSize) / 2;
                                    if (info.Height - borderWidth > textSize)
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)borderWidth / 2, 0 + (int)borderWidth / 2 + (int)(textSize + horizontaIndent), percentage, info.Height - (int)borderWidth / 2, innerCornerRadius);
                                    }
                                    else
                                    {
                                        if ((int)indent + (int)(textSize + horizontaIndent) < info.Height - (int)indent)
                                        {
                                            //Draw progress bar when text size is the constraint
                                            progressBar = CreateRoundRect(0 + (int)indent, 0 + (int)indent + (int)(textSize + horizontaIndent), percentage, info.Height - (int)indent, innerCornerRadius);
                                        }
                                        else
                                        {
                                            progressBar = CreateRoundRect(0 + (int)indent, 0 + (int)indent + (int)textSize, percentage, 0 + (int)indent + (int)textSize, innerCornerRadius);
                                        }
                                    }

                                    break;
                                }
                            case ProgressBarTextOrientation.Center:
                                {
                                    var indent = (info.Height - textSize) / 2;
                                    if (info.Height - borderWidth > textSize)
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)borderWidth / 2, 0 + (int)borderWidth / 2, percentage, info.Height - (int)borderWidth / 2, innerCornerRadius);
                                    }
                                    else
                                    {
                                        //Draw progress bar when text size is the constraint
                                        progressBar = CreateRoundRect(0 + (int)indent, 0 + (int)indent, percentage, info.Height - (int)indent, innerCornerRadius);
                                    }

                                    break;
                                }
                            case ProgressBarTextOrientation.End:
                                {
                                    var indent = (info.Height - textSize) / 2;
                                    if (info.Height - borderWidth > textSize)
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)borderWidth / 2, 0 + (int)borderWidth / 2, percentage, info.Height - (int)borderWidth / 2 - (int)textSize - horizontaIndent, innerCornerRadius);
                                    }
                                    else
                                    {
                                        if ((int)indent < info.Height - (int)indent - (int)textSize - horizontaIndent)
                                        {
                                            //Draw progress bar when text size is the constraint
                                            progressBar = CreateRoundRect(0 + (int)indent, 0 + (int)indent, percentage, info.Height - (int)indent - (int)textSize - horizontaIndent, innerCornerRadius);
                                        }
                                        else
                                        {
                                            progressBar = CreateRoundRect(0 + (int)indent, 0 + (int)indent, percentage, 0 + (int)indent, innerCornerRadius);
                                        }
                                    }

                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException(nameof(textPositionVertical), textPositionVertical, null);
                        }

                        startPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Top);
                        endPoint = new SKPoint(progressBar.Rect.Right, progressBar.Rect.Top);

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        switch (textPositionVertical)
                        {
                            case ProgressBarTextOrientation.Start:
                                {
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth * verticalMultiplier)
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)borderWidth / 2 + (int)(textWidth * verticalMultiplier), info.Height - percentage, info.Width - (int)borderWidth / 2, info.Height - (int)borderWidth / 2, innerCornerRadius);
                                    }
                                    else
                                    {
                                        if ((int)indent + (int)textWidth * verticalMultiplier < info.Width - (int)indent)
                                        {
                                            //Draw progress bar when text size is the constraint
                                            progressBar = CreateRoundRect(0 + (int)indent + (int)(textWidth * verticalMultiplier), info.Height - percentage, info.Width - (int)indent, info.Height + (int)indent, innerCornerRadius);
                                        }
                                        else
                                        {
                                            progressBar = CreateRoundRect(0 + (int)indent + (int)(textWidth * verticalMultiplier), info.Height - percentage, 0 + (int)indent + (int)(textWidth * verticalMultiplier), info.Height + (int)indent, innerCornerRadius);
                                        }
                                    }
                                    break;
                                }
                            case ProgressBarTextOrientation.Center:
                                {
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth)
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)borderWidth / 2, info.Height - percentage, info.Width - (int)borderWidth / 2, info.Height - (int)borderWidth / 2, innerCornerRadius);
                                    }
                                    else
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)indent, info.Height - percentage, info.Width - (int)indent, info.Height - (int)indent, innerCornerRadius);
                                    }
                                    break;
                                }
                            case ProgressBarTextOrientation.End:
                                {
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth * verticalMultiplier)
                                    {
                                        //Draw progress bar when border width is the constraint
                                        progressBar = CreateRoundRect(0 + (int)borderWidth / 2, info.Height - percentage, info.Width - (int)borderWidth / 2 - (int)(textWidth * verticalMultiplier), info.Height - (int)borderWidth / 2, innerCornerRadius);
                                    }
                                    else
                                    {
                                        if ((int)indent < info.Width - (int)indent - (int)textWidth * verticalMultiplier)
                                        {
                                            //Draw progress bar when text size is the constraint
                                            progressBar = CreateRoundRect(0 + (int)indent, info.Height - percentage, info.Width - (int)indent - (int)(textWidth * verticalMultiplier), info.Height - (int)indent, innerCornerRadius);
                                        }
                                        else
                                        {
                                            progressBar = CreateRoundRect(0 + (int)indent + (int)(textWidth * verticalMultiplier), info.Height - percentage, 0 + (int)indent + (int)(textWidth * verticalMultiplier), info.Height - (int)indent, innerCornerRadius);
                                        }
                                    }
                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException(nameof(textPositionVertical), textPositionVertical, null);
                        }
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

        internal void DrawBorder(SKCanvas canvas, SKImageInfo info, ProgressBarOrientation orientation, ProgressBarTextOrientation progressTextPositionVertical,
            float outerCornerRadius, float borderWidth, float textSize, float textWidth, SKColor borderColor)
        {
            SKRoundRect backgroundBorder;
            if (borderWidth > 0)
            {
                switch (orientation)
                {
                    case ProgressBarOrientation.Horizontal:
                        {
                            var indent = info.Height - textSize;
                            switch (progressTextPositionVertical)
                            {
                                case ProgressBarTextOrientation.Start:
                                    backgroundBorder = CreateRoundRect(0, (int)textSize + horizontaIndent, info.Width, info.Height, outerCornerRadius);
                                    DrawBorderWithOrientation(canvas, borderWidth, borderColor, indent, backgroundBorder);
                                    break;
                                case ProgressBarTextOrientation.Center:
                                    backgroundBorder = CreateRoundRect(0, 0, info.Width, info.Height, outerCornerRadius);
                                    DrawBorderWithOrientation(canvas, borderWidth, borderColor, indent, backgroundBorder);
                                    break;
                                case ProgressBarTextOrientation.End:
                                    backgroundBorder = CreateRoundRect(0, 0, info.Width, info.Height - (int)textSize - horizontaIndent, outerCornerRadius);
                                    DrawBorderWithOrientation(canvas, borderWidth, borderColor, indent, backgroundBorder);
                                    break;
                            }
                            break;
                        }
                    case ProgressBarOrientation.Vertical:
                        {
                            var indent = info.Width - textWidth;
                            switch (progressTextPositionVertical)
                            {
                                case ProgressBarTextOrientation.Start:
                                    backgroundBorder = CreateRoundRect((int)(textWidth * verticalMultiplier), 0, info.Width, info.Height, outerCornerRadius);
                                    DrawBorderWithOrientation(canvas, borderWidth, borderColor, indent, backgroundBorder);
                                    break;
                                case ProgressBarTextOrientation.Center:
                                    backgroundBorder = CreateRoundRect(0, 0, info.Width, info.Height, outerCornerRadius);
                                    DrawBorderWithOrientation(canvas, borderWidth, borderColor, indent, backgroundBorder);
                                    break;
                                case ProgressBarTextOrientation.End:
                                    backgroundBorder = CreateRoundRect(0, 0, info.Width - (int)(textWidth * verticalMultiplier), info.Height, outerCornerRadius);
                                    DrawBorderWithOrientation(canvas, borderWidth, borderColor, indent, backgroundBorder);
                                    break;
                            }
                            break;
                        }
                }
            }
        }

        internal static void DrawTextWithPosition(SKCanvas canvas, ProgressBarOrientation orientation, ProgressBarTextPosition textPosition, ProgressBarTextOrientation textOrientation, string fontName, SKImageInfo info,
            int percentage, float textSize, float percentageValue, float borderWidth, string format, SKColor primaryColor,
            SKColor secondaryColor)
        {
            var str = string.Format(format, percentageValue);

            var font = FontsHelper.GetTypeface(fontName);

            var textPaint = new SKPaint
            {
                Typeface = font,
                TextSize = textSize,
                IsAntialias = true,
                Color = primaryColor
            };

            var textBounds = new SKRect();

            textPaint.MeasureText(str, ref textBounds);
            var textWidth = GetTextWidth(format, textSize);

            float xText, yText;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        switch (textPosition)
                        {
                            case ProgressBarTextPosition.Start:
                                {
                                    var indent = (info.Height - textSize) / 2;
                                    if (info.Height - borderWidth > textSize)
                                    {
                                        xText = textSize * 1.5f - textBounds.MidX + borderWidth / 2;

                                        yText = info.Height / 2f - textBounds.MidY;
                                    }
                                    else
                                    {
                                        xText = textSize * 1.5f - textBounds.MidX + indent;

                                        yText = info.Height / 2f - textBounds.MidY;
                                    }

                                    textPaint.Color = percentage < textBounds.Width * 1.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.Center:
                                {
                                    xText = info.Width / 2f - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;

                                    textPaint.Color = percentageValue < 0.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.End:
                                {
                                    var indent = (info.Height - textSize) / 2;
                                    if (info.Height - borderWidth > textSize)
                                    {
                                        xText = info.Width - textSize * 1.5f - textBounds.MidX - borderWidth / 2;

                                        yText = info.Height / 2f - textBounds.MidY;
                                    }
                                    else
                                    {
                                        xText = info.Width - textSize * 1.5f - textBounds.MidX - indent;

                                        yText = info.Height / 2f - textBounds.MidY;
                                    }

                                    textPaint.Color = percentage < info.Width - textSize * 1.5f - textBounds.MidX ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.Relative:
                                {
                                    var indent = (info.Height - textSize) / 2;
                                    if (info.Height - borderWidth > textSize)
                                    {
                                        xText = percentageValue < 0.5f
                                        ? (info.Width + percentage - borderWidth / 2) / 2f - textBounds.MidX
                                        : (percentage + borderWidth / 2) / 2f - textBounds.MidX;

                                        yText = info.Height / 2f - textBounds.MidY;
                                    }
                                    else
                                    {
                                        xText = percentageValue < 0.5f
                                        ? (info.Width + percentage - indent) / 2f - textBounds.MidX
                                        : (percentage + indent) / 2f - textBounds.MidX;

                                        yText = info.Height / 2f - textBounds.MidY;
                                    }

                                    textPaint.Color = percentageValue < 0.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.Attached:
                                {
                                    xText = percentage < textBounds.Width * 1.5f ?
                                        textSize * 1.5f - textBounds.MidX :
                                        percentage - textSize * 1.5f - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;

                                    textPaint.Color = percentage < textBounds.Width * 1.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException(nameof(textPosition), textPosition, null);
                        }

                        yText = textOrientation switch
                        {
                            ProgressBarTextOrientation.Start => textBounds.Height,
                            ProgressBarTextOrientation.Center => info.Height / 2f - textBounds.MidY,
                            ProgressBarTextOrientation.End => info.Height + textBounds.MidY,
                            _ => throw new ArgumentOutOfRangeException(nameof(textOrientation), textOrientation, null)
                        };

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        switch (textPosition)
                        {
                            case ProgressBarTextPosition.Start:
                                {
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth)
                                    {
                                        xText = info.Width / 2f - textBounds.MidX;

                                        yText = info.Height - textSize - textBounds.MidY - borderWidth / 2;
                                    }
                                    else
                                    {
                                        xText = info.Width / 2f - textBounds.MidX;

                                        yText = info.Height - textSize - textBounds.MidY - indent;
                                    }
                                    break;
                                }
                            case ProgressBarTextPosition.Center:
                                {
                                    xText = info.Width / 2f - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;
                                    break;
                                }
                            case ProgressBarTextPosition.End:
                                {
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth)
                                    {
                                        xText = info.Width / 2f - textBounds.MidX;

                                        yText = textSize - textBounds.MidY + borderWidth / 2;
                                    }
                                    else
                                    {
                                        xText = info.Width / 2f - textBounds.MidX;

                                        yText = textSize - textBounds.MidY + indent;
                                    }
                                    break;
                                }
                            case ProgressBarTextPosition.Relative:
                                {
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth)
                                    {
                                        xText = info.Width / 2f - textBounds.MidX;

                                        yText = percentageValue < 0.5f
                                        ? info.Height - ((info.Height + percentage - borderWidth / 2) / 2f + textBounds.MidY)
                                        : info.Height - ((percentage + borderWidth / 2) / 2f);
                                    }
                                    else
                                    {
                                        xText = info.Width / 2f - textBounds.MidX;

                                        yText = percentageValue < 0.5f
                                        ? info.Height - ((info.Height + percentage - indent) / 2f + textBounds.MidY)
                                        : info.Height - ((percentage + indent) / 2f);
                                    }

                                    textPaint.Color = percentageValue < 0.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.Attached:
                                {
                                    xText = info.Width / 2f - textBounds.MidX;
                                    var indent = (info.Width - textWidth) / 2;
                                    if (info.Width - borderWidth > textWidth)
                                    {
                                        yText = percentage < textSize * 1.5f + borderWidth / 2 ?
                                        info.Height - textSize / 1.5f - borderWidth / 2 :
                                        info.Height - percentage + textSize / 1.5f;
                                        textPaint.Color = percentage < textBounds.Height * 1.5f ? secondaryColor : primaryColor;
                                    }
                                    else
                                    {
                                        yText = percentage < textSize * 1.5f + indent ?
                                        info.Height - textSize / 1.5f - indent :
                                        info.Height - percentage + textSize / 1.5f;
                                        textPaint.Color = percentage < textBounds.Height * 1.5f ? secondaryColor : primaryColor;
                                    }
                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException(nameof(textPosition), textPosition, null);
                        }

                        xText = textOrientation switch
                        {
                            ProgressBarTextOrientation.Start => 0,
                            ProgressBarTextOrientation.Center => info.Width / 2f - textBounds.MidX,
                            ProgressBarTextOrientation.End => info.Width - textWidth * verticalMultiplier,
                            _ => throw new ArgumentOutOfRangeException(nameof(textOrientation), textOrientation, null)
                        };

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
        private static SKRoundRect CreateRoundRect(int left, int top, int right, int bottom, float cornerRadius) =>
           new SKRoundRect(new SKRect(left, top, right, bottom), cornerRadius, cornerRadius);

        private static float GetTextWidth(string format, float textSize)
        {
            var str = string.Format(format, 1);
            var textPaint = new SKPaint
            {
                TextSize = textSize
            };

            return textPaint.MeasureText(str);
        }

        private float GetMaxVerticalTextSize(string format, float textWidth, int currentTextSize)
        {
            float newTextSize = 0;
            var str = string.Format(format, 1);
            SKRect rect = new SKRect();
            var paint = new SKPaint()
            {
                Typeface = FontsHelper.GetTypeface(FontName),
                TextSize = currentTextSize
            };
            paint.MeasureText(str, ref rect);
            for(int i = 0; GetTextWidth(format, currentTextSize - i) >= textWidth; i++)
            {
                newTextSize = currentTextSize - i;
            }
            return newTextSize;
        }

        private static void DrawBorderWithOrientation(SKCanvas canvas, float borderWidth, SKColor borderColor, float indent, SKRoundRect backgroundBorder)
        {
            SKPaint borderPaint;
            if (borderWidth > indent)
            {
                borderPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = borderColor,
                    StrokeWidth = indent
                };
            }
            else
            {
                borderPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = borderColor,
                    StrokeWidth = borderWidth
                };
            }

            canvas.DrawRoundRect(backgroundBorder, borderPaint);
        }
        #endregion

        //Use these methods if your text is located only inside the progress bar.
        //internal static void DrawBackground(SKCanvas canvas, ProgressBarOrientation orientation, SKImageInfo info,
        //    float outerCornerRadius, SKColor startColor, SKColor endColor)
        //{
        //    var backgroundBar = CreateRoundRect(0, 0, info.Width, info.Height, outerCornerRadius);

        //    SKPoint startPoint;
        //    SKPoint endPoint;

        //    switch (orientation)
        //    {
        //        case ProgressBarOrientation.Horizontal:
        //            {
        //                startPoint = new SKPoint(backgroundBar.Rect.Left, backgroundBar.Rect.Top);
        //                endPoint = new SKPoint(backgroundBar.Rect.Right, backgroundBar.Rect.Top);

        //                break;
        //            }
        //        case ProgressBarOrientation.Vertical:
        //            {
        //                startPoint = new SKPoint(backgroundBar.Rect.Left, backgroundBar.Rect.Top);
        //                endPoint = new SKPoint(backgroundBar.Rect.Left, backgroundBar.Rect.Bottom);

        //                break;
        //            }
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
        //    }

        //    using var paint = new SKPaint
        //    {
        //        IsAntialias = true,
        //        Shader = SKShader.CreateLinearGradient(startPoint, endPoint, new[] { startColor, endColor },
        //            new float[] { 0, 1 }, SKShaderTileMode.Clamp)
        //    };

        //    canvas.DrawRoundRect(backgroundBar, paint);
        //}

        //internal static void DrawProgress(SKCanvas canvas, ProgressBarOrientation orientation, SKImageInfo info,
        //    int percentage, float innerCornerRadius, float borderWidth, float minProgressSize, float textWidth, SKColor startColor, SKColor endColor)
        //{
        //    SKRoundRect progressBar;
        //    SKPoint startPoint;
        //    SKPoint endPoint;

        //    switch (orientation)
        //    {
        //        case ProgressBarOrientation.Horizontal:
        //            {
        //                var indent = (info.Height - minProgressSize) / 2;
        //                if (info.Height - borderWidth > minProgressSize)
        //                {
        //                    //Draw progress bar when border width is the constraint
        //                    progressBar = CreateRoundRect(0 + (int)borderWidth / 2, 0 + (int)borderWidth / 2, percentage, info.Height - (int)borderWidth / 2, innerCornerRadius);
        //                }
        //                else
        //                {
        //                    //Draw progress bar when text size is the constraint
        //                    progressBar = CreateRoundRect(0 + (int)indent, 0 + (int)indent, percentage, info.Height - (int)indent, innerCornerRadius);
        //                }
        //                startPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Top);
        //                endPoint = new SKPoint(progressBar.Rect.Right, progressBar.Rect.Top);
        //                break;
        //            }
        //        case ProgressBarOrientation.Vertical:
        //            {
        //                var indent = (info.Width - textWidth) / 2;
        //                if (info.Width - borderWidth > textWidth)
        //                {
        //                    //Draw progress bar when border width is the constraint
        //                    progressBar = CreateRoundRect(0 + (int)borderWidth / 2, info.Height - percentage, info.Width - (int)borderWidth / 2, info.Height - (int)borderWidth / 2, innerCornerRadius);
        //                }
        //                else
        //                {
        //                    //Draw progress bar when border width is the constraint
        //                    progressBar = CreateRoundRect(0 + (int)indent, info.Height - percentage, info.Width - (int)indent, info.Height - (int)indent, innerCornerRadius);
        //                }
        //                startPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Top);
        //                endPoint = new SKPoint(progressBar.Rect.Left, progressBar.Rect.Bottom);

        //                break;
        //            }
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
        //    }

        //    using var paint = new SKPaint
        //    {
        //        IsAntialias = true,
        //        Shader = SKShader.CreateLinearGradient(startPoint, endPoint,
        //            new[] { startColor, endColor }, new float[] { 0, 1 }, SKShaderTileMode.Clamp)
        //    };

        //    canvas.DrawRoundRect(progressBar, paint);
        //}

        //internal static void DrawText(SKCanvas canvas, ProgressBarOrientation orientation, SKImageInfo info,
        //    int percentage, float textSize, float percentageValue, float borderWidth, string format, SKColor primaryColor,
        //    SKColor secondaryColor)
        //{
        //    var str = string.Format(format, percentageValue);

        //    var textPaint = new SKPaint
        //    {
        //        TextSize = textSize,
        //        IsAntialias = true,
        //        Color = percentageValue < 0.5f ? secondaryColor : primaryColor
        //    };

        //    var textBounds = new SKRect();

        //    textPaint.MeasureText(str, ref textBounds);
        //    var textWidth = GetTextWidth(format, textSize);

        //    float xText, yText;

        //    switch (orientation)
        //    {
        //        case ProgressBarOrientation.Horizontal:
        //            {
        //                var indent = (info.Height - textSize) / 2;
        //                if (info.Height - borderWidth > textSize)
        //                {
        //                    xText = percentageValue < 0.5f
        //                    ? (info.Width + percentage - borderWidth / 2) / 2f - textBounds.MidX
        //                    : (percentage + borderWidth / 2) / 2f - textBounds.MidX;

        //                    yText = info.Height / 2f - textBounds.MidY;
        //                }
        //                else
        //                {
        //                    xText = percentageValue < 0.5f
        //                    ? (info.Width + percentage - indent) / 2f - textBounds.MidX
        //                    : (percentage + indent) / 2f - textBounds.MidX;

        //                    yText = info.Height / 2f - textBounds.MidY;
        //                }

        //                break;
        //            }
        //        case ProgressBarOrientation.Vertical:
        //            {
        //                var indent = (info.Width - textWidth) / 2;
        //                if (info.Width - borderWidth > textWidth)
        //                {
        //                    xText = info.Width / 2f - textBounds.MidX;

        //                    yText = percentageValue < 0.5f
        //                        ? (info.Height - percentage + borderWidth / 2) / 2f - textBounds.MidY
        //                        : info.Height - ((percentage + borderWidth / 2) / 2f + textBounds.MidY);
        //                }
        //                else
        //                {
        //                    xText = info.Width / 2f - textBounds.MidX;

        //                    yText = percentageValue < 0.5f
        //                        ? (info.Height - percentage + indent) / 2f - textBounds.MidY
        //                        : info.Height - ((percentage + indent) / 2f + textBounds.MidY);
        //                }

        //                break;
        //            }
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
        //    }

        //    canvas.DrawText(str, xText, yText, textPaint);
        //}
    }
}