using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class NewPodcastForm : Form
    {
        public NewPodcastForm()
        {
            InitializeComponent();
        }
        public string PodcastUrl { get { return textBoxUrl.Text; } }

        private void OnButtonOkClick(object sender, EventArgs e)
        {
            Uri uri;
            if (!Uri.TryCreate(PodcastUrl, UriKind.Absolute, out uri))
            {
                errorProvider1.SetError(textBoxUrl, "Must be a valid URL starting with http://");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
