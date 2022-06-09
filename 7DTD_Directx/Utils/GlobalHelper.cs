using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7DTD_Directx.Utils
{
    public static class GlobalHelper
    {
        //public static Config Config = new Config();

        //public static WebHelper WebHelper { get; set; }
        public delegate void OnStatusChanged(object myObject, string message, int percentage);
        public static OnStatusChanged UpdateStatus { get; set; }
        public static OnStatusChanged UpdateSubStatus { get; set; }

        //public static MapPoint MyCoordinates = new MapPoint()
        //{

        //};

        public static class ProgramParams
        {
            public enum Argument
            {
                HELP = 0,
                H = 0,
                CONSOLE = 1,
                C = 1,
                LOG
            }

            public static string GetArgumentDefinition(Argument argument)
            {
                switch(argument)
                {
                    case Argument.HELP:
                    {
                        return "Writes an information about all commands";
                    }
                    case Argument.CONSOLE:
                    {
                        return "Opens a console";
                    }
                    case Argument.LOG:
                    {
                        return "Enables a logging";
                    }
                    default:
                        return $"Unknown argument {argument}";
                }
            }
        }
    }
}
