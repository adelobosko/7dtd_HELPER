using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _7dtd_HELP.WinApi.User32;

namespace _7dtd_HELP
{
    class SnapShotService
    {
        private static Image _screen;

        public static Image TakeWindowScreen(int sleepDuration = 1500, string processName = "7DaysToDie")
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                SetForegroundWindow(processes[0].MainWindowHandle);
            }

            if (sleepDuration > 50)
            {
                Thread.Sleep(sleepDuration);
            }

            return TakeScreenShot();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sleepDuration">if value highest then 50 then create Thread.Sleep(sleepDuration)</param>
        /// <returns></returns>
        public static Image TakeScreenShot(int sleepDuration = 100, bool onlyCurrentWindow = true)
        {
            var listInputs = new List<Input>()
            {
                InputHelper.GetKeyboardInput(ScanCodeShort.SNAPSHOT, VirtualKeyShort.SNAPSHOT, KeyEventF.KEYDOWN),
                InputHelper.GetKeyboardInput(ScanCodeShort.SNAPSHOT, VirtualKeyShort.SNAPSHOT, KeyEventF.KEYUP)
            };

            if (onlyCurrentWindow)
            {
                listInputs.Insert(0, InputHelper.GetKeyboardInput(ScanCodeShort.MENU, VirtualKeyShort.MENU, KeyEventF.KEYDOWN));
                listInputs.Add(InputHelper.GetKeyboardInput(ScanCodeShort.MENU, VirtualKeyShort.MENU, KeyEventF.KEYUP));
            }
            
            var tSnapshot = listInputs.ToArray();

            InputHelper.Send(tSnapshot);
            InputHelper.Send(tSnapshot);
            InputHelper.Send(tSnapshot);

            if (sleepDuration > 50)
            {
                Thread.Sleep(sleepDuration);
            }
            var image = Clipboard.GetImage();
            var screenBounds = Screen.PrimaryScreen.Bounds;
            return image ?? new Bitmap(screenBounds.Width, screenBounds.Height);
        }
    }
}
