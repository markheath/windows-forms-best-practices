using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class WpfEpisodeViewHost : UserControl, IEpisodeView
    {
        public WpfEpisodeViewHost()
        {
            InitializeComponent();
        }

        public string Description
        {
            set
            {
                wpfEpisodeView1.DescriptionWebBrowser.NavigateToString(value);
            }
        }

        public string Title
        {
            set { wpfEpisodeView1.TitleLabel.Content = value; }
        }

        public string PublicationDate
        {
            set { wpfEpisodeView1.PublicationDate.Content = value; }
        }

        public int Rating
        {
            get { return (int)wpfEpisodeView1.RatingSlider.Value; }
            set { wpfEpisodeView1.RatingSlider.Value = value; }
        }

        public string Notes
        {
            get { return wpfEpisodeView1.TextBoxNotes.Text; }
            set { wpfEpisodeView1.TextBoxNotes.Text = value; }
        }

        public string Tags
        {
            get { return wpfEpisodeView1.TextBoxTags.Text; }
            set { wpfEpisodeView1.TextBoxTags.Text = value; }
        }

        public void SetPeaks(float[] peaks)
        {
            wpfEpisodeView1.WaveformControl.SetPeaks(peaks);
        }

        public int PositionInSeconds
        {
            get { return wpfEpisodeView1.WaveformControl.PositionInSeconds; }
            set { wpfEpisodeView1.WaveformControl.PositionInSeconds = value; }
        }

        public event EventHandler PositionChanged
        {
            add { wpfEpisodeView1.WaveformControl.PositionUpdated += value; }
            remove { wpfEpisodeView1.WaveformControl.PositionUpdated -= value; }
        }

        public event EventHandler<NoteArgs> NoteCreated
        {
            add { wpfEpisodeView1.WaveformControl.NoteCreated += value; }
            remove { wpfEpisodeView1.WaveformControl.NoteCreated -= value; }
        }
    }
}
