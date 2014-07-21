using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using NAudio.Wave;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal interface IPodcastPlayer : IDisposable
    {
        void UnloadEpisode();
        void Play();
        void Pause();
        void Stop();
        void LoadEpisode(Episode selectedEpisode);
        Task<float[]> LoadPeaksAsync();
        int PositionMilliseconds { get; set; }
    }

    class PodcastPlayer : IPodcastPlayer
    {
        private WaveOutEvent player;
        private Episode currentEpisode;
        private MediaFoundationReader currentReader;

        public void UnloadEpisode()
        {
            if (player != null) player.Dispose();
            if (currentReader != null) currentReader.Dispose();
            player = null;
            currentReader = null;
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
                    currentReader = new MediaFoundationReader(currentEpisode.AudioFile);
                    player.Init(currentReader);

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

        public Task<float[]> LoadPeaksAsync()
        {
            return Task.Run(() =>
            {
                var peaks = new List<float>();
                using (var reader = new MediaFoundationReader(currentEpisode.AudioFile))
                {
                    var sampleProvider = reader.ToSampleProvider();
                    var sampleBuffer = new float[reader.WaveFormat.SampleRate*reader.WaveFormat.Channels/10];
                    int read;
                    do
                    {
                        read = sampleProvider.Read(sampleBuffer, 0, sampleBuffer.Length);
                        if (read > 0)
                        {
                            var max = sampleBuffer.Take(read).Select(Math.Abs).Max();
                            peaks.Add(max);                            
                        }
                    } while (read > 0);
                    return peaks.ToArray();
                }
            });
        }

        public int PositionMilliseconds
        {
            get
            {
                if (currentReader != null)
                    return (int)currentReader.CurrentTime.TotalMilliseconds;
                return 0;
            }
            set
            {
                if (currentReader != null)
                    currentReader.CurrentTime = TimeSpan.FromMilliseconds(value);
            }            
        }
    }
}
