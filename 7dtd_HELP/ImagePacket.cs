using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _7dtd_HELP
{
    public class DrawableImage
    {
        private int _opacity;
        private string _filePath;

        [JsonIgnore]
        public readonly Map Map;

        [JsonIgnore]
        public ImagePacket Image { get; set; }
        public bool IsShown { get; set; }
        public int Opacity
        {
            get => _opacity;
            set
            {
                if (value > 100)
                {
                    _opacity = 100;
                }
                else if (value < 0)
                {
                    _opacity = 0;
                }
                else
                {
                    _opacity = value;
                }
            }
        }
        public Dictionary<string, string> Options { get; set; }

        public static class DrawableImageOptions
        {
            public static readonly string ReplaceAlpha = "ReplaceAlpha";
            public static readonly string ReplaceBlackAsAlpha = "ReplaceBlackAsAlpha";
        }

        public string FilePath
        {
            get => Path.Combine(Map.DirectoryPath, _filePath);
            private set => _filePath = value;
        }



        public DrawableImage(Map map, string filePath)
        {
            Map = map;
            Opacity = 100;
            FilePath = filePath;
            Options = new Dictionary<string, string>();
        }


        public Bitmap GetBitmap(int width = 0, int height = 0)
        {
            var bmp = Image?.GetBitmap();
            if (bmp != null)
            {
                if (width == 0 && height == 0 || width == bmp.Width && height == bmp.Height)
                {
                    return bmp;
                }

                return bmp.ResizeImage(width, height);
            }


            if (!File.Exists(FilePath))
            {
                return null;
            }

            bmp = new Bitmap(FilePath);
            var replaceAlpha = -1;
            var replaceBlackAsAlpha = -1;

            if (Options.ContainsKey(DrawableImageOptions.ReplaceAlpha))
            {
                var value = Options[DrawableImageOptions.ReplaceAlpha];
                int.TryParse(value, out replaceAlpha);
            }

            if (Options.ContainsKey(DrawableImageOptions.ReplaceBlackAsAlpha))
            {
                var value = Options[DrawableImageOptions.ReplaceBlackAsAlpha];
                int.TryParse(value, out replaceBlackAsAlpha);
            }

            if (replaceAlpha != -1 || replaceBlackAsAlpha != -1)
            {
                var newBmp = new Bitmap(bmp.Width, bmp.Height);
                var lockedNewBitmap = new LockBitmap(newBmp);
                lockedNewBitmap.LockBits();

                var lockedBitmap = new LockBitmap(bmp);
                lockedBitmap.LockBits();


                Parallel.For(0, lockedNewBitmap.Width, i =>
                {
                    for (var j = 0; j < lockedNewBitmap.Height; j++)
                    {
                        var pixel = lockedBitmap.GetPixel(i, j);
                        if (replaceBlackAsAlpha != -1 && pixel.A == 0 && pixel.R == 0 && pixel.G == 0 & pixel.B == 0)
                        {
                            lockedNewBitmap.SetPixel(i, j, Color.Transparent);
                            continue;
                        }

                        lockedNewBitmap.SetPixel(i, j, Color.FromArgb(replaceAlpha, pixel.R, pixel.G, pixel.B));
                    }
                });

                lockedBitmap.UnlockBits();
                lockedNewBitmap.UnlockBits();

                bmp = newBmp;
                Image = new ImagePacket(newBmp);
            }

            if (width == 0 && height == 0 || width == bmp.Width && height == bmp.Height)
            {
                return bmp;
            }

            return bmp.ResizeImage(width, height);
        }

        public async Task<Bitmap> GetBitmapAsync(int width = 0, int height = 0)
        {
            return await new Task<Bitmap>(() =>
            {
                return GetBitmap(width, height);
            });
        }
    }

    public class ImagePacket
    {
        public string Hash { get; set; }
        public int Length { get; set; }
        public string Image { get; set; }

        public ImagePacket()
        {
            Hash = string.Empty;
            Image = string.Empty;
        }

        public ImagePacket(byte[] imageBytes) : this()
        {
            Hash = StringHash(imageBytes);
            Length = imageBytes.Length;
            Image = Convert.ToBase64String(imageBytes);
        }

        public ImagePacket(Image image) : this()
        {
            var imageBytes = image.ToBytes();
            Hash = StringHash(imageBytes);
            Length = imageBytes.Length;
            Image = Convert.ToBase64String(imageBytes);
        }

        public ImagePacket(Bitmap image) : this()
        {
            var imageBytes = image.ToBytes();
            Hash = StringHash(imageBytes);
            Length = imageBytes.Length;
            Image = Convert.ToBase64String(imageBytes);
        }

        public byte[] GetBytes()
        {
            byte[] data = Convert.FromBase64String(Image);

            if (data.Length != Length) throw new Exception("Error data len");
            if (!StringHash(data).Equals(Hash)) throw new Exception("Error hash");

            return data;
        }

        public Bitmap GetBitmap()
        {
            var bytes = GetBytes();
            return BitmapHelper.BytesToBitmap(bytes);
        }

        public static string StringHash(byte[] value)
        {
            var sb = new StringBuilder();
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(value);
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }
}