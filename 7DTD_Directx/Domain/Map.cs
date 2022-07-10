using _7DTD_Directx.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Threading.Tasks;

namespace _7DTD_Directx.Domain
{
    [Table("Maps", Schema = "Map")]
    public class Map
    {
        public Guid MapID { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public (string IP, string Port) Host { get; private set; }

        public int Size { get; set; }
        public DrawableImage? Cities { get; set; }
        public DrawableImage? Biomes { get; set; }
        public DrawableImage? Radiation { get; set; }


        public List<SpawnPoint> SpawnPoints { get; private set; }
        public List<PrefabPoint> PrefabPoints { get; private set; }


        private Map()
        {

        }


        public Map(string name, string path, (string IP, string Port) host)
        {
            Name = name;
            Path = path;
            Host = host;
            MapID = Guid.NewGuid();
            SpawnPoints = new List<SpawnPoint>();
            PrefabPoints = new List<PrefabPoint>();
        }


        public static async Task<Map> LoadMapFromFolder(string path)
        {
            var mapName = System.IO.Path.GetFileName(path);
            var hostsFile = System.IO.Path.Combine(path, "hosts.txt");
            var worldDirectory = System.IO.Path.Combine(path, "World");
            var mapInfoFile = System.IO.Path.Combine(worldDirectory, "map_info.xml");
            var prefabsFile = System.IO.Path.Combine(worldDirectory, "prefabs.xml");
            var spawnPointsFile = System.IO.Path.Combine(worldDirectory, "spawnpoints.xml");

            var filesThatShouldExist = new string[] {
                hostsFile, mapInfoFile, prefabsFile, spawnPointsFile
            };
            var directoriesThatShouldExist = new string[] {
                worldDirectory
            };


            foreach(var filePath in filesThatShouldExist)
            {
                if(!File.Exists(filePath))
                {
                    throw new Exception($"Could not find a {filePath} file.\r\nSeems the SaveLocal folder is broken or not loaded.");
                }
            }

            foreach(var directoryPath in directoriesThatShouldExist)
            {
                if(!Directory.Exists(directoryPath))
                {
                    throw new Exception($"Could not find a {directoryPath} directory. Seems the SaveLocal folder is broken or not loaded.");
                }
            }


            var host = await GetIPAndPort(hostsFile);
            var map = new Map(mapName, path, host);

            var mapSize = GetMapSize(mapInfoFile);
            map.Size = mapSize;

            var biomesBlob = GetBiomesBlob(worldDirectory, "biomes.png");
            map.Biomes = new DrawableImage(biomesBlob);

            var radiationBlob = GetRadiationBlob(worldDirectory, "radiation.png");
            map.Radiation = new DrawableImage(radiationBlob);

            var citiesBlob = GetCitiesBlob(worldDirectory, "splat3_processed.png");
            map.Cities = new DrawableImage(citiesBlob);

            return map;




            /*

            GlobalHelper.Config.Map = new Map()
            {
                Name = mapName
            };

            if(!GlobalHelper.Config.Maps.Contains(mapName))
            {
                var item = new ToolStripMenuItem()
                {
                    Name = $"{mapName}ToolStripMenuItem",
                    Checked = false,
                    Text = mapName
                };
                item.Click += (o, args) =>
                {
                    LoadMapFolder(path);
                };
                loadToolStripMenuItem.DropDownItems.Add(item);
            }

            GlobalHelper.Config.Map.LoadPrefabs(prefabsFile, new XmlPrefabsMapLoader());
            GlobalHelper.Config.Map.LoadSpawnPoints(spawnPointsFile);
            GlobalHelper.Config.Map.DirectoryPath = path;

            GlobalHelper.Config.Save();
            UpdateUI();*/
        }


        private static Blob GetCitiesBlob(string worldDirectory, string filename)
        {
            var path = System.IO.Path.Combine(worldDirectory, filename);
            var bitmapSource = BitmapSourceExtension.GetBitmapSourceFromFile(path);
            var oldColor = new MaskColor(0, 0, 0, 0);
            var newColor = new MaskColor(222, 222, 222, 222);
            bitmapSource = bitmapSource.ReplaceColor(oldColor, newColor);
            oldColor = new MaskColor(0, null, null, null);
            newColor = new MaskColor(255, null, null, null);
            bitmapSource = bitmapSource.ReplaceColor(oldColor, newColor);
            oldColor = new MaskColor(222, 222, 222, 222);
            newColor = new MaskColor(0, 222, 222, 222);
            bitmapSource = bitmapSource.ReplaceColor(oldColor, newColor);
            var bytes = bitmapSource.ToByteArray();
            var blob = new Blob(filename, bytes);

            bitmapSource.SaveToFile(filename);
            return blob;
        }


        private static Blob GetRadiationBlob(string worldDirectory, string filename)
        {
            var path = System.IO.Path.Combine(worldDirectory, filename);
            var bitmapSource = BitmapSourceExtension.GetBitmapSourceFromFile(path);
            var oldColor = new MaskColor(null, 0, 0, 0);
            var newColor = new MaskColor(0, 0, 0, 0);
            bitmapSource = bitmapSource.ReplaceColor(oldColor, newColor);
            var bytes = bitmapSource.ToByteArray();
            var blob = new Blob(filename, bytes);

            bitmapSource.SaveToFile(filename);
            return blob;
        }


        private static Blob GetBiomesBlob(string worldDirectory, string filename)
        {
            var path = System.IO.Path.Combine(worldDirectory, filename);
            var bitmapSource = BitmapSourceExtension.GetBitmapSourceFromFile(path);
            var bytes = bitmapSource.ToByteArray();
            var blob = new Blob(filename, bytes);
            bitmapSource.SaveToFile(filename);
            return blob;
        }


        private static async Task<(string IP, string Port)> GetIPAndPort(string path)
        {
            var hosts = (await File.ReadAllTextAsync(path))
                .Replace("\r", "")
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var ip = "";
            var port = "";
            if(hosts.Length > 0)
            {
                var host = hosts[0].Split(':');
                if(host.Length > 1)
                {
                    ip = host[0];
                    port = host[1];
                }
            }

            return (ip, port);
        }


        private static int GetMapSize(string filePath)
        {
            var textAll = File.ReadAllText(filePath);
            var startText = "HeightMapSize\" value=\"";
            var startIndex = textAll.IndexOf(startText, StringComparison.Ordinal);
            if(startIndex >= 0)
            {
                var endText = ",";
                var endIndex = textAll.IndexOf(endText, startIndex + startText.Length, StringComparison.Ordinal);

                if(endIndex >= 0)
                {
                    var sizeString = textAll.Substring(startIndex + startText.Length, endIndex - startIndex - startText.Length);
                    var mapSize = Convert.ToInt32(sizeString);
                    return mapSize;
                }
            };

            throw new Exception($"Could not read MapSize from {filePath}");
        }
    }
}
