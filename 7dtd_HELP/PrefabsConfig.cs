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

        public void UpdatePrefabs()
        {
            GlobalHelper.UpdateStatus?.Invoke(this, "Clearing cache...", 0);
            if (!Directory.Exists(GlobalHelper.Paths.ConfigFolder))
            {
                Directory.CreateDirectory(GlobalHelper.Paths.ConfigFolder);
            }
            if (File.Exists(GlobalHelper.Paths.PrefabsZipFile))
            {
                File.Delete(GlobalHelper.Paths.PrefabsZipFile);
            }
            var unzipPath = Path.Combine(GlobalHelper.Paths.ConfigFolder, "master");
            if (Directory.Exists(unzipPath))
            {
                Directory.Delete(unzipPath, true);
            }
            GlobalHelper.UpdateStatus?.Invoke(this, "Cache are cleared", 100);


            var downloadTask = GlobalHelper.WebHelper.DownloadFileAsync(prefabsUrl, GlobalHelper.Paths.PrefabsZipFile, "Prefabs downloading...");
            downloadTask.Wait();


            GlobalHelper.UpdateStatus?.Invoke(this, "Prefabs unzipping...", 0);
            GlobalHelper.UpdateStatus?.Invoke(this, "Prefabs unzipping...", 50);
            ZipFile.ExtractToDirectory(GlobalHelper.Paths.PrefabsZipFile, unzipPath);
            GlobalHelper.UpdateStatus?.Invoke(this, "Prefabs are unzipped", 100);


            var moveTask = Task.Run(() =>
            {
                var sourceDir = Path.Combine(unzipPath, "7dtd-map-master/docs/prefabs");
                var dirInfo = new DirectoryInfo(sourceDir);
                long sourceDirSize = 0;
                long destinationDirSize = 0;
                foreach (FileInfo fi in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    sourceDirSize += fi.Length;
                }

                var taskCopy = Task.Run(() =>
                {
                    Directory.Move(sourceDir, GlobalHelper.Paths.PrefabsFolder);
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

            GlobalHelper.UpdateStatus?.Invoke(this, "Deleting downloads...", 0);
            Directory.Delete(unzipPath, true);
            File.Delete(GlobalHelper.Paths.PrefabsZipFile);
            GlobalHelper.UpdateStatus?.Invoke(this, "Downloads are deleted", 100);
        }
    }
}
