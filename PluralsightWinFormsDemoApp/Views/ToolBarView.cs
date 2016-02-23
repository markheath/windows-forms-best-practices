using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Commands;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class ToolBarView : UserControl, IToolbarView
    {
        public ToolBarView()
        {
            InitializeComponent();
        }

        public void SetCommands(IToolbarCommand[] commands)
        {
            toolStrip1.Items.Clear();
            foreach (var command in commands)
            {
                var button = new ToolStripButton();
                button.Text = command.ToolTip;
                button.Image = command.Icon;
                button.Enabled = command.IsEnabled;
                button.ImageScaling = ToolStripItemImageScaling.None;
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                var c = command; // create a closure around the command
                command.PropertyChanged += (o, s) => {
                    button.Text = c.ToolTip;
                    button.Image = c.Icon;
                    button.Enabled = c.IsEnabled;
                };
                button.Click += (o, s) => c.Execute();
                toolStrip1.Items.Add(button);
            }
        }
    }
}
