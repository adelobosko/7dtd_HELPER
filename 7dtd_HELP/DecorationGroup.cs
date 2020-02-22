using System.Collections.Generic;
using System.Drawing;

namespace _7dtd_HELP
{
    public class DecorationGroup
    {
        public static Brush DefaultBrush = Brushes.Blue;
        public static int DefaultBrushSize = 8;

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                name = value;
            }
        }

        public List<Prefab> Prefabs { get; set; }
        public Icon Icon { get; set; }
        public bool IsEnabled { get; set; }
        public Brush BrushColor { get; set; }
        public int BrushSize { get; set; }

        public DecorationGroup()
        {
            Prefabs = new List<Prefab>();
            Icon = new Icon();
            IsEnabled = true;
            BrushColor = DefaultBrush;
            BrushSize = DefaultBrushSize;
        }
    }

    public static class DecorationGroupExtension
    {
        public static void SetPrefabs(this DecorationGroup decorationGroup, List<Prefab> prefabs)
        {
            decorationGroup.Prefabs = new List<Prefab>(prefabs);
        }
    }

    public class Icon
    {
        public string FullName { get; set; }
        public bool IsShow { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Icon()
        {
            IsShow = false;
            Width = -1;
            Height = -1;
        }
    }

    public static class IconExtension
    {
        public static Bitmap GetBitmapByFile(this Icon icon)
        {
            return (Bitmap)Image.FromFile(icon.FullName);
        }
    }
}
