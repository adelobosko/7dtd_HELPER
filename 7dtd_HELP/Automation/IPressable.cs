using System;

namespace _7dtd_HELP.Automation
{
    public interface IPressable
    {
        string KeysCombination { get; set; }
        Action PressAction { get; set; }
        void PressEvent();
    }
}