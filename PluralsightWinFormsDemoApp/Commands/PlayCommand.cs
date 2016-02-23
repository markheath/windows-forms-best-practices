using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Events;

namespace PluralsightWinFormsDemoApp.Commands
{
    class PlayCommand : CommandBase
    {
        private readonly IPodcastPlayer player;

        public PlayCommand(IPodcastPlayer player)
        {
            this.player = player;
            Icon = IconResources.play_icon_32;
            ToolTip = "Play";
            ShortcutKey = Keys.Space | Keys.Control;
            IsEnabled = false;
            EventAggregator.Instance.Subscribe<EpisodeSelectedMessage>(e => IsEnabled = true);
            EventAggregator.Instance.Subscribe<PodcastSelectedMessage>(e => IsEnabled = false);
        }

        public override void Execute()
        {
            player.Play();
        }
    }
}