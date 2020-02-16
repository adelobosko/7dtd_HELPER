using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7dtd_HELP
{
    public static class GlobalHelper
    {
        public static class Paths
        {
            public static string ProgramFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            public static string ConfigFolder = Path.Combine(ProgramFolder, "config");
            public static string ConfigFile = Path.Combine(ConfigFolder, "config.cfg");
            public static string PrefabsZipFile = Path.Combine(ConfigFolder, "master.zip");
            public static string PrefabsFolder = Path.Combine(ConfigFolder, "prefabs");

        }

        public static WebHelper WebHelper { get; set; }
        public delegate void OnStatusChanged(object myObject, string message, int percentage);
        public static OnStatusChanged UpdateStatus { get; set; }
    }
}
