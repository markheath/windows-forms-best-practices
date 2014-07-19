using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
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
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
