using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class ToolBarView : UserControl, IToolbarView
    {
        public ToolBarView()
        {
            InitializeComponent();
        }

        public event EventHandler AddPodcastClicked
        {
            add { buttonAddSubscription.Click += value; }
            remove { buttonAddSubscription.Click -= value; }
        }

        public event EventHandler RemovePodcastClicked
        {
            add { buttonRemoveSubscription.Click += value; }
            remove { buttonRemoveSubscription.Click -= value; }
        }

        public event EventHandler StopClicked
        {
            add { buttonStop.Click += value; }
            remove { buttonStop.Click -= value; }
        }

        public event EventHandler PlayClicked
        {
            add { buttonPlay.Click += value; }
            remove { buttonPlay.Click -= value; }
        }

        public event EventHandler PauseClicked
        {
            add { buttonPause.Click += value; }
            remove { buttonPause.Click -= value; }
        }

        public event EventHandler FavouriteChanged
        {
            add { buttonFavourite.CheckStateChanged += value; }
            remove { buttonFavourite.CheckStateChanged -= value; }
        }

        public bool EpisodeIsFavourite
        {
            get { return buttonFavourite.Checked; }
            set { buttonFavourite.Checked = value; }
        }

        public Image FavouriteImage
        {
            set { buttonFavourite.Image = value; }
        }
    }
}
