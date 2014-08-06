using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class EpisodeView : UserControl, IEpisodeView
    {
        public EpisodeView()
        {
            InitializeComponent();
            toolTip1.SetToolTip(textBoxTags, 
                "Enter tags for this podcast, comma separated");
            textBoxTags.HelpRequested += textBoxTags_HelpRequested;
        }

        void textBoxTags_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(TextResources.TagsHelp);
        }

        public string Description
        {
            get { return webBrowserDescription.DocumentText; }
            set { webBrowserDescription.DocumentText = value; }
        }

        public string Title
        {
            get { return labelEpisodeTitle.Text; }
            set { labelEpisodeTitle.Text = value; }
        }

        public string PublicationDate
        {
            get { return labelPublicationDate.Text; }
            set { labelPublicationDate.Text = value; }
        }

        public int Rating
        {
            get { return (int)numericUpDownRating.Value; } 
            set { numericUpDownRating.Value = value; }
        }

        public string Notes
        {
            get { return textBoxNotes.Text; }
            set { textBoxNotes.Text = value; }
        }

        public string Tags { 
            get { return textBoxTags.Text; }
            set { textBoxTags.Text = value; } 
        }

        public void SetPeaks(float[] peaks)
        {
            waveformViewer1.SetPeaks(peaks);
        }

        public int PositionInSeconds
        {
            get { return waveformViewer1.PositionInSeconds; }
            set { waveformViewer1.PositionInSeconds = value; }
        }

        public event EventHandler PositionChanged
        {
            add { waveformViewer1.PositionChanged += value; }
            remove { waveformViewer1.PositionChanged -= value; }
        }

        public event EventHandler<NoteArgs> NoteCreated
        {
            add { waveformViewer1.NoteCreated += value; }
            remove { waveformViewer1.NoteCreated -= value; }
        }
    }
}
