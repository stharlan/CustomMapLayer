using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace skiatest
{
    class Program
    {
        static void Main(string[] args)
        {
            SKImageInfo info = new SKImageInfo(640, 480, SKColorType.Bgra8888, SKAlphaType.Premul);
            using (SKBitmap bmp = new SKBitmap(info))
            {
                using (SKCanvas canvas = new SKCanvas(bmp))
                {
                    canvas.Clear(SKColors.Transparent);
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.IsAntialias = true;
                        paint.Color = SKColors.Red;
                        canvas.DrawCircle(100, 100, 100, paint);
                    }
                }
                using (SKImage img = SKImage.FromBitmap(bmp))
                using (SKData data = img.Encode(SKEncodedImageFormat.Png, 100))
                using (System.IO.FileStream fout = System.IO.File.OpenWrite("test.png"))
                {
                    data.SaveTo(fout);
                }
            }
            using (SKBitmap bmp = new SKBitmap(info))
            {
                using (SKCanvas canvas = new SKCanvas(bmp))
                {
                    canvas.Clear(SKColors.Transparent);
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.IsAntialias = true;
                        paint.Color = SKColors.Blue;
                        canvas.DrawRect(50, 50, 200, 200, paint);
                    }
                }
                using (SKImage img = SKImage.FromBitmap(bmp))
                using (SKData data = img.Encode(SKEncodedImageFormat.Png, 100))
                using (System.IO.FileStream fout = System.IO.File.OpenWrite("test1.png"))
                {
                    data.SaveTo(fout);
                }
            }
        }
    }
}
