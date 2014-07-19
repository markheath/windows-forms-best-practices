using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    interface IPodcastLoader
    {
        Task UpdatePodcast(Podcast podcast);
    }

    class PodcastLoader : IPodcastLoader
    {
        public async Task UpdatePodcast(Podcast podcast)
        {
            var doc = new XmlDocument();
            await Task.Run(() => doc.Load(podcast.SubscriptionUrl));

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            podcast.Title = channel["title"].InnerText;
            podcast.Link = channel["link"].InnerText;
            podcast.Description = channel["description"].InnerText;
            if (podcast.Episodes == null) podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {
                var guid = item["guid"].InnerText;
                var episode = podcast.Episodes.FirstOrDefault(e => e.Guid == guid);
                if (episode == null)
                {
                    episode = new Episode() { Guid = guid, IsNew = true };
                    episode.Title = item["title"].InnerText;
                    episode.PubDate = item["pubDate"].InnerText;
                    var xmlElement = item["description"];
                    if (xmlElement != null) episode.Description = xmlElement.InnerText;
                    var element = item["link"];
                    if (element != null) episode.Link = element.InnerText;
                    var enclosureElement = item["enclosure"];
                    if (enclosureElement != null) episode.AudioFile = enclosureElement.Attributes["url"].InnerText;
                    podcast.Episodes.Add(episode);
                }
            }
        }
    }
}
