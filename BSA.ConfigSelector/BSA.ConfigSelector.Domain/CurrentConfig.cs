using System.IO;

namespace BSA.ConfigSelector.Domain
{
    public class CurrentConfig
    {
        public Config Config { get; private set; }

        public CurrentConfig(string filePath)
        {
            Config = new Config(filePath);
        }

        public void ChangeTo(Config newConfig)
        {
            string sourcePath = newConfig.FilePath;
            string destinationPath = Config.FilePath;

            File.Copy(sourcePath, destinationPath, true);

            Config = new Config(destinationPath);
        }
    }
}
