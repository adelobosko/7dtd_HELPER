using System.Collections.Generic;
using System.Drawing;

namespace _7dtd_HELP
{
    public class DecorationGroup
    {
        public string Name { get; set; }
        public List<Prefab> Prefabs { get; set; }
        public Icon Icon { get; set; }
        public bool IsEnabled { get; set; }

        public DecorationGroup()
        {
            Prefabs = new List<Prefab>();
            Icon = new Icon();
            IsEnabled = true;
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
        public string Name { get; set; }
        public Bitmap Image { get; set; }
        public bool IsShow { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Icon()
        {
            Image = null;
            IsShow = false;
            Width = -1;
            Height = -1;
        }
    }
}
