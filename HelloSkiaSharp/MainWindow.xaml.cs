using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloSkiaSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool drawing;

        private bool dragging;
        private SKPoint dragStartPoint;

        private SKPaint pathStrokePaint;
        private SKPath path;

        public MainWindow()
        {
            InitializeComponent();

            drawing = true;
            dragging = false;

            pathStrokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 10,
                IsAntialias = true
            };
        }

        private void skiaCanvasElement_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;
            var size = e.Info.Size;

            canvas.Clear(SKColors.Transparent);

            // Draw text
            var textPaint = new SKPaint
            {
                IsAntialias = true,
                TextSize = 50,
                TextAlign = SKTextAlign.Center,
                Color = 0xFF3498DB,
                Style = SKPaintStyle.Fill,
                Typeface = SKTypeface.FromFamilyName("Trebuchet")
            };

            canvas.DrawText(
                "SkiaSharp",
                size.Width / 2,
                (size.Height + textPaint.TextSize) / 2,
                textPaint);

            // Draw circle
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = new SKColor(0, 150, 0),
                StrokeWidth = 5
            };
            canvas.DrawCircle(e.Info.Width / 2, e.Info.Height / 2, 100, circlePaint);

            /*
            // Create the path
            SKPath path = new SKPath();
            // Define the first contour
            path.MoveTo(0.5f * info.Width, 0.1f * info.Height);
            path.LineTo(0.2f * info.Width, 0.4f * info.Height);
            path.LineTo(0.8f * info.Width, 0.4f * info.Height);
            path.LineTo(0.5f * info.Width, 0.1f * info.Height);
            // Create two SKPaint objects
            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Magenta,
                StrokeWidth = 50
            };
            // Fill and stroke the path
            canvas.DrawPath(path, strokePaint);
            */

            if (path != null)
            {
                canvas.DrawPath(path, pathStrokePaint);
            }
        }

        private void skiaCanvasElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SKPoint skPoint = new SKPoint((float)e.GetPosition(skiaCanvasElement).X, (float)e.GetPosition(skiaCanvasElement).Y);
            if (drawing == true)
            {
                if (path == null)
                    path = new SKPath();

                if (path.PointCount == 0)
                {
                    path.MoveTo(skPoint);
                }
                else
                {
                    path.LineTo(skPoint);
                }
            }
            else
            {
                if (path != null)
                {
                    if (path.Contains(skPoint.X, skPoint.Y))
                    {
                        dragging = true;
                        dragStartPoint = skPoint;
                    }
                }
            }

            skiaCanvasElement.InvalidateVisual();
        }

        private void skiaCanvasElement_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            drawing = false;
            skiaCanvasElement.InvalidateVisual();
        }

        private void skiaCanvasElement_MouseMove(object sender, MouseEventArgs e)
        {
            SKPoint skPoint = new SKPoint((float)e.GetPosition(skiaCanvasElement).X, (float)e.GetPosition(skiaCanvasElement).Y);
            if (dragging == true)
            {
                path.Offset(skPoint.X - dragStartPoint.X, skPoint.Y - dragStartPoint.Y);
                dragStartPoint = skPoint;
            }
            skiaCanvasElement.InvalidateVisual();
        }

        private void skiaCanvasElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dragging)
            {
                dragging = false;
                path.Offset(0, 0);
            }
            skiaCanvasElement.InvalidateVisual();
        }
    }
}
