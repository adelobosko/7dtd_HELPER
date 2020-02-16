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
        public List<MapPoint> Prefabs { get; }
        public List<ConfiguredDecoration> AllowedDecorations { get; set; }
        public Map(int size = 3072, int scale = 10, int cellSize = 50)
        {
            Size = size;
            Scale = scale;
            CellSize = cellSize;
            MapCollection = new Dictionary<string, List<MapPoint>>();
            Prefabs = new List<MapPoint>();
            AllowedDecorations = new List<ConfiguredDecoration>();
        }

        public void LoadPrefabs(string filename, IMapLoader mapLoader)
        {
            Prefabs.Clear();
            var mapPoints = mapLoader.LoadMapPoints(filename);
            if(mapPoints == null)
                return;

            Prefabs.AddRange(mapPoints);
        }

        public void Draw(IMapDrawer mapDrawer)
        {
            mapDrawer.DrawMap(this);
        }
    }
}