using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal class MessageBoxDisplayService : IMessageBoxDisplayService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}