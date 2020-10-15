using SkiaSharp;
using System;

namespace TrashBox.Controls.GradientProgressBar
{
    internal static class ProgressBarHelper
    {
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
                Shader = SKShader.CreateLinearGradient(startPoint, endPoint, new[] {startColor, endColor},
                    new float[] {0, 1}, SKShaderTileMode.Clamp)
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
                    new[] {startColor, endColor}, new float[] {0, 1}, SKShaderTileMode.Clamp)
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
    }
}