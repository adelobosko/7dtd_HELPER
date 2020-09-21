using System.Collections.Generic;
using static _7dtd_HELP.WinApi.User32;

namespace _7dtd_HELP
{
    public static class InputSet
    {
        public static Input[] LeftMouseButton = new List<Input>()
        {
            InputHelper.GetMouseInput(MouseEventF.LEFTDOWN),
            InputHelper.GetMouseInput(MouseEventF.LEFTUP)
        }.ToArray();

        public static Input[] RightMouseButton = new List<Input>()
        {
            InputHelper.GetMouseInput(MouseEventF.RIGHTDOWN),
            InputHelper.GetMouseInput(MouseEventF.RIGHTUP)
        }.ToArray();

        public static Input[] Paste = new List<Input>()
        {
            InputHelper.GetKeyboardInput(ScanCodeShort.CONTROL, VirtualKeyShort.CONTROL, KeyEventF.KEYDOWN),
            InputHelper.GetKeyboardInput(ScanCodeShort.KEY_V, VirtualKeyShort.KEY_V, KeyEventF.KEYDOWN),
            InputHelper.GetKeyboardInput(ScanCodeShort.KEY_V, VirtualKeyShort.KEY_V, KeyEventF.KEYUP),
            InputHelper.GetKeyboardInput(ScanCodeShort.CONTROL, VirtualKeyShort.CONTROL, KeyEventF.KEYUP)
        }.ToArray();


        public static Input[] Enter = new List<Input>()
        {
            InputHelper.GetKeyboardInput(ScanCodeShort.RETURN, VirtualKeyShort.RETURN, KeyEventF.KEYDOWN),
            InputHelper.GetKeyboardInput(ScanCodeShort.RETURN, VirtualKeyShort.RETURN, KeyEventF.KEYUP)
        }.ToArray();
    }
}