using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class EpisodeView : UserControl
    {
        public EpisodeView()
        {
            InitializeComponent();
            toolTip1.SetToolTip(textBoxTags, "Enter tags for this podcast, separated with commas\r\ne.g. Sport, Football");
            errorProvider1.SetError(numericUpDownRating, "must be greater than 0");
        }
    }
}
