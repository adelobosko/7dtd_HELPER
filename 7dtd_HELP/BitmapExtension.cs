using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace _7dtd_HELP
{
    public static class BitmapExtension
    {

        public static Bitmap CropAtRect(this Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b, -r.X, -r.Y);
            return nb;
        }

        public static Bitmap ToGrayScale(this Bitmap b)
        {
            var bmp = new Bitmap(b.Width, b.Height);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(b, 0, 0);
            for (var y = 0; y < bmp.Height; y++)
                for (var x = 0; x < bmp.Width; x++)
                {
                    var c = bmp.GetPixel(x, y);
                    var rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }

            return bmp;
        }

        public static Image ToGrayScale(this Image b)
        {
            var bmp = new Bitmap(b.Width, b.Height);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(b, 0, 0);
            for (var y = 0; y < bmp.Height; y++)
            for (var x = 0; x < bmp.Width; x++)
            {
                var c = bmp.GetPixel(x, y);
                var rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
            }

            return bmp;

        }

        public static Image CropAtRect(this Image b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b, -r.X, -r.Y);
            return nb;
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
    }
}