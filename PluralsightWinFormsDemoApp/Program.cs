using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Commands;
using PluralsightWinFormsDemoApp.Presenters;

namespace PluralsightWinFormsDemoApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var episodeView = new EpisodeView();
            var subscriptionView = new SubscriptionView();
            var podcastView = new PodcastView();

            var podcastPlayer = new PodcastPlayer();
            var podcastLoader = new PodcastLoader();
            var settingsService = new SettingsService();
            var subscriptionManager = new SubscriptionManager("subscriptions.xml");
            var messageBoxDisplayService = new MessageBoxDisplayService();
            var systemInformationService = new SystemInformationService();
            var newSubscriptionService = new NewSubscriptionService();

            var commands = new IToolbarCommand[]
            {
                new AddSubscriptionCommand(subscriptionView,
                    messageBoxDisplayService, newSubscriptionService, podcastLoader, subscriptionManager),
                new RemoveSubscriptionCommand(subscriptionView, subscriptionManager),
                new PlayCommand(podcastPlayer),
                new PauseCommand(podcastPlayer),
                new StopCommand(podcastPlayer),
                new FavouriteCommand(subscriptionView),
                new SettingsCommand(),
            };
            var mainForm = new MainForm(episodeView, subscriptionView, podcastView, commands);

            var ep = new EpisodePresenter(episodeView, podcastPlayer);
            var sp = new SubscriptionPresenter(subscriptionView, podcastPlayer);
            var pp = new PodcastPresenter(podcastView);

            var presenter = new MainFormPresenter(mainForm,
                podcastLoader,
                subscriptionManager,
                podcastPlayer,
                messageBoxDisplayService,
                settingsService,
                systemInformationService,
                commands);
            Application.Run(mainForm);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n" +
                "{0}\r\n" +
                "Please contact support.",
                ((Exception)e.ExceptionObject).Message);

            Console.WriteLine("ERROR {0}: {1}",
                DateTimeOffset.Now, e.ExceptionObject);

            MessageBox.Show(message, "Unexpected Error");

        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n" +
              "{0}\r\n" +
              "Please contact support.",
                e.Exception.Message);

            Console.WriteLine("ERROR {0}: {1}",
                DateTimeOffset.Now, e.Exception);

            MessageBox.Show(message, "Unexpected Error");
        }
    }
}
