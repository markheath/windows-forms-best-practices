using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp
{
    class StopCommand : CommandBase
    {
        private readonly IPodcastPlayer player;

        public StopCommand(IPodcastPlayer player)
        {
            this.player = player;
            Icon = IconResources.stop_icon_32;
            ToolTip = "Stop";
        }

        public override void Execute()
        {
            player.Stop();
        }
    }
}