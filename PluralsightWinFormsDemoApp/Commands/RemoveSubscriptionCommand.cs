using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp
{
    class RemoveSubscriptionCommand : CommandBase
    {
        private readonly ISubscriptionView subscriptionView;
        private readonly ISubscriptionManager subscriptionManager;
        private readonly IPodcastPlayer player;

        public RemoveSubscriptionCommand(ISubscriptionView subscriptionView, ISubscriptionManager subscriptionManager)
        {
            this.subscriptionView = subscriptionView;
            this.subscriptionManager = subscriptionManager;
            Icon = IconResources.play_icon_32;
            ToolTip = "Play";
        }

        public override void Execute()
        {
            var pod = subscriptionView.SelectedNode.Tag as Podcast;
            if (pod != null)
            {
                subscriptionManager.RemoveSubscription(pod);
                subscriptionView.RemoveNode(pod.Id.ToString());
                Utils.SelectFirstEpisode(subscriptionView, subscriptionManager);
            }
        }
    }
}