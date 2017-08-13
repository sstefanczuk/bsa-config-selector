using System.Linq;
using BSA.ConfigSelector.ConsoleApp.States;
using BSA.ConfigSelector.Domain;

namespace BSA.ConfigSelector.ConsoleApp
{
    internal class AppContext
    {
        private readonly DefinedConfigs _definedConfigs;
        private readonly CurrentConfig _currentConfig;

        public AppContext(string definedConfigsPath, string currentConfigPath, string configFileName)
        {
            _definedConfigs = new DefinedConfigs(definedConfigsPath, configFileName);
            _currentConfig = new CurrentConfig(currentConfigPath);
            InitializeState();
        }

        public AppState CurrentState { get; private set; }
        public DefinedConfigs DefinedConfigs { get { return _definedConfigs; } }
        public CurrentConfig CurrentConfig { get { return _currentConfig; } }

        public void ChangeState(AppState state)
        {
            state.SetContext(this);
            CurrentState = state;
        }

        private void InitializeState()
        {
            if (!_definedConfigs.Any())
            {
                ChangeState(new NoDefinedConfigs());
            }

            ChangeState(new DefinedConfigSelected(0));
        }
    }
}
