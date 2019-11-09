using System.Collections.Generic;
using System.Drawing;

namespace _7dtd_HELP
{
    public class Map
    {
        public int CellSize { get; set; }
        public int Size {get; set; }
        public int Scale { get; set; }
        public Point Offset { get; set; }
        public Dictionary<string,List<MapPoint>> MapCollection { get; }
        public List<MapPoint> Perfabs { get; }
        public Map(int size = 3072, int sclae = 10, int cellSize = 50)
        {
            Size = size;
            Scale = sclae;
            CellSize = cellSize;
            MapCollection = new Dictionary<string, List<MapPoint>>();
            Perfabs = new List<MapPoint>();
        }

        public void LoadPerfabs(string filename, IMapLoader mapLoader)
        {
            Perfabs.Clear();
            var mapPoints = mapLoader.LoadMapPoints(filename);
            if(mapPoints == null)
                return;

            Perfabs.AddRange(mapPoints);
        }

        public void Draw(IMapDrawer mapDrawer)
        {
            mapDrawer.DrawMap(this);
        }
    }
}