using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace _7dtd_HELP
{
    public class PrefabsConfig
    {
        private static readonly string prefabsUrl = "https://github.com/kui/7dtd-map/archive/master.zip";

        public DateTime LastUpdateTime { get; set; }
        public List<Prefab> Prefabs { get; set; }

        public PrefabsConfig()
        {
            LastUpdateTime = new DateTime(2000, 01, 01);
            Prefabs = new List<Prefab>();
        }

        public PrefabsConfig(DateTime lastUpdateTime, List<Prefab> prefabs)
        {
            LastUpdateTime = lastUpdateTime;
            Prefabs = new List<Prefab>(prefabs);
        }

        public static void ClearPrefabsCache()
        {
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...", 0);

            if (!Directory.Exists(GlobalHelper.Paths.ConfigDirectory))
            {
                Directory.CreateDirectory(GlobalHelper.Paths.ConfigDirectory);
            }
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...",25);

            if (File.Exists(GlobalHelper.Paths.PrefabsZipFile))
            {
                File.Delete(GlobalHelper.Paths.PrefabsZipFile);
            }
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...", 50);
            
            if (Directory.Exists(GlobalHelper.Paths.UnzippedPrefabsDirectory))
            {
                Directory.Delete(GlobalHelper.Paths.UnzippedPrefabsDirectory, true);
            }
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...", 75);

            if (Directory.Exists(GlobalHelper.Paths.PrefabsDirectory))
            {
                Directory.Delete(GlobalHelper.Paths.PrefabsDirectory, true);
            }
            GlobalHelper.UpdateStatus?.Invoke("Prefabs cache is cleared", "Cache are cleared", 100);
        }

        public static void UnzipPrefabs()
        {
            try
            {
                GlobalHelper.UpdateStatus?.Invoke("Unzipping prefabs", "Prefabs unzipping...", 0);
                ZipFile.ExtractToDirectory(GlobalHelper.Paths.PrefabsZipFile,
                    GlobalHelper.Paths.UnzippedPrefabsDirectory);
                GlobalHelper.UpdateStatus?.Invoke("Prefabs are unzipped", "Prefabs are unzipped", 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdatePrefabs()
        {
            ClearPrefabsCache();

            var downloadTask = GlobalHelper.WebHelper.DownloadFileAsync(prefabsUrl, GlobalHelper.Paths.PrefabsZipFile, "Prefabs downloading...");
            downloadTask.Wait();

            UnzipPrefabs();

            var moveTask = Task.Run(() =>
            {
                var dirInfo = new DirectoryInfo(GlobalHelper.Paths.UnzippedPrefabsDirectory);
                long sourceDirSize = 0;
                long destinationDirSize = 0;
                foreach (FileInfo fi in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    sourceDirSize += fi.Length;
                }

                var taskCopy = Task.Run(() =>
                {
                    Directory.Move(GlobalHelper.Paths.UnzippedPrefabsDirectory, GlobalHelper.Paths.PrefabsDirectory);
                });

                var taskWatch = Task.Run(async () =>
                {
                    while (sourceDirSize > destinationDirSize)
                    {
                        destinationDirSize = 0;
                        foreach (FileInfo fi in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                        {
                            destinationDirSize += fi.Length;
                        }
                        GlobalHelper.UpdateStatus?.Invoke(this, "Copping prefabs...", (int)sourceDirSize / 100 * (int)destinationDirSize);
                        Task delay = Task.Delay(500);
                        await delay;
                    }
                });
            });
            moveTask.Wait();

            GlobalHelper.UpdateStatus?.Invoke(this, "Parsing prefabs...", 0);
            var prefabsDirectoryInfo = new DirectoryInfo(GlobalHelper.Paths.PrefabsDirectory);
            var htmlFiles = prefabsDirectoryInfo.GetFiles("*.html", SearchOption.AllDirectories);
            Prefabs.Clear();
            for (var i = 0; i < htmlFiles.Length; i++)
            {
                var blocks = Prefab.GetPrefabBlocksByHtml(htmlFiles[i].FullName);
                Prefabs.Add(new Prefab()
                {
                    FileName = htmlFiles[i].FullName,
                    Name = Path.GetFileNameWithoutExtension(htmlFiles[i].Name),
                    Blocks = new List<PrefabBlock>(blocks)
                });
                var percentage = (i + 1) * 100.0 / htmlFiles.Length;
                if (percentage > 0 && percentage < 100)
                    GlobalHelper.UpdateStatus?.Invoke(this, $"Parsing prefabs... ({percentage:0.00}%)", (int)percentage);
            }
        }
    }
}
