using System;

namespace PluralsightWinFormsDemoApp.Views
{
    public interface IEpisodeView
    {
        string Description { set; }
        string Title { set; }
        string PublicationDate { set; }
        int Rating { get; set; }
        string Notes { get; set; }
        string Tags { get; set; }
        void SetPeaks(float[] peaks);
        int PositionInSeconds { get; set; }
        event EventHandler PositionChanged;
        event EventHandler<NoteArgs> NoteCreated;
    }
}