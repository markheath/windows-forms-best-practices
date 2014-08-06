using System;
using PluralsightWinFormsDemoApp.Model;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp.Commands
{
    class FavouriteCommand : CommandBase
    {
        private readonly ISubscriptionView subscriptionView;
        private Episode currentEpisode;

        public FavouriteCommand(ISubscriptionView subscriptionView)
        {
            this.subscriptionView = subscriptionView;
            Icon = IconResources.star_icon_32;
            ToolTip = "Favourite";
            subscriptionView.SelectionChanged += SubscriptionViewOnSelectionChanged;
        }

        private void SubscriptionViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            currentEpisode = subscriptionView.SelectedNode.Tag as Episode;            
            SetIcon();
        }

        public override void Execute()
        {
            if (currentEpisode != null)
            {
                currentEpisode.IsFavourite = !currentEpisode.IsFavourite;
                SetIcon();
            }
        }

        private void SetIcon()
        {            
            Icon = currentEpisode != null && currentEpisode.IsFavourite
                ? IconResources.star_icon_fill_32
                : IconResources.star_icon_32;
        }
    }
}