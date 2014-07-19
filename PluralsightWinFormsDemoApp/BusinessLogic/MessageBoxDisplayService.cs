using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    internal class MessageBoxDisplayService : IMessageBoxDisplayService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }

    internal interface IMessageBoxDisplayService
    {
        void Show(string message);
    }
}