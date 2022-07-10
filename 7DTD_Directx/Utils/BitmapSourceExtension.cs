using _7DTD_Directx.Domain;
using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _7DTD_Directx.Utils
{
    public static class BitmapSourceExtension
    {
        public static BitmapSource BitmapSourceFromByteArray(byte[] buffer)
        {
            using(var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }


        public static BitmapSource GetBitmapSourceFromFile(string path)
        {
            try
            {
                var bitmap = new BitmapImage(new Uri(path));
                return bitmap;
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not load the '{path}'", ex);
            }
        }


        public static byte[] ToByteArray(this BitmapSource bitmapSource)
        {
            byte[] data;
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            using(MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }


        public static void SaveToFile(this BitmapSource bitmapSource, string path)
        {
            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(fileStream);
            }
        }


        public static BitmapSource ReplaceColor(this BitmapSource source, MaskColor oldColor, MaskColor newColor)
        {
            var bytesPerPixel = (source.Format.BitsPerPixel + 7) / 8;
            var stride = bytesPerPixel * source.PixelWidth;
            var buffer = new byte[stride * source.PixelHeight];

            source.CopyPixels(buffer, stride, 0);

            for(var y = 0; y < source.PixelHeight; y++)
            {
                for(int x = 0; x < source.PixelWidth; x++)
                {
                    var i = stride * y + bytesPerPixel * x;
                    var b = buffer[i];
                    var g = buffer[i + 1];
                    var r = buffer[i + 2];
                    var a = buffer[i + 3];

                    if((oldColor.A == null || oldColor.A == a)
                        && (oldColor.R == null || oldColor.R == r)
                        && (oldColor.G == null || oldColor.G == g)
                        && (oldColor.B == null || oldColor.B == b))
                    {
                        buffer[i] = newColor.B ?? b;
                        buffer[i + 1] = newColor.G ?? g;
                        buffer[i + 2] = newColor.R ?? r;
                        buffer[i + 3] = newColor.A ?? a;
                    }
                }
            }

            return BitmapSource.Create(
                source.PixelWidth, source.PixelHeight,
                source.DpiX, source.DpiY,
                PixelFormats.Bgra32, null, buffer, stride);
        }
    }
}
