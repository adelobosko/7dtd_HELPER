namespace _7DTD_Directx.Domain
{
    public abstract class MapPoint
    {

        public string Name { get; set; }
        public bool ShouldShow { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public MapPointRotation Rotation { get; set; }


        //public static int DefaultBrushSize = 8;
        //public static Brush DefaultBrush = Brushes.Blue;
        //public Icon Icon { get; set; }
        //public List<MapPoint> MapPoints { get; set; }
        //public Brush BrushColor { get; set; }
        //public int BrushSize { get; set; }

        protected MapPoint()
        {
        }

        public MapPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
