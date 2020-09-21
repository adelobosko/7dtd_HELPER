using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _7dtd_HELP
{


    public class Map
    {
        public static readonly string DefaultName = "DefaultEmptyMap";
        public static readonly int DefaultCellSize = 50;
        public static readonly int DefaultSize = 6144;
        public static readonly int DefaultScale = 1;
        public static readonly int DefaultToolTipRadius = 100;

        public Bitmap Biomes;

        public string Name { get; set; }
        public string DirectoryPath { get; set; }
        public string Description { get; set; }

        public string Ip { get; set; }

        public string Port { get; set; }

        public int CellSize { get; set; }

        public int Size { get; set; }
        public int ToolTipRadius { get; set; }
        public int Scale { get; set; }
        public bool IsBiomesShown { get; set; }
        public bool IsShowAllPrefabIcons { get; set; }
        //public List<MapObjectCollection> MapObjects { get; set; }
        public MapObjectCollection SpawnPoints { get; set; }
        public List<MapPoint> Prefabs { get; }
        public Bitmap Cities { get; set; }
        public bool IsCitiesShown { get; set; }
        public int CitiesOpacity { get; set; }
        public int BiomesOpacity { get; set; }

        public Map()
        {
            Name = DefaultName;
            Size = DefaultSize;
            Scale = DefaultScale;
            CellSize = DefaultCellSize;
            //MapObjects = new List<MapObjectCollection>();
            Prefabs = new List<MapPoint>();
            DirectoryPath = "";
            SpawnPoints = new MapObjectCollection()
            {
                Name = "Spawn points",
                Icon = null,
                IsEnabled = true,
                MapPoints = new List<MapPoint>(),
                BrushColor = Brushes.Red,
                BrushSize = MapObjectCollection.DefaultBrushSize
            };
            IsShowAllPrefabIcons = true;
            ToolTipRadius = DefaultToolTipRadius;
            CitiesOpacity = 100;
            BiomesOpacity = 100;
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
        public static int DefaultBrushSize = 8;
        public static Brush DefaultBrush = Brushes.Blue;

        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public Icon Icon { get; set; }
        public List<MapPoint> MapPoints { get; set; }
        public Brush BrushColor { get; set; }
        public int BrushSize { get; set; }

        public MapObjectCollection()
        {
            MapPoints = new List<MapPoint>();
            Icon = null;
            BrushColor = DefaultBrush;
            BrushSize = DefaultBrushSize;
        }
    }

    public static class MapExtension
    {
        public static Bitmap GetBiomes(this Map map, int width = 0, int height = 0)
        {
            if (map.Biomes != null)
            {
                if (width == 0 && height == 0 || width == map.Biomes.Width && height == map.Biomes.Height)
                {
                    return map.Biomes;
                }

                return map.Biomes.ResizeImage(width, height);
            }

            var biomesFile = Path.Combine(map.DirectoryPath, "World", "biomes.png");
            if (!File.Exists(biomesFile))
            {
                return null;
            }
            map.Biomes = (Bitmap)Image.FromFile(biomesFile);

            if (width == 0 && height == 0)
            {
                return map.Biomes;
            }

            return map.Biomes.ResizeImage(width, height);
        }

        public static Bitmap GetCities(this Map map, int width = 0, int height = 0)
        {
            if (map.Cities != null)
            {
                if (width == 0 && height == 0 || width == map.Cities.Width && height == map.Cities.Height)
                {
                    return map.Cities;
                }

                return map.Cities.ResizeImage(width, height);
            }

            var citiesFile = Path.Combine(map.DirectoryPath, "World", "splat3_processed.png");
            if (!File.Exists(citiesFile))
            {
                return null;
            }

            using (var bmp = new Bitmap(citiesFile))
            {
                var newBMP = new Bitmap(bmp.Width, bmp.Height);
                for (var i = 0; i < bmp.Width; i++)
                {
                    for (var j = 0; j < bmp.Height; j++)
                    {
                        var pixel = bmp.GetPixel(i, j);
                        if (pixel.A == 0 && pixel.R == 0 && pixel.G == 0 & pixel.B == 0)
                        {
                            newBMP.SetPixel(i,j, Color.Transparent);
                            continue;
                        }

                        newBMP.SetPixel(i, j, Color.FromArgb(255 , pixel.R, pixel.G, pixel.B));
                    }
                }

                map.Cities = newBMP;

                if (width == 0 && height == 0 || width == map.Cities.Width && height == map.Cities.Height)
                {
                    return map.Cities;
                }

                return map.Cities.ResizeImage(width, height);
            }
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

            map.Size = Convert.ToInt32(sizeString);
        }

        public static void LoadSpawnPoints(this Map map, string filename)
        {
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

                map.SpawnPoints.MapPoints.Add(new MapPoint()
                {
                    Name = "SpawnPoint",
                    X = Convert.ToInt32(coordinates[0]),
                    Y = Convert.ToInt32(coordinates[2])
                });
            }
        }
    }
}