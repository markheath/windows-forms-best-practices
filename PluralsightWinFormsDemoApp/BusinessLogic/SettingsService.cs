using PluralsightWinFormsDemoApp.Properties;

namespace PluralsightWinFormsDemoApp
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

    internal interface ISettingsService
    {
        bool FirstRun { get; set; }
        void Save();
    }

}