using System;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;
        event HelpEventHandler HelpRequested;
        event KeyEventHandler KeyUp;

        IEpisodeView EpisodeView { get; }
        IPodcastView PodcastView { get; }
        ISubscriptionView SubscriptionView { get; }
        IToolbarView ToolbarView { get; }

        Color BackColor { get; set; }

        void ShowEpisodeView();
        void ShowPodcastView();
    }
}