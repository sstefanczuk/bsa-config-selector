using System;
using System.Reflection;

namespace BSA.ConfigSelector.ConsoleApp
{
    internal class App
    {
        private static string Version = GetAppVersion();
        private readonly AppContext _context;

        public App(string definedConfigsPath, string currentConfigPath, string configFileName)
        {
            _context = new AppContext(definedConfigsPath, currentConfigPath, configFileName);
        }

        public void Run()
        {
            ConsoleHelper.Initialize();

            while (true)
            {
                DisplayAppState();
                ProcessUserRequest();
            }
        }

        private void DisplayAppState()
        {
            Console.Clear();

            ConsoleHelper.DisplayHeader(Version);
            ConsoleHelper.DisplayCurrentConfigSection(_context.CurrentConfig);

            Console.SetCursorPosition(0, 12);
            _context.CurrentState.DisplayState();

            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            ConsoleHelper.WriteHorizontalLine();
            Console.Write("[Enter] - change config          [Arrows] - navigate");
        }

        private void ProcessUserRequest()
        {
            var pressedKey = Console.ReadKey();
            _context.CurrentState.HandleKeyPressed(pressedKey);
        }

        private static string GetAppVersion()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;

            return string.Format("{0}.{1}", version.Major, version.Minor);
        }
    }
}
