using System.Net;
using System.Xml;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Events;
using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Commands
{
    class AddSubscriptionCommand : CommandBase
    {
        private readonly IMessageBoxDisplayService messageBoxDisplayService;
        private readonly INewSubscriptionService newSubscriptionService;
        private readonly IPodcastLoader podcastLoader;
        private readonly ISubscriptionManager subscriptionManager;

        public AddSubscriptionCommand(
            IMessageBoxDisplayService messageBoxDisplayService,
            INewSubscriptionService newSubscriptionService,
            IPodcastLoader podcastLoader,
            ISubscriptionManager subscriptionManager)
        {
            this.messageBoxDisplayService = messageBoxDisplayService;
            this.newSubscriptionService = newSubscriptionService;
            this.podcastLoader = podcastLoader;
            this.subscriptionManager = subscriptionManager;
            Icon = IconResources.add_icon_32;
            ToolTip = "Add Subscription";
        }

        public async override void Execute()
        {
            var newPodcastUrl = newSubscriptionService.GetSubscriptionUrl();
            if (newPodcastUrl != null)
            {
                var pod = new Podcast { SubscriptionUrl = newPodcastUrl };
                try
                {
                    await podcastLoader.UpdatePodcast(pod);
                    subscriptionManager.AddSubscription(pod);
                    EventAggregator.Instance.Publish(new PodcastLoadedMessage(pod));
                }
                catch (WebException)
                {
                    messageBoxDisplayService.Show("Sorry, that podcast could not be found. Please check the URL");
                }
                catch (XmlException)
                {
                    messageBoxDisplayService.Show("Sorry, that URL is not a podcast feed");
                }
            }
        }
    }
}