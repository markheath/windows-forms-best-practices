using PluralsightWinFormsDemoApp.Commands;

namespace PluralsightWinFormsDemoApp.Views
{
    public interface IToolbarView
    {
        void SetCommands(IToolbarCommand[] commands);
    }
}