using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7dtd_HELP.Logger
{
    class Logger
    {
        private Control _formControl;
        public bool IsClearLogForEveryLog { get; set; }
        public string AdditionFragmentOfEveryLog { get; set; }

        public Logger(Control formControl, bool isClearLogForEveryLog = false)
        {
            _formControl = formControl;
            AdditionFragmentOfEveryLog = $"{Environment.NewLine}{Environment.NewLine}";
            IsClearLogForEveryLog = isClearLogForEveryLog;
        }

        public void Log(string text)
        {
            if (_formControl == null)
            {
                return;
            }

            if (IsClearLogForEveryLog)
            {
                Clear();
            }

            _formControl.Text += $"{text}{AdditionFragmentOfEveryLog}";
        }

        public void Log(string data, string text)
        {
           var logText = $"{data}{AdditionFragmentOfEveryLog}{text}{AdditionFragmentOfEveryLog}";

           Log(logText);
        }

        public void Clear()
        {
            if (_formControl == null)
            {
                return;
            }

            _formControl.Text = "";
        }
    }
}
