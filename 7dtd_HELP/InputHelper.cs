using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static _7dtd_HELP.WinApi.User32;

namespace _7dtd_HELP
{
    public static class InputHelper
    {
        public static void Send(Input[] inputArr)
        {
            SendInput((uint)inputArr.Length, inputArr, Input.Size);
        }

    public static Input GetKeyboardInput(ScanCodeShort keyScanCodeShort, VirtualKeyShort virtualKeyShort,
            KeyEventF keyEventF)
        {
            return new Input()
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


        public static Input GetMouseInput(MouseEventF mouseEventF, int dx = 0, int dy = 0, int mouseData = 0,
            uint time = 1, uint dwExtraInfo = 1)
        {
            return new Input()
            {
                type = InputType.MOUSE,
                U = new InputUnion()
                {
                    mi = new MouseInput()
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
