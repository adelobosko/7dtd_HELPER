using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _7dtd_HELP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Contains("-console") || args.Contains("-c"))
            {
                AllocConsole();
            }
            if (args.Contains("-log"))
            {
            }
            if (args.Contains("-help") || args.Contains("-h"))
            {
                var argumentsDictionary = new Dictionary<string, int>();
                var argumentsNames = Enum.GetNames(typeof(GlobalHelper.ProgramParams.Argument));
                var argumentsValues = Enum.GetValues(typeof(GlobalHelper.ProgramParams.Argument)).Cast<int>().ToList();
                for (var i = 0; i < argumentsNames.Length; i++)
                {
                    argumentsDictionary.Add(argumentsNames[i], argumentsValues[i]);
                }

                var distinctValuesList = argumentsDictionary
                    .Select(e => e.Value).Distinct().ToList();

                AllocConsole();
                foreach (var value in distinctValuesList)
                {
                    var sameArguments = argumentsDictionary.Where(e => e.Value == value)
                        .Select(e => $"-{e.Key.ToLower()}")
                        .Aggregate((current, next) => $"{current}, {next}");
                    Console.WriteLine($"{sameArguments} ==> {GlobalHelper.ProgramParams.GetArgumentDefinition((GlobalHelper.ProgramParams.Argument)value)}");
                }
            }
            Application.Run(new HelperForm());
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
