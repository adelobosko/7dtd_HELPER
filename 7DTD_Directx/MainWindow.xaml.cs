using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
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
        bool _isLmbPressed = false;
        bool _isRmbPressed = false;

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


        private void chooseMapFolderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            using(var commonOpenFileDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                InitialDirectory = Utils.GlobalHelper.Paths.MapsAppDataDirectory,
                EnsureFileExists = true,
                Title = "Choose a server's folder from SavesLocal."
            })
            {
                if(commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(commonOpenFileDialog.FileName))
                {
                    Map.MapProvider.TryLoadMapFromSaveLocalFolder(commonOpenFileDialog.FileName);
                }
            }            
        }
    }
}
