using System;

namespace BSA.ConfigSelector.ConsoleApp.States
{
    internal class NoDefinedConfigs : AppState
    {
        public override void HandleKeyPressed(ConsoleKeyInfo pressedKey)
        {
        }

        public override void DisplayState()
        {
            ConsoleHelper.DisplayWarning("Cannot find any defined config in: \n\r" + Context.DefinedConfigs.DirectoryPath);
        }
    }
}
