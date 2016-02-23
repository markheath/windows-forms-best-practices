using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Commands
{
    abstract class CommandBase : IToolbarCommand
    {
        private bool isEnabled;
        private Image icon;
        private string toolTip;
        public event PropertyChangedEventHandler PropertyChanged;

        protected CommandBase()
        {
            isEnabled = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Execute();

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }

        public Image Icon
        {
            get { return icon; }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        public string ToolTip
        {
            get { return toolTip; }
            set
            {
                if (toolTip != value)
                {
                    toolTip = value;
                    OnPropertyChanged("ToolTip");
                }
            }
        }

        public Keys ShortcutKey { get; set; }
    }
}