using System.Linq;

namespace BSA.ConfigSelector.Domain
{
    public class ConnectionString
    {
        private readonly string _content;
        private readonly string _server;
        private readonly string _database;

        public ConnectionString(string content)
        {
            _content = content;

            var parameters = _content
                .Split(';')
                .Where(p => p.Contains("="));

            foreach (string parameter in parameters)
            {
                var parameterParts = parameter.Split('=');
                string name = parameterParts[0];
                string value = parameterParts[1];
                if (name == "Data Source")
                {
                    _server = value;
                }

                if (name == "Initial Catalog")
                {
                    _database = value;
                }
            }
        }

        public string Server
        {
            get { return _server; }
        }

        public string Database
        {
            get { return _database; }
        }
    }
}
