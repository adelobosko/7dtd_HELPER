using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("DrawableImages", Schema = "Config")]
    public class DrawableImage
    {
        private int _opacity;

        public Guid DrawableImageID { get; private set; }
        public bool ShouldShow { get; set; }
        public int Opacity
        {
            get => _opacity;
            set
            {
                if(value > 100)
                {
                    _opacity = 100;
                }
                else if(value < 0)
                {
                    _opacity = 0;
                }
                else
                {
                    _opacity = value;
                }
            }
        }

        public Blob Blob { get; private set; }


        protected DrawableImage()
        {
        }


        public DrawableImage(Blob blob)
        {
            DrawableImageID = Guid.NewGuid();
            Blob = blob;
            Opacity = 100;
        }


        //public Bitmap GetBitmap(int width = 0, int height = 0)
        //{
        //    var bmp = Image?.GetBitmap();
        //    if(bmp != null)
        //    {
        //        if(width == 0 && height == 0 || width == bmp.Width && height == bmp.Height)
        //        {
        //            return bmp;
        //        }

        //        return bmp.ResizeImage(width, height);
        //    }


        //    if(!File.Exists(FilePath))
        //    {
        //        return null;
        //    }

        //    bmp = new Bitmap(FilePath);
        //    var replaceAlpha = -1;
        //    var replaceBlackAsAlpha = -1;

        //    if(Options.ContainsKey(DrawableImageOptions.ReplaceAlpha))
        //    {
        //        var value = Options[DrawableImageOptions.ReplaceAlpha];
        //        int.TryParse(value, out replaceAlpha);
        //    }

        //    if(Options.ContainsKey(DrawableImageOptions.ReplaceBlackAsAlpha))
        //    {
        //        var value = Options[DrawableImageOptions.ReplaceBlackAsAlpha];
        //        int.TryParse(value, out replaceBlackAsAlpha);
        //    }

        //    if(replaceAlpha != -1 || replaceBlackAsAlpha != -1)
        //    {
        //        var newBmp = new Bitmap(bmp.Width, bmp.Height);
        //        var lockedNewBitmap = new LockBitmap(newBmp);
        //        lockedNewBitmap.LockBits();

        //        var lockedBitmap = new LockBitmap(bmp);
        //        lockedBitmap.LockBits();


        //        Parallel.For(0, lockedNewBitmap.Width, i =>
        //        {
        //            for(var j = 0; j < lockedNewBitmap.Height; j++)
        //            {
        //                var pixel = lockedBitmap.GetPixel(i, j);
        //                if(replaceBlackAsAlpha != -1 && pixel.A == 0 && pixel.R == 0 && pixel.G == 0 & pixel.B == 0)
        //                {
        //                    lockedNewBitmap.SetPixel(i, j, Color.Transparent);
        //                    continue;
        //                }

        //                lockedNewBitmap.SetPixel(i, j, Color.FromArgb(replaceAlpha, pixel.R, pixel.G, pixel.B));
        //            }
        //        });

        //        lockedBitmap.UnlockBits();
        //        lockedNewBitmap.UnlockBits();

        //        bmp = newBmp;
        //        Image = new ImagePacket(newBmp);
        //    }

        //    if(width == 0 && height == 0 || width == bmp.Width && height == bmp.Height)
        //    {
        //        return bmp;
        //    }

        //    return bmp.ResizeImage(width, height);
        //}

        //public async Task<Bitmap> GetBitmapAsync(int width = 0, int height = 0)
        //{
        //    return await new Task<Bitmap>(() =>
        //    {
        //        return GetBitmap(width, height);
        //    });
        //}
    }
}
