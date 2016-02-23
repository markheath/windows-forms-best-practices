using System;

namespace PluralsightWinFormsDemoApp.Views
{
    public class NoteArgs : EventArgs
    {
        public NoteArgs(string note, TimeSpan position)
        {
            Position = position;
            Note = note;
        }

        public string Note { get; private set; }
        public TimeSpan Position { get; private set; }
    }
}