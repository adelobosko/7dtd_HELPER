using _7DTD_Directx.Database;
using _7DTD_Directx.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace _7DTD_Directx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _isCtrlPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.LeftCtrl)
            {
                _isCtrlPressed = true;
            }
        }


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.LeftCtrl)
            {
                _isCtrlPressed = false;
            }
        }





        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void MapWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }


        private void MapWindow_MouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
            if(Mouse.LeftButton == MouseButtonState.Pressed && Mouse.RightButton == MouseButtonState.Pressed)
            {
                var handle = new WindowInteropHelper(this).Handle;
                Task.Run(() =>
                {
                    Utils.WinApi.User32.ReleaseCapture();
                    Utils.WinApi.User32.SendMessage(handle, Utils.WinApi.User32.WM_NCLBUTTONDOWN, Utils.WinApi.User32.HT_CAPTION, 0);
                });
            }
        }


        private async void chooseMapFolderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            using(var commonOpenFileDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                InitialDirectory = Utils.Paths.MapsAppDataDirectory,
                EnsureFileExists = true,
                Title = "Choose a server's folder from SavesLocal."
            })
            {
                if(commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(commonOpenFileDialog.FileName))
                {
                    using(var db = new DatabaseContext())
                    {
                        var map = await Map.LoadMapFromFolder(commonOpenFileDialog.FileName);
                        db.Maps.Add(map);

                        var spawnPoint = new SpawnPoint(map, 1, 2, 3)
                        {
                            ShouldShow = true
                        };

                        var prefabInfo = new PrefabInfo("test", 1, 200, 30);

                        prefabInfo.AvaliableBlocks.AddRange(new AvailablePrefabBlock[]
                        {
                        new AvailablePrefabBlock(prefabInfo, new Block("Test_1"), 5),
                        new AvailablePrefabBlock(prefabInfo, new Block("Test_2"), 3),
                        new AvailablePrefabBlock(prefabInfo, new Block("Test_12"), 5)
                        });

                        var prefabPoint = new PrefabPoint(map, prefabInfo, 1, 2, 3)
                        {
                            ShouldShow = true
                        };

                        map.SpawnPoints.Add(spawnPoint);
                        map.PrefabPoints.Add(prefabPoint);

                        Utils.GlobalHelper.Config.CurrentMap = map;
                        await db.SaveChangesAsync();
                    }
                }
            }
        }

        private async void MapWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using(var db = new DatabaseContext())
            {
                var config = await db.Configs.FirstOrDefaultAsync();
                if(config == null)
                {
                    config = new Config();
                    db.Configs.Add(config);
                    await db.SaveChangesAsync();
                }

                Utils.GlobalHelper.Config = config;
                var availableMaps = await db.Maps.ToListAsync();
                Utils.GlobalHelper.Config.AvailableMaps = availableMaps;
            }
        }
    }
}
