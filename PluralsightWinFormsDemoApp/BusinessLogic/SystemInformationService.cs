using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    internal class SystemInformationService : ISystemInformationService
    {
        public bool IsHighContrastColourScheme { get { return SystemInformation.HighContrast; } }
    }

    internal interface ISystemInformationService
    {
        bool IsHighContrastColourScheme { get; }
    }
}