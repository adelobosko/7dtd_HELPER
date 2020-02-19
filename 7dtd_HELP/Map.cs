using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _7dtd_HELP
{
    public class Map
    {
        public static readonly int DefaultCellSize = 50;
        public static readonly int DefaultSize = 3072;
        public static readonly int DefaultScale = 10;
        public static readonly Point DefaultOffset = new Point(0, 0);

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ip { get; set; }

        public string Port { get; set; }

        public int CellSize { get; set; }

        public int Size { get; set; }

        public int Scale { get; set; }

        public Point Offset { get; set; }
        public Dictionary<string, List<MapPoint>> MapCollection { get; }
        public List<MapPoint> Prefabs { get; }
        public Map()
        {
            Name = "DefaultEmptyMap";
            Size = DefaultSize;
            Scale = DefaultScale;
            CellSize = DefaultCellSize;
            MapCollection = new Dictionary<string, List<MapPoint>>();
            Prefabs = new List<MapPoint>();
        }

        public void Draw(IMapDrawer mapDrawer)
        {
            mapDrawer.DrawMap(this);
        }

        
        public static Map Load(string mapName)
        {
            var path = Path.Combine(GlobalHelper.Paths.MapsDirectory, $"{mapName}.json");

            var jsonString = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Map>(jsonString);
        }
    }

    public static class MapExtension
    {
        public static void Save(this Map map)
        {
            if (!Directory.Exists(GlobalHelper.Paths.ConfigDirectory))
            {
                Directory.CreateDirectory(GlobalHelper.Paths.ConfigDirectory);
            }
            if (!Directory.Exists(GlobalHelper.Paths.MapsDirectory))
            {
                Directory.CreateDirectory(GlobalHelper.Paths.MapsDirectory);
            }

            var path = Path.Combine(GlobalHelper.Paths.MapsDirectory, $"{map.Name}.json");
            var jsonString = JsonConvert.SerializeObject(map);
            File.WriteAllText(path, jsonString);
        }

        public static void LoadPrefabs(this Map map, string filename, IMapLoader mapLoader)
        {
            var mapPoints = mapLoader.LoadMapPoints(filename);
            if (mapPoints == null)
            {
                Console.WriteLine("LoadPrefabs: mapPoints == null");
                return;
            }

            map.Prefabs.Clear();
            map.Prefabs.AddRange(mapPoints);
        }

        public static void LoadMapInfo(this Map map, string filename)
        {
            var textAll = File.ReadAllText(filename);
            var startText = "HeightMapSize\" value=\"";
            var startIndex = textAll.IndexOf(startText, StringComparison.Ordinal);
            if (startIndex <= -1) return;

            var endText = ",";
            var endIndex = textAll.IndexOf(endText, startIndex + startText.Length, StringComparison.Ordinal);

            if (endIndex <= -1) return;

            var sizeString = textAll.Substring(startIndex + startText.Length,
                endIndex - startIndex - startText.Length);

            map.Size = Convert.ToInt32(sizeString) / 2;
        }
    }
}