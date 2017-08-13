using System;
using BSA.ConfigSelector.Domain;

namespace BSA.ConfigSelector.ConsoleApp
{
    internal static class ConsoleHelper
    {
        private const int Indent = 3;

        public static void Initialize()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
        }

        public static void DisplayHeader(string version)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteHorizontalLine();
            Console.WriteLine("                             BSA Config Selector " + version);
            WriteHorizontalLine();
            RestoreForegroundColor();
        }

        public static void DisplayCurrentConfigSection(CurrentConfig currentConfig)
        {
            Console.WriteLine("Current config:");
            Console.CursorLeft += Indent;
            Console.WriteLine(currentConfig.Config.FilePath);

            string database = string.Format("{0} ({1})",
                currentConfig.Config.ConnectionString.Database,
                currentConfig.Config.ConnectionString.Server);
            WriteProperty("Database", database, Indent);
            if (currentConfig.Config.ApiUrl != null)
            {
                WriteProperty("Api URL", currentConfig.Config.ApiUrl.ToString(), Indent);
            }
            WriteHorizontalLine();
        }

        public static void DisplayWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            RestoreForegroundColor();
        }

        public static void WriteProperty(string propertyName, string value, int indent = 0)
        {
            Console.CursorLeft += indent;
            Console.Write(propertyName + ": ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(value);
            RestoreForegroundColor();
            Console.WriteLine();
        }

        public static void WriteHorizontalLine()
        {
            Console.WriteLine("________________________________________________________________________________");
        }

        private static void RestoreForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
