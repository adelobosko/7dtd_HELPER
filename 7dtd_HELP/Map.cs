using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _7dtd_HELP
{
    public class Map
    {
        public static readonly string DefaultName = "DefaultEmptyMap";
        public static readonly int DefaultCellSize = 50;
        public static readonly int DefaultSize = 3072;
        public static readonly int DefaultScale = 10;
        public static readonly Point DefaultOffset = new Point(0, 0);
        public static Bitmap Biomes = null;

        public string Name { get; set; }
        public string DirectoryPath { get; set; }
        public string Description { get; set; }

        public string Ip { get; set; }

        public string Port { get; set; }

        public int CellSize { get; set; }

        public int Size { get; set; }

        public int Scale { get; set; }
        public bool IsBiomesShown { get; set; }

        public Point Offset { get; set; }
        public List<MapObjectCollection> MapObjects { get; set; }
        public List<MapPoint> Prefabs { get; }
        public Map()
        {
            Name = DefaultName;
            Size = DefaultSize;
            Scale = DefaultScale;
            CellSize = DefaultCellSize;
            MapObjects = new List<MapObjectCollection>();
            Prefabs = new List<MapPoint>();
            Offset = DefaultOffset;
            DirectoryPath = "";
        }

        public void Draw(IMapDrawer mapDrawer)
        {
            mapDrawer.DrawMap(this);
        }

        
        public static Map Load(string mapName)
        {
            var path = Path.Combine(GlobalHelper.Paths.MapsDirectory, $"{mapName}.json");
            if (!File.Exists(path))
            {
                MessageBox.Show($"Path {path} is not exist!");
            }
            var jsonString = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Map>(jsonString);
        }
    }

    public class MapObjectCollection
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public List<MapPoint> MapPoints { get; set; }

        public MapObjectCollection()
        {
            MapPoints = new List<MapPoint>();
        }
    }

    public static class MapExtension
    {
        public static Bitmap GetBiomes(this Map map, int width = 0, int height = 0)
        {
            if (Map.Biomes != null)
            {
                if (width == 0 && height == 0)
                {
                    return Map.Biomes;
                }

                return Map.Biomes.ResizeImage(width, height);
            }

            var biomesFile = Path.Combine(map.DirectoryPath, "World", "biomes.png");
            if (!File.Exists(biomesFile))
            {
                return null;
            }
            Map.Biomes = (Bitmap)Image.FromFile(biomesFile);

            if (width == 0 && height == 0)
            {
                return Map.Biomes;
            }

            return Map.Biomes.ResizeImage(width, height);
        }

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

            if (map.Name == Map.DefaultName)
            {
                return;
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

        public static void LoadSpawnPoints(this Map map, string filename)
        {
            var spawnPoints = new MapObjectCollection()
            {
                Name = "SpawnPoints",
                IsEnabled = true,
                MapPoints = new List<MapPoint>()
            };
            var textAll = File.ReadAllText(filename);

            textAll = textAll.Replace(
                    new[] { "<spawnpoints>", "</spawnpoints>", "<spawnpoint", " ", "\r", "\n", },
                    "");
            var rows = textAll.Split(new[] {"/>"}, StringSplitOptions.RemoveEmptyEntries);
            textAll = null;
            foreach (var row in rows)
            {
                var startText = "position=\"";
                var startIndex = row.IndexOf(startText, StringComparison.Ordinal);
                if (startIndex <= -1) continue;
                var endText = "\"";
                var endIndex = row.IndexOf(endText, startIndex + startText.Length, StringComparison.Ordinal);

                if (endIndex <= -1) return;

                var coordinates = row.Substring(
                        startIndex + startText.Length,
                        endIndex - startIndex - startText.Length)
                    .Split(',');

                if(coordinates.Length != 3)
                    continue;

                spawnPoints.MapPoints.Add(new MapPoint()
                {
                    Name = "",
                    X = Convert.ToInt32(coordinates[0]),
                    Y = Convert.ToInt32(coordinates[2])
                });
            }

            var existSpawnPoints = map.MapObjects.SingleOrDefault(mc => mc.Name == spawnPoints.Name);
            if (existSpawnPoints != null)
            {
                map.MapObjects.Remove(existSpawnPoints);
            }
            map.MapObjects.Add(spawnPoints);
        }
    }
}