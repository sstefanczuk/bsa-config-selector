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

        public abstract void HandleKeyPressed(ConsoleKeyInfo pressedKey);

        public abstract void DisplayState();
    }
}
