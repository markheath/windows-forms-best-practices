using System;
using System.Threading.Tasks;
using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal interface IPodcastPlayer : IDisposable
    {
        void UnloadEpisode();
        void Play();
        void Pause();
        void Stop();
        void LoadEpisode(Episode selectedEpisode);
        Task LoadPeaksAsync();
        int PositionInSeconds { get; set; }
        bool IsPlaying { get; }
    }
}