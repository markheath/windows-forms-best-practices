using PluralsightWinFormsDemoApp.Properties;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal class SettingsService : ISettingsService
    {
        public bool FirstRun
        {
            get { return Settings.Default.FirstRun; }
            set { Settings.Default.FirstRun = value; }
        }

        public void Save()
        {
            Settings.Default.Save();
        }
    }
}