using System;
using System.Diagnostics;
using System.Windows.Forms;
using NAudio.Wave;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    class PodcastPlayer : IDisposable
    {
        private WaveOutEvent player;
        private Episode currentEpisode;

        public void UnloadEpisode()
        {
            if (player != null) player.Dispose();
            player = null;

        }

        public void Dispose()
        {
            if (player != null)
            {
                player.Dispose();
            }            
        }

        public void Play()
        {
            if (player == null)
            {
                if (currentEpisode.AudioFile == null)
                {
                    MessageBox.Show("No audio file download provided");
                    Process.Start(currentEpisode.AudioFile ?? currentEpisode.Link);
                    return;
                }
                try
                {
                    player = new WaveOutEvent();
                    player.Init(new MediaFoundationReader(currentEpisode.AudioFile));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving podcast audio");
                    player = null;
                }

            }
            if (player != null)
            {
                player.Play();
            }
        }

        public void Pause()
        {
            if (player != null) player.Pause();
        }

        public void Stop()
        {
            if (player != null) player.Stop();
        }

        public void LoadEpisode(Episode selectedEpisode)
        {
            currentEpisode = selectedEpisode;
        }
    }
}
