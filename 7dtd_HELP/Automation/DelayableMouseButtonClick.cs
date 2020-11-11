using System;
using System.Threading;

namespace _7dtd_HELP.Automation
{
    public class DelayableMouseButtonClick : IPressable, IDelayable
    {
        private bool _isTimerEnabled;

        public int CurrentDelayState { get; set; }
        public int Delay { get; set; }
        public string KeysCombination { get; set; }
        public Timer Timer { get; set; }

        
        public bool IsTimerEnabled
        {
            get => _isTimerEnabled;
            set
            {
                CurrentDelayState = 0;
                _isTimerEnabled = value;
            }
        }

        public Action PressAction { get; set; }

        public DelayableMouseButtonClick(Action pressAction, int delay, string keysCombination)
        {
            KeysCombination = keysCombination;
            Delay = delay;
            PressAction = pressAction;
            Timer = new Timer(TimerTick, PressAction, 20, 20);
        }

        public void TimerTick(object state)
        {
            if (!IsTimerEnabled)
            {
                return;
            }

            CurrentDelayState++;
            if (CurrentDelayState < Delay)
            {
                return;
            }

            PressEvent();

            CurrentDelayState = 0;
        }

        public void PressEvent()
        {
            PressAction.Invoke();
        }
    }
}