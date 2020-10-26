using Com.Igniscor.Controls.Helpers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Com.Igniscor.Controls.ProgressBar
{
    public partial class DetailedProgressBar
    {
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

        public static readonly BindableProperty ProgressTextPositionVerticalProperty = BindableProperty.Create(
          nameof(ProgressTextPositionVertical),
          typeof(ProgressBarTextPositionVertical),
          typeof(DetailedProgressBar),
          ProgressBarTextPositionVertical.Start,
          BindingMode.OneWay,
          (bindable, value) => value != null,
          OnPropertyChangedInvalidate);

        public ProgressBarTextPositionVertical ProgressTextPositionVertical
        {
            get => (ProgressBarTextPositionVertical)GetValue(ProgressTextPositionVerticalProperty);
            set => SetValue(ProgressTextPositionVerticalProperty, value);
        }

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

        internal static void DrawTextWithPosition(SKCanvas canvas, ProgressBarOrientation orientation,ProgressBarTextPosition textPosition, ProgressBarTextPositionVertical textPositionVertical, string fontName, SKImageInfo info,
            int percentage, float textSize, float percentageValue, string format, SKColor primaryColor,
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

            float xText, yText;

            switch (orientation)
            {
                case ProgressBarOrientation.Horizontal:
                    {
                        switch (textPosition)
                        {
                            case ProgressBarTextPosition.Start:
                                {
                                    xText = textSize*1.5f - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;

                                    textPaint.Color = percentage < textBounds.Width * 1.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.Center:
                                {
                                    xText = info.Width /2f  - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;

                                    textPaint.Color = percentageValue < 0.5f ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.End:
                                {
                                    xText = info.Width - textSize*1.5f - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;

                                    textPaint.Color = percentage < info.Width - textSize * 1.5f - textBounds.MidX ? secondaryColor : primaryColor;
                                    break;
                                }
                            case ProgressBarTextPosition.Relative:
                                {
                                    xText = percentageValue < 0.5f
                                        ? (info.Width + percentage) / 2f - textBounds.MidX
                                        : percentage / 2f - textBounds.MidX;

                                    yText = info.Height / 2f - textBounds.MidY;

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

                        switch (textPositionVertical)
                        {
                            case ProgressBarTextPositionVertical.Start:
                                {
                                    yText = textBounds.Height;

                                    break;
                                }
                            case ProgressBarTextPositionVertical.Center:
                                {
                                    yText = info.Height / 2f - textBounds.MidY;

                                    break;
                                }
                            case ProgressBarTextPositionVertical.End:
                                {
                                    yText = info.Height + textBounds.MidY;

                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException(nameof(textPositionVertical), textPositionVertical, null);
                        }

                        break;
                    }
                case ProgressBarOrientation.Vertical:
                    {
                        switch (textPosition)
                        {
                            case ProgressBarTextPosition.Start:
                                {
                                    xText = info.Width / 2f - textBounds.MidX;

                                    yText = info.Height - textSize - textBounds.MidY;
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
                                    xText = info.Width / 2f - textBounds.MidX;

                                    yText = textSize - textBounds.MidY;
                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException(nameof(textPosition), textPosition, null);
                        }

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
            }

            canvas.DrawText(str, xText, yText, textPaint);
        }

        internal static void DrawBackground(SKCanvas canvas, ProgressBarOrientation orientation, ProgressBarTextPositionVertical textPositionVertical, float textSize, SKImageInfo info,
           float outerCornerRadius, SKColor startColor, SKColor endColor)
        {
            SKRoundRect backgroundBar;

            switch (textPositionVertical)
            {
                case ProgressBarTextPositionVertical.Start:
                    {
                        backgroundBar = CreateRoundRect(0, (int)(textSize + 5), info.Width, (int)(info.Height + textSize + 5), outerCornerRadius);
                        break;
                    }
                case ProgressBarTextPositionVertical.Center:
                    {
                        backgroundBar = CreateRoundRect(info.Width, info.Height, outerCornerRadius);

                        break;
                    }
                case ProgressBarTextPositionVertical.End:
                    {
                        backgroundBar = CreateRoundRect(info.Width, (int)(info.Height - textSize - 5), outerCornerRadius);
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(textPositionVertical), textPositionVertical, null);
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

            canvas.DrawRoundRect(backgroundBar, paint);
        }

        internal static void DrawProgress(SKCanvas canvas, ProgressBarOrientation orientation, ProgressBarTextPositionVertical textPositionVertical, float textSize, SKImageInfo info,
            int percentage, float innerCornerRadius, SKColor startColor, SKColor endColor)
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
                            case ProgressBarTextPositionVertical.Start:
                                {
                                    progressBar = CreateRoundRect(0, (int)(textSize + 5),percentage, (int)(info.Height + textSize + 5), innerCornerRadius);

                                    break;
                                }
                            case ProgressBarTextPositionVertical.Center:
                                {
                                    progressBar = CreateRoundRect(percentage, info.Height, innerCornerRadius);

                                    break;
                                }
                            case ProgressBarTextPositionVertical.End:
                                {
                                    progressBar = CreateRoundRect(percentage, (int)(info.Height - textSize - 5), innerCornerRadius);

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

        private static SKRoundRect CreateRoundRect(int left,int top,int right, int bottom, float cornerRadius) =>
           new SKRoundRect(new SKRect(left, top, right, bottom), cornerRadius, cornerRadius);
    }
}
