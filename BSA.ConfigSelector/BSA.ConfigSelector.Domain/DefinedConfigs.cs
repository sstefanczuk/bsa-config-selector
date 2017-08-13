using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BSA.ConfigSelector.Domain
{
    public class DefinedConfigs : IEnumerable<DefinedConfig>
    {
        private readonly string _directoryPath;
        private readonly IEnumerable<DefinedConfig> _configs;

        public DefinedConfigs(string directoryPath, string configFileName)
        {
            _directoryPath = directoryPath;
            _configs = DetDefinedConfigs(directoryPath, configFileName);
        }

        public string DirectoryPath
        {
            get { return _directoryPath; }
        }

        public IEnumerator<DefinedConfig> GetEnumerator()
        {
            return _configs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<DefinedConfig> DetDefinedConfigs(string directoryPath, string configFileName)
        {
            return new DirectoryInfo(directoryPath)
                .GetDirectories()
                .Select(subDirectory => new DefinedConfig(Path.Combine(subDirectory.FullName, configFileName)));
        }
    }
}
