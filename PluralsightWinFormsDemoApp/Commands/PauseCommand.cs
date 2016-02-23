using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp.Commands
{
    class PauseCommand : CommandBase
    {
        private readonly IPodcastPlayer player;

        public PauseCommand(IPodcastPlayer player)
        {
            this.player = player;
            Icon = IconResources.pause_icon_32;
            ToolTip = "Pause";
        }

        public override void Execute()
        {
            player.Play();
        }
    }
}