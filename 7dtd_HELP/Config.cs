using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _7dtd_HELP
{
    public class Config
    {
        public Map Map { get; set; }
        public List<string> Maps { get; set; }
        public List<DecorationGroup> DecorationGroups { get; set; }
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
            return JsonConvert.DeserializeObject<Config>(jsonString);
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

            var jsonString = JsonConvert.SerializeObject(config);
            File.WriteAllText(GlobalHelper.Paths.ConfigFile, jsonString);
        }
    }
}
