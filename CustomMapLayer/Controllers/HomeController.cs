using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkiaSharp;
using System.IO;

namespace CustomMapLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Layer1(int width, int height)
        {
            return new FileGeneratingResult("map.csv", "text/csv",
                stream => this.GenerateExportFile(width, height, stream));
        }

        public void GenerateExportFile(int width, int height, Stream stream)
        {
            SKImageInfo info = new SKImageInfo(width, height, SKColorType.Bgra8888, SKAlphaType.Premul);
            using (SKBitmap bmp = new SKBitmap(info))
            {
                using (SKCanvas canvas = new SKCanvas(bmp))
                {
                    canvas.Clear(SKColors.Transparent);
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.IsAntialias = true;
                        paint.Color = new SKColor(255, 0, 0, 127);
                        canvas.DrawCircle(width / 2, height / 2, 100, paint);
                    }
                }
                using (SKImage img = SKImage.FromBitmap(bmp))
                using (SKData data = img.Encode(SKEncodedImageFormat.Png, 100))
                {
                    data.SaveTo(stream);
                }
            }
        }
    }
}