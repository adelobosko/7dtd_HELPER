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
            public static string ProgramDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            public static string ConfigDirectory = Path.Combine(ProgramDirectory, "config");
            public static string PrefabsDirectory = Path.Combine(ConfigDirectory, "prefabs");
            public static string UnzippedDirectory = Path.Combine(ConfigDirectory, "master");
            public static string UnzippedPrefabsDirectory = Path.Combine(UnzippedDirectory, "7dtd-map-master/docs/prefabs");

            public static string PrefabsZipFile = Path.Combine(ConfigDirectory, "master.zip");
            public static string ConfigFile = Path.Combine(ConfigDirectory, "config.cfg");
        }

        public static WebHelper WebHelper { get; set; }
        public delegate void OnStatusChanged(object myObject, string message, int percentage);
        public static OnStatusChanged UpdateStatus { get; set; }

        public static class ProgramParams
        {
            public enum Argument
            {
                HELP = 0,
                H = 0,
                CONSOLE = 1,
                C = 1,
                LOG
            }

            public static string GetArgumentDefinition(Argument argument)
            {
                switch (argument)
                {
                    case Argument.HELP:
                    {
                        return "Writes an information about all commands";
                    }
                    case Argument.CONSOLE:
                    {
                        return "Opens a console";
                    }
                    case Argument.LOG:
                    {
                        return "Enables a logging";
                    }
                    default:
                        return $"Unknown argument {argument}";
                }
            }
        }
    }
}
