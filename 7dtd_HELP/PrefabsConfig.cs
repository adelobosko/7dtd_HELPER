using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

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
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...", 25);

            if (File.Exists(GlobalHelper.Paths.PrefabsZipFile))
            {
                try
                {
                    File.Delete(GlobalHelper.Paths.PrefabsZipFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...", 50);

            if (Directory.Exists(GlobalHelper.Paths.UnzippedDirectory))
            {
                try
                {
                    Directory.Delete(GlobalHelper.Paths.UnzippedDirectory, true);
                }
                catch
                {
                    Thread.Sleep(2000);
                    Directory.Delete(GlobalHelper.Paths.UnzippedDirectory, true);
                }
            }
            GlobalHelper.UpdateStatus?.Invoke("Clearing prefabs cache", "Clearing prefabs cache...", 75);

            if (Directory.Exists(GlobalHelper.Paths.PrefabsDirectory))
            {
                try
                {
                    Directory.Delete(GlobalHelper.Paths.PrefabsDirectory, true);
                }
                catch
                {
                    Thread.Sleep(2000);
                    Directory.Delete(GlobalHelper.Paths.PrefabsDirectory, true);
                }
            }
            GlobalHelper.UpdateStatus?.Invoke("Prefabs cache is cleared", "Cache are cleared", 100);
        }

        public static void UnzipPrefabs()
        {
            GlobalHelper.UpdateStatus?.Invoke("Unzipping prefabs", "Prefabs unzipping...", 0);
            using (var zip = ZipFile.Read(GlobalHelper.Paths.PrefabsZipFile))
            {
                zip.FlattenFoldersOnExtract = true;
                zip.ExtractProgress += (sender, args) =>
                {
                    if (args.EventType == ZipProgressEventType.Extracting_EntryBytesWritten)
                    {
                        var percentage = args.BytesTransferred / (0.01 * args.TotalBytesToTransfer);
                        GlobalHelper.UpdateSubStatus?.Invoke("Unzipping prefabs",
                            $"{args.CurrentEntry.FileName} ({percentage:0.00})%", (int)percentage);
                    }
                    else if (args.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
                    {
                        if (args.EntriesTotal <= 0) return;

                        var globalPercent = args.EntriesExtracted / (0.01 * args.EntriesTotal);
                        GlobalHelper.UpdateStatus?.Invoke("Unzipping prefabs",
                            $"Prefabs unzipping... {args.EntriesExtracted} / {args.EntriesTotal} ({globalPercent:0.00}%)",
                            (int)globalPercent);
                    }
                };

                zip.ExtractSelectedEntries("name = *", "7dtd-map-master\\docs\\prefabs", GlobalHelper.Paths.PrefabsDirectory, ExtractExistingFileAction.OverwriteSilently);
            }

            GlobalHelper.UpdateStatus?.Invoke("Prefabs are unzipped", "Prefabs are unzipped", 100);
            GlobalHelper.UpdateSubStatus?.Invoke("", "", 0);
        }


        public static List<Prefab> ParsPrefabs()
        {
            var prefabs = new List<Prefab>();
            try
            {
                GlobalHelper.UpdateStatus?.Invoke("Parsing prefabs", "Parsing prefabs...", 0);
                var prefabsDirectoryInfo = new DirectoryInfo(GlobalHelper.Paths.PrefabsDirectory);
                var htmlFiles = prefabsDirectoryInfo.GetFiles("*.html", SearchOption.AllDirectories);
                for (var i = 0; i < htmlFiles.Length; i++)
                {
                    var blocks = Prefab.GetPrefabBlocksByHtml(htmlFiles[i].FullName);
                    var prefab = new Prefab()
                    {
                        FileName = htmlFiles[i].FullName,
                        Name = Path.GetFileNameWithoutExtension(htmlFiles[i].Name),
                        Blocks = new List<PrefabBlock>(blocks)
                    };
                    prefabs.Add(prefab);
                    var percentage = (i + 1) * 100.0 / htmlFiles.Length;
                    if (percentage > 0 && percentage < 100)
                        GlobalHelper.UpdateStatus?.Invoke($"Parsing prefabs {prefab.Name}", $"Parsing prefabs... ({percentage:0.00}%)", (int)percentage);
                }
                return prefabs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex);
                return prefabs;
            }
        }

        public void UpdatePrefabs()
        {
            ClearPrefabsCache();

            var downloadTask = GlobalHelper.WebHelper.DownloadFileAsync(prefabsUrl, GlobalHelper.Paths.PrefabsZipFile, "Prefabs downloading...");
            downloadTask.Wait();

            UnzipPrefabs();
            var prefabs = ParsPrefabs();
            Prefabs = new List<Prefab>(prefabs);
            LastUpdateTime = DateTime.Now;


            GlobalHelper.Config.Save();
            GlobalHelper.UpdateStatus?.Invoke("Prefabs is updated", "Prefabs is updated", 100);
            GlobalHelper.Config = Config.Load(GlobalHelper.Config);
            SystemSounds.Beep.Play();
            new Thread(() =>
            {
                Thread.Sleep(5000);
                GlobalHelper.UpdateStatus?.Invoke("", "", 0);
                GlobalHelper.UpdateSubStatus?.Invoke("", "", 0);
            }).Start();
        }
    }
}
