using System;
using System.IO;

namespace _7DTD_Directx.Utils
{
    public static class Paths
    {
        public static string? ProgramDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location ?? "");
        public static string ConfigDirectory = Path.Combine(ProgramDirectory ?? "", "Config");

        public static string PrefabsDirectory = Path.Combine(ConfigDirectory, "Prefabs");
        public static string UnzippedDirectory = Path.Combine(ConfigDirectory, "master");
        public static string UnzippedPrefabsDirectory = Path.Combine(
            UnzippedDirectory,
            "7dtd-map-master",
            "docs",
            "prefabs");
        public static string MapsAppDataDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "7DaysToDie",
            "SavesLocal"
        );

        public static string PrefabsZipFile = Path.Combine(ConfigDirectory, "master.zip");
        public static string ConfigFile = Path.Combine(ConfigDirectory, "config.cfg");
        public static string PrefabsConfig = Path.Combine(ConfigDirectory, "prefabsConfig.cfg");
        public static string DecorationGroups = Path.Combine(ConfigDirectory, "decorationGroupsConfig.cfg");
    }
}
