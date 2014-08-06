using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    class SubscriptionManager : ISubscriptionManager
    {
        private readonly string file;
        private List<Podcast> podcasts;
            
        public SubscriptionManager(string file)
        {
            this.file = file;
            LoadPodcasts();
        }

        private void LoadPodcasts()
        {
            if (File.Exists(file))
            {
                var serializer = new XmlSerializer(typeof(List<Podcast>));
                using (var s = File.OpenRead("subscriptions.xml"))
                {
                    podcasts = (List<Podcast>)serializer.Deserialize(s);
                }
            }
            else
            {
                var defaultFeeds = new[]
                {
                    "http://hwpod.libsyn.com/rss",
                    "http://feeds.feedburner.com/herdingcode",
                    "http://www.pwop.com/feed.aspx?show=dotnetrocks&amp;filetype=master",
                    "http://feeds.feedburner.com/JesseLibertyYapcast",
                    "http://feeds.feedburner.com/HanselminutesCompleteMP3"
                };
                podcasts = defaultFeeds.Select(f => new Podcast { SubscriptionUrl = f, Id = Guid.NewGuid() }).ToList();
            }
        }

        public void Save()
        {
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create(file))
            {
                serializer.Serialize(s, podcasts);
            }
        }


        public void AddSubscription(Podcast podcast)
        {
            podcasts.Add(podcast);
        }

        public void RemoveSubscription(Podcast podcast)
        {
            podcasts.Remove(podcast);
        }

        public IEnumerable<Podcast> Subscriptions { get { return podcasts; } }
    }
}
