using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static _7dtd_HELP.Win32;

namespace _7dtd_HELP
{
    public static class InputHelper
    {
        public static void Send(INPUT[] inputArr)
        {
            SendInput((uint)inputArr.Length, inputArr, INPUT.Size);
        }

    public static INPUT GetKeyboardInput(ScanCodeShort keyScanCodeShort, VirtualKeyShort virtualKeyShort,
            KEYEVENTF keyEventF)
        {
            return new INPUT()
            {
                type = InputType.KEYBOARD,
                U = new InputUnion()
                {
                    ki = new KEYBDINPUT()
                    {
                        wScan = keyScanCodeShort,
                        wVk = virtualKeyShort,
                        dwFlags = keyEventF
                    }
                }
            };
        }


        public static INPUT GetMouseInput(MOUSEEVENTF mouseEventF, int dx = 0, int dy = 0, int mouseData = 0,
            uint time = 1, uint dwExtraInfo = 1)
        {
            return new INPUT()
            {
                type = InputType.MOUSE,
                U = new InputUnion()
                {
                    mi = new MOUSEINPUT()
                    {
                        dx = dx,
                        dy = dy,
                        mouseData = mouseData,
                        dwFlags = mouseEventF,
                        time = time,
                        dwExtraInfo = (UIntPtr) dwExtraInfo
                    }
                }
            };
        }
    }
}
