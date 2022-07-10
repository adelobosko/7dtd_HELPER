using _7DTD_Directx.Domain;

namespace _7DTD_Directx.Utils
{
    public static class GlobalHelper
    {
        public static Config Config;

        //public static WebHelper WebHelper { get; set; }
        //public delegate void OnStatusChanged(object myObject, string message, int percentage);
        //public static OnStatusChanged UpdateStatus { get; set; }
        //public static OnStatusChanged UpdateSubStatus { get; set; }

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
                        return "Show all commands";
                    }
                    case Argument.CONSOLE:
                    {
                        return "Open a console";
                    }
                    case Argument.LOG:
                    {
                        return "Enable a logging";
                    }
                    default:
                        return $"Unknown argument {argument}";
                }
            }
        }
    }
}
