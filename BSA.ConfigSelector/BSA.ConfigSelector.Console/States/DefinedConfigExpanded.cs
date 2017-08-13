using System;
using BSA.ConfigSelector.ConsoleApp.Extensions;
using BSA.ConfigSelector.Domain;

namespace BSA.ConfigSelector.ConsoleApp.States
{
    internal class DefinedConfigExpanded : DefinedConfigSelected
    {
        public DefinedConfigExpanded(int selectedIndex) : base(selectedIndex)
        {
            SelectedIndex = selectedIndex;
        }

        protected override void OnKeyPressed(ConsoleKeyInfo pressedKey)
        {
            base.OnKeyPressed(pressedKey);

            if (pressedKey.IsKeyLeft())
            {
                Context.ChangeState(new DefinedConfigSelected(SelectedIndex));
            }
        }

        protected override void DisplayAdditionalConfigInfo(DefinedConfig config, int index)
        {
            if (index != SelectedIndex)
            {
                return;
            }

            string database = string.Format("{0} ({1})",
                config.Config.ConnectionString.Database,
                config.Config.ConnectionString.Server);
            ConsoleHelper.WriteProperty("Database", database, 10);

            if (config.Config.ApiUrl != null)
            {
                ConsoleHelper.WriteProperty("Api URL", config.Config.ApiUrl.ToString(), 10);
            }
        }
    }
}
