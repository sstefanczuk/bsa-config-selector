using System;
using System.Linq;
using BSA.ConfigSelector.ConsoleApp.Extensions;
using BSA.ConfigSelector.Domain;

namespace BSA.ConfigSelector.ConsoleApp.States
{
    internal class DefinedConfigSelected : AppState
    {
        protected int SelectedIndex;

        public DefinedConfigSelected(int selectedIndex)
        {
            SelectedIndex = selectedIndex;
        }

        public override void HandleKeyPressed(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.IsKeyUp())
            {
                DecrementIndex();
            }

            if (pressedKey.IsKeyDown())
            {
                IncrementIndex();
            }

            if (pressedKey.IsKeyRight())
            {
                Context.ChangeState(new DefinedConfigExpanded(SelectedIndex));
            }

            if (pressedKey.IsEnter())
            {
                ChangeConfig();
            }
        }

        public override void DisplayState()
        {
            Console.WriteLine("Change current config to:");

            int index = 0;
            foreach (DefinedConfig config in Context.DefinedConfigs)
            {
                Console.CursorLeft += 3;
                DisplayConfigInfo(config, index);
                index++;
            }
        }

        protected virtual void DisplayConfigInfo(DefinedConfig config, int index)
        {
            if (index == SelectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            string prefix = index == SelectedIndex ? "--> " : "    ";

            Console.WriteLine(prefix + config.Name);
            Console.ForegroundColor = ConsoleColor.White;

            DisplayAdditionalConfigInfo(config, index);
        }

        protected virtual void DisplayAdditionalConfigInfo(DefinedConfig config, int index)
        {
        }

        private void DecrementIndex()
        {
            SelectedIndex--;
            if (SelectedIndex < 0)
            {
                SelectedIndex = Context.DefinedConfigs.Count() - 1;
            }
        }

        private void IncrementIndex()
        {
            SelectedIndex++;
            if (SelectedIndex >= Context.DefinedConfigs.Count())
            {
                SelectedIndex = 0;
            }
        }

        private void ChangeConfig()
        {
            var selectedConfig = Context.DefinedConfigs.ElementAt(SelectedIndex);
            Context.CurrentConfig.ChangeTo(selectedConfig.Config);
        }
    }
}
