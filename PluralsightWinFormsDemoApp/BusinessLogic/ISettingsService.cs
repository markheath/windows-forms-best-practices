namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal interface ISettingsService
    {
        bool FirstRun { get; set; }
        void Save();
    }
}