namespace BSA.ConfigSelector.ConsoleApp.States
{
    internal class NoDefinedConfigs : AppState
    {
        public override void DisplayState()
        {
            ConsoleHelper.DisplayWarning("Cannot find any defined config in: \n\r" + Context.DefinedConfigs.DirectoryPath);
        }
    }
}
