using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _7DTD_Directx.Map
{
    internal static class MapProvider
    {
        internal static void TryLoadMapFromSaveLocalFolder(string path)
        {
            var mapName = Path.GetFileName(path);
            var hostsFile = Path.Combine(path, "hosts.txt");
            var worldDirectory = Path.Combine(path, "World");
            var mapInfoFile = Path.Combine(worldDirectory, "map_info.xml");
            var prefabsFile = Path.Combine(worldDirectory, "prefabs.xml");
            var spawnPointsFile = Path.Combine(worldDirectory, "spawnpoints.xml");

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
                    MessageBox.Show($"Could not find a {filePath} file.\r\nSeems the SaveLocal folder is broken or not loaded.");
                    return;
                }
            }

            foreach(var directoryPath in directoriesThatShouldExist)
            {
                if(!Directory.Exists(directoryPath))
                {
                    MessageBox.Show($"Could not find a {directoryPath} directory. Seems the SaveLocal folder is broken or not loaded.");
                    return;
                }
            }

            var mapPath = Path.Combine(Utils.Paths.MapsDirectory, $"{mapName}.json");
            if(File.Exists(mapPath))
            {
                throw new NotImplementedException();
                //UpdateAndLoadMap(mapPath);
            }
            else
            {
                CreateAndLoadMap(mapPath);
            }



            return;




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


        private static void CreateAndLoadMap(string path)
        {
            var mapName = Path.GetFileName(path);
            var hostsFile = Path.Combine(path, "hosts.txt");
            var host = GetIPAndPort(hostsFile);

            var map = new Map(mapName, path, host);

            var worldDirectory = Path.Combine(path, "World");
            var mapInfoFile = Path.Combine(worldDirectory, "map_info.xml");
            var mapSize = GetMapSize(mapInfoFile);

            map.Size = mapSize;

            var prefabsFile = Path.Combine(worldDirectory, "prefabs.xml");
            var spawnPointsFile = Path.Combine(worldDirectory, "spawnpoints.xml");
        }


        private static (string IP, string Port) GetIPAndPort(string path)
        {
            var hosts = File.ReadAllText(path)
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
