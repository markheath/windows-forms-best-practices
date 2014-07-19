using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public interface IToolbarCommand : INotifyPropertyChanged
    {
        void Execute();
        bool IsEnabled { get; set; }
        Image Icon { get; set; }
        string ToolTip { get; set; }
        Keys ShortcutKey { get; set; }
    }
}