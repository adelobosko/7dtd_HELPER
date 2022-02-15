using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace _7dtd_HELP
{
    public static class BitmapHelper
    {

        public static Bitmap CropAtRect(this Bitmap b, Rectangle r)
        {
            Bitmap newBitmap = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            g.DrawImage(b, -r.X, -r.Y);
            return newBitmap;
        }


        public static Image CropAtRect(this Image b, Rectangle r)
        {
            return CropAtRect((Bitmap)b, r);
        }


        public static Bitmap ToGrayScale(this Bitmap b)
        {
            var newBmp = new Bitmap(b.Width, b.Height);
            var g = Graphics.FromImage(newBmp);
            g.DrawImage(b, 0, 0);

            var lockedBitmap = new LockBitmap(newBmp);
            lockedBitmap.LockBits();

            Parallel.For(0, lockedBitmap.Height, y =>
            {
                for (int x = 0; x < lockedBitmap.Width; x++)
                {
                    var c = lockedBitmap.GetPixel(x, y);
                    var rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    lockedBitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            });

            lockedBitmap.UnlockBits();

            return newBmp;
        }


        public static Image ToGrayScale(this Image b)
        {
            return ToGrayScale((Bitmap)b);
        }


        public static void ReplaceColor(Bitmap bmp, Color oldColor, Color newColor)
        {
            var lockedBitmap = new LockBitmap(bmp);
            lockedBitmap.LockBits();

            Parallel.For(0, lockedBitmap.Height, y =>
            {
                for (int x = 0; x < lockedBitmap.Width; x++)
                {
                    if (lockedBitmap.GetPixel(x, y) == oldColor)
                    {
                        lockedBitmap.SetPixel(x, y, newColor);
                    }
                }
            });

            lockedBitmap.UnlockBits();
        }


        public static void ReplaceAlpha(Bitmap bmp, int newAlpha, int alphaToReplace = -1)
        {
            var lockedBitmap = new LockBitmap(bmp);
            lockedBitmap.LockBits();

            Parallel.For(0, lockedBitmap.Height, y =>
            {
                for (int x = 0; x < lockedBitmap.Width; x++)
                {
                    var pixel = lockedBitmap.GetPixel(x, y);

                    if (alphaToReplace != -1 && pixel.A != alphaToReplace)
                    {
                        continue;
                    }

                    lockedBitmap.SetPixel(x, y, Color.FromArgb(newAlpha, pixel.R, pixel.G, pixel.B));
                }
            });

            lockedBitmap.UnlockBits();
        }


        public static Bitmap ResizeImage(this Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        public static Bitmap ChangeOpacity(this Bitmap img, float opacityValue)
        {
            var bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            var colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacityValue;
            var imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }


        public static byte[] ToBytes(this Bitmap img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        public static Bitmap BytesToBitmap(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return (Bitmap)System.Drawing.Image.FromStream(ms);
            }
        }
    }
}