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
            this.DialogResult = DialogResult.OK;
        }
    }
}
