using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp.Presenters
{
    class EpisodePresenter
    {
        private readonly IEpisodeView episodeView;
        private readonly IPodcastPlayer podcastPlayer;
        private readonly Timer timer;
        private Episode currentEpisode;

        public EpisodePresenter(IEpisodeView episodeView, IPodcastPlayer podcastPlayer)
        {

            this.episodeView = episodeView;
            this.podcastPlayer = podcastPlayer;
            episodeView.Title = "";
            episodeView.PublicationDate = "";
            this.episodeView.NoteCreated += EpisodeViewOnNoteCreated;
            episodeView.PositionChanged += (s, a) => podcastPlayer.PositionInSeconds = episodeView.PositionInSeconds;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void EpisodeViewOnNoteCreated(object sender, NoteArgs noteArgs)
        {
            currentEpisode.Notes = String.Format(episodeView.Notes + "{0:hh\\:mm\\:ss}: {1}\r\n",
                noteArgs.Position, noteArgs.Note);
            episodeView.Notes = currentEpisode.Notes;
        }

        public async Task OnEpisodeSelected(Episode selectedEpisode)
        {
            this.currentEpisode = selectedEpisode;

            episodeView.Title = currentEpisode.Title;
            episodeView.PublicationDate = currentEpisode.PubDate;
            episodeView.Description = currentEpisode.Description;
            //toolbarView.EpisodeIsFavourite = currentEpisode.IsFavourite; now handled by the IsFavouriteCommand
            currentEpisode.IsNew = false;
            episodeView.Rating = currentEpisode.Rating;
            episodeView.Tags = String.Join(",", currentEpisode.Tags ?? new string[0]);
            episodeView.Notes = currentEpisode.Notes ?? "";
            podcastPlayer.LoadEpisode(currentEpisode);
            if (currentEpisode.Peaks == null || currentEpisode.Peaks.Length == 0)
            {
                episodeView.SetPeaks(null);
                currentEpisode.Peaks = await podcastPlayer.LoadPeaksAsync();
            }
            episodeView.SetPeaks(currentEpisode.Peaks); 
        }

        public void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.Tags.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = episodeView.Rating;
            currentEpisode.Notes = episodeView.Notes;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (podcastPlayer != null && podcastPlayer.IsPlaying)
            {
                episodeView.PositionInSeconds = podcastPlayer.PositionInSeconds;
            }
        }
    }
}