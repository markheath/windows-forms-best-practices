using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal class SystemInformationService : ISystemInformationService
    {
        public bool IsHighContrastColourScheme { get { return SystemInformation.HighContrast; } }
    }
}