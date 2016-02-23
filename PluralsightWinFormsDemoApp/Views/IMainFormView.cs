using System;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;
        event HelpEventHandler HelpRequested;
        event KeyEventHandler KeyUp;

        Color BackColor { get; set; }

        void ShowEpisodeView();
        void ShowPodcastView();
    }
}