using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class NoteForm : Form
    {
        public NoteForm()
        {
            InitializeComponent();
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
            
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            DialogResult = DialogResult.OK;
            Close();
        }

        public string Note { get { return textBoxNote.Text;  }}
    }
}
