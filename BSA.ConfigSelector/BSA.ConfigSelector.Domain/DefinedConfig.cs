namespace BSA.ConfigSelector.Domain
{
    public class DefinedConfig
    {
        private readonly Config _config;
        private readonly string _name;

        public DefinedConfig(string filePath)
        {
            _config = new Config(filePath);
            _name = GetLastDirectoryName(filePath);
        }

        public string Name
        {
            get { return _name; }
        }

        public Config Config
        {
            get { return _config; }
        }

        private string GetLastDirectoryName(string filePath)
        {
            var pathParts = filePath.Split('\\');

            return pathParts[pathParts.Length - 2];
        }
    }
}
