using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;

namespace _7dtd_HELP
{
    public class Config
    {
        [JsonIgnore]
        public Map Map { get; set; }

        public List<string> Maps { get; set; }

        [JsonIgnore]
        public List<DecorationGroup> DecorationGroups { get; set; }

        [JsonIgnore]
        public PrefabsConfig PrefabsConfig { get; set; }

        public Rectangle CoordinatesRectangle { get; set; }
        public Point CurrentMapCenterGameCoordinates { get; set; }


        public Config()
        {
            Map = new Map();
            Maps = new List<string>();
            PrefabsConfig = new PrefabsConfig();
            DecorationGroups = new List<DecorationGroup>();
        }

        public static Config Load(Config config)
        {
            if (!File.Exists(GlobalHelper.Paths.ConfigFile))
            {
                config.Save();
            }

            var jsonString = File.ReadAllText(GlobalHelper.Paths.ConfigFile);
            config = JsonConvert.DeserializeObject<Config>(jsonString);

            try
            {
                config.Map = Map.Load(config.Maps.First());
            }
            catch (ArgumentException ex)
            {
                config.Map = new Map();
            }

            config.PrefabsConfig = LoadPrefabsConfig();
            config.DecorationGroups = LoadDecorationGroups();

            return config;
        }

        private static PrefabsConfig LoadPrefabsConfig()
        {
            var jsonString = File.ReadAllText(GlobalHelper.Paths.PrefabsConfig);
            return JsonConvert.DeserializeObject<PrefabsConfig>(jsonString);
        }

        private static List<DecorationGroup> LoadDecorationGroups()
        {
            var jsonString = File.ReadAllText(GlobalHelper.Paths.DecorationGroups);
            return JsonConvert.DeserializeObject<List<DecorationGroup>>(jsonString);
        }
    }

    public static class ConfigExtension
    {
        public static void Save(this Config config)
        {
            if (config.Maps == null)
            {
                MessageBox.Show("config.Maps = null");
                return;
            }
            if (!Directory.Exists(GlobalHelper.Paths.ConfigDirectory))
            {
                Directory.CreateDirectory(GlobalHelper.Paths.ConfigDirectory);
            }
            
            if(!GlobalHelper.Config.Maps.Contains(config.Map.Name))
            {
                GlobalHelper.Config.Maps.Add(config.Map.Name);
            }
            config.Map.Save();

            config.Maps.Remove(config.Map.Name);
            config.Maps.Insert(0, config.Map.Name);

            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText(GlobalHelper.Paths.ConfigFile, json);

            SavePrefabsConfig(config);
            SaveDecorationGroups(config);
        }


        public static void SavePrefabsConfig(Config config)
        {
            var json = JsonConvert.SerializeObject(config.PrefabsConfig);
            File.WriteAllText(GlobalHelper.Paths.PrefabsConfig, json);
        }


        public static void SaveDecorationGroups(Config config)
        {
            var json = JsonConvert.SerializeObject(config.DecorationGroups);
            File.WriteAllText(GlobalHelper.Paths.DecorationGroups, json);
        }
    }
}
