﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HelloSkiaSharp
{
    class ImageService
    {
        private int Call = 0;
        private Stopwatch Stopwatch = new Stopwatch();

        public void UpdateImage(WriteableBitmap writeableBitmap)
        {
            int width = (int)writeableBitmap.Width,
                height = (int)writeableBitmap.Height;

            writeableBitmap.Lock();

            using (var surface = SKSurface.Create(
              width: width,
              height: height,
              colorType: SKColorType.Bgra8888,
              alphaType: SKAlphaType.Premul,
              pixels: writeableBitmap.BackBuffer,
              rowBytes: width * 4))
            {
                SKCanvas canvas = surface.Canvas;

                int x = 30;
                var paint = new SKPaint() { Color = new SKColor(0, 0, 0), TextSize = 100 };
                canvas.Clear(new SKColor(130, 130, 130));
                canvas.DrawText("SkiaSharp on Wpf!", x, 200, paint);
                if (this.Call == 0)
                    this.Stopwatch.Start();
                double fps = this.Call / ((this.Stopwatch.Elapsed.TotalSeconds != 0) ? this.Stopwatch.Elapsed.TotalSeconds : 1);
                canvas.DrawText($"FPS: {fps:0}", x, 300, paint);
                canvas.DrawText($"Frames: {this.Call++}", x, 400, paint);

                SKPath path = new SKPath();
            }

            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));

            writeableBitmap.Unlock();
        }
    }
}
