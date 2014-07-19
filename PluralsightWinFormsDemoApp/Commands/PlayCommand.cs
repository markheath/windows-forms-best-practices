using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp
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
        }

        public override void Execute()
        {
            player.Play();
        }
    }
}