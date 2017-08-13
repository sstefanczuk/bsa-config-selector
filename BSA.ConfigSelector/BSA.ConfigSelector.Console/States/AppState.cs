using BSA.ConfigSelector.ConsoleApp.Extensions;
using System;

namespace BSA.ConfigSelector.ConsoleApp.States
{
    internal abstract class AppState
    {
        protected AppContext _context;

        protected AppContext Context { get { return _context; } }

        public void SetContext(AppContext context)
        {
            _context = context;
        }

        public void HandleKeyPressed(ConsoleKeyInfo pressedKey)
        {
            if(pressedKey.IsEscape())
            {
                Environment.Exit(0);
            }

            OnKeyPressed(pressedKey);
        }

        public abstract void DisplayState();

        protected virtual void OnKeyPressed(ConsoleKeyInfo pressedKey) { }
    }
}
