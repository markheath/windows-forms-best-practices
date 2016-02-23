using System.Linq;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Events;
using PluralsightWinFormsDemoApp.Model;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp.Commands
{
    class RemoveSubscriptionCommand : CommandBase
    {
        private readonly ISubscriptionView subscriptionView;
        private readonly ISubscriptionManager subscriptionManager;

        public RemoveSubscriptionCommand(ISubscriptionView subscriptionView, ISubscriptionManager subscriptionManager)
        {
            this.subscriptionView = subscriptionView;
            this.subscriptionManager = subscriptionManager;
            Icon = IconResources.remove_icon_32;
            ToolTip = "Play";
        }

        public override void Execute()
        {
            var pod = subscriptionView.SelectedNode.Tag as Podcast;
            if (pod != null)
            {
                subscriptionManager.RemoveSubscription(pod);
                subscriptionView.RemoveNode(pod.Id.ToString());
                EventAggregator.Instance.Publish(new PodcastLoadCompleteMessage(subscriptionManager.Subscriptions.ToArray()));
            }
        }
    }
}