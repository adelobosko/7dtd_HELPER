using System.Threading;

namespace _7dtd_HELP.Automation
{
    public interface IDelayable
    {
        int CurrentDelayState { get; set; }
        int Delay { get; set; }
        bool IsTimerEnabled { get; set; }
        Timer Timer { get; set; }

        void TimerTick(object state);
    }
}