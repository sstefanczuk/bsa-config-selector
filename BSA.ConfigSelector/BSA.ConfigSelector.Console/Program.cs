using System;
using System.Configuration;
using System.IO;

namespace BSA.ConfigSelector.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = ConfigurationManager.AppSettings;

            string definedConfigsPath = settings["DefinedConfigsDirectoryPath"];
            string currentConfigAppDataSubdirectory = settings["CurrentConfigAppDataSubdirectory"];
            string configFileName = settings["ConfigFileName"];

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string currentConfigPath = Path.Combine(appDataPath, currentConfigAppDataSubdirectory, configFileName);

            var application = new App(definedConfigsPath, currentConfigPath, configFileName);
            application.Run();
        }
    }
}
