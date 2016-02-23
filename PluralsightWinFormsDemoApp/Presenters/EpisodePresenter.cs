using System;
using System.Linq;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Events;
using PluralsightWinFormsDemoApp.Model;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp.Presenters
{
    class EpisodePresenter
    {
        private readonly IEpisodeView episodeView;
        private readonly IPodcastPlayer podcastPlayer;
        private Episode currentEpisode;

        public EpisodePresenter(IEpisodeView episodeView, IPodcastPlayer podcastPlayer)
        {
            this.episodeView = episodeView;
            this.podcastPlayer = podcastPlayer;
            episodeView.Title = "";
            episodeView.PublicationDate = "";
            this.episodeView.NoteCreated += EpisodeViewOnNoteCreated;
            episodeView.PositionChanged += (s, a) => podcastPlayer.PositionInSeconds = episodeView.PositionInSeconds;

            var timer = new Timer {Interval = 100};
            timer.Tick += TimerOnTick;
            timer.Start();

            EventAggregator.Instance.Subscribe<EpisodeSelectedMessage>(OnEpisodeSelected);
            EventAggregator.Instance.Subscribe<PodcastSelectedMessage>(OnPodcastSelected);
            EventAggregator.Instance.Subscribe<ApplicationClosingMessage>(m => SaveEpisode());
            EventAggregator.Instance.Subscribe<PeaksAvailableMessage>(OnPeaksAvailable);
        }

        private void OnPeaksAvailable(PeaksAvailableMessage obj)
        {
            if (obj.Episode == currentEpisode)
            {
                episodeView.SetPeaks(obj.Episode.Peaks);
            }
        }

        private void OnPodcastSelected(PodcastSelectedMessage obj)
        {
            SaveEpisode();
            currentEpisode = null;
        }

        private void EpisodeViewOnNoteCreated(object sender, NoteArgs noteArgs)
        {
            currentEpisode.Notes = String.Format(episodeView.Notes + "{0:hh\\:mm\\:ss}: {1}\r\n",
                noteArgs.Position, noteArgs.Note);
            episodeView.Notes = currentEpisode.Notes;
        }

        private async void OnEpisodeSelected(EpisodeSelectedMessage episodeSelected)
        {
            SaveEpisode();
            currentEpisode = episodeSelected.Episode;

            episodeView.Title = currentEpisode.Title;
            episodeView.PublicationDate = currentEpisode.PubDate;
            episodeView.Description = currentEpisode.Description;
            //toolbarView.EpisodeIsFavourite = currentEpisode.IsFavourite; now handled by the IsFavouriteCommand
            currentEpisode.IsNew = false;
            episodeView.Rating = currentEpisode.Rating;
            episodeView.Tags = String.Join(",", currentEpisode.Tags ?? new string[0]);
            episodeView.Notes = currentEpisode.Notes ?? "";
            episodeView.PositionInSeconds = 0;
            podcastPlayer.LoadEpisode(currentEpisode);
            if (currentEpisode.Peaks == null || currentEpisode.Peaks.Length == 0)
            {
                episodeView.SetPeaks(null);
                await podcastPlayer.LoadPeaksAsync();
            }
            else
            {
                episodeView.SetPeaks(currentEpisode.Peaks); 
            }
        }

        private void SaveEpisode()
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