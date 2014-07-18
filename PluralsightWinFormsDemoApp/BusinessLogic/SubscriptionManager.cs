using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PluralsightWinFormsDemoApp
{
    class SubscriptionManager
    {
        private readonly string file;

        public SubscriptionManager(string file)
        {
            this.file = file;
        }

        public List<Podcast> LoadPodcasts()
        {
            List<Podcast> podcasts;
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
                podcasts = defaultFeeds.Select(f => new Podcast() { SubscriptionUrl = f, Id = Guid.NewGuid() }).ToList();
            }
            return podcasts;
        }

        public void Save(List<Podcast> podcasts)
        {
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create(file))
            {
                serializer.Serialize(s, podcasts);
            }
        }
    }
}
