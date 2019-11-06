using System.Collections.Generic;

namespace _7dtd_HELP
{
    public static class InputSet
    {
        public static Win32.INPUT[] LeftMouseButton = new List<Win32.INPUT>()
        {
            InputHelper.GetMouseInput(Win32.MOUSEEVENTF.LEFTDOWN),
            InputHelper.GetMouseInput(Win32.MOUSEEVENTF.LEFTUP)
        }.ToArray();

        public static Win32.INPUT[] RightMouseButton = new List<Win32.INPUT>()
        {
            InputHelper.GetMouseInput(Win32.MOUSEEVENTF.RIGHTDOWN),
            InputHelper.GetMouseInput(Win32.MOUSEEVENTF.RIGHTUP)
        }.ToArray();

        public static Win32.INPUT[] Paste = new List<Win32.INPUT>()
        {
            InputHelper.GetKeyboardInput(Win32.ScanCodeShort.CONTROL, Win32.VirtualKeyShort.CONTROL, Win32.KEYEVENTF.KEYDOWN),
            InputHelper.GetKeyboardInput(Win32.ScanCodeShort.KEY_V, Win32.VirtualKeyShort.KEY_V, Win32.KEYEVENTF.KEYDOWN),
            InputHelper.GetKeyboardInput(Win32.ScanCodeShort.KEY_V, Win32.VirtualKeyShort.KEY_V, Win32.KEYEVENTF.KEYUP),
            InputHelper.GetKeyboardInput(Win32.ScanCodeShort.CONTROL, Win32.VirtualKeyShort.CONTROL, Win32.KEYEVENTF.KEYUP)
        }.ToArray();


        public static Win32.INPUT[] Enter = new List<Win32.INPUT>()
        {
            InputHelper.GetKeyboardInput(Win32.ScanCodeShort.RETURN, Win32.VirtualKeyShort.RETURN, Win32.KEYEVENTF.KEYDOWN),
            InputHelper.GetKeyboardInput(Win32.ScanCodeShort.RETURN, Win32.VirtualKeyShort.RETURN, Win32.KEYEVENTF.KEYUP)
        }.ToArray();
    }
}