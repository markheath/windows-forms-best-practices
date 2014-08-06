using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class NoteForm : Form
    {
        public NoteForm()
        {
            InitializeComponent();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            DialogResult = DialogResult.OK;
            Close();
        }

        public string Note { get { return textBoxNote.Text; } }
    }
}
