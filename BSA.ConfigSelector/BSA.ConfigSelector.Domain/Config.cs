using System;
using System.Xml;

namespace BSA.ConfigSelector.Domain
{
    public class Config
    {
        private readonly string _filePath;
        private readonly ConnectionString _connectionString;
        private readonly ApiUrl _apiUrl;

        public string FilePath { get { return _filePath; } }
        public ConnectionString ConnectionString { get { return _connectionString; } }
        public ApiUrl ApiUrl { get { return _apiUrl; } }

        public Config(string filePath)
        {
            _filePath = filePath;

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            if (doc.DocumentElement == null)
            {
                throw new InvalidOperationException("The configuration file contains no root for the document.");
            }

            var connectionStringNodes = doc.DocumentElement.SelectNodes("/configuration/connectionStrings/add");
            if (connectionStringNodes == null)
            {
                throw new InvalidOperationException("The configuration file contains no connection string.");
            }

            foreach (XmlNode node in connectionStringNodes)
            {
                if (node.Attributes == null)
                {
                    continue;
                }

                var name = node.Attributes["name"].Value;
                if (name == "main")
                {
                    _connectionString = new ConnectionString(node.Attributes["connectionString"].Value);
                }
            }

            var appSettingsNodes = doc.DocumentElement.SelectNodes("/configuration/appSettings/add");
            if (appSettingsNodes == null)
            {
                return;
            }

            foreach (XmlNode node in appSettingsNodes)
            {
                if (node.Attributes == null)
                {
                    continue;
                }

                var key = node.Attributes["key"].Value;
                if (key == "apiUrl")
                {
                    _apiUrl = new ApiUrl(node.Attributes["value"].Value);
                }
            }
        }
    }
}
