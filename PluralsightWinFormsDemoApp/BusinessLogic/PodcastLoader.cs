using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using PluralsightWinFormsDemoApp.Model;

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
            var rss = doc["rss"];
            if (rss == null) throw new InvalidDataException("No rss node found");
            var channel = rss["channel"];
            if (channel == null) throw new InvalidDataException("No channel node found");
            var items = channel.GetElementsByTagName("item");
            
            podcast.Title = channel.GetInnerText("title");
            podcast.Link = channel.GetInnerText("link");
            podcast.Description = channel.GetInnerText("description");
            if (podcast.Episodes == null) podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {
                var guid = item.GetInnerText("guid");
                var episode = podcast.Episodes.FirstOrDefault(e => e.Guid == guid);
                if (episode == null)
                {
                    episode = new Episode
                              {
                                  Guid = guid,
                                  IsNew = true,
                                  Title = item.GetInnerText("title"),
                                  PubDate = item.GetInnerText("pubDate"),
                                  Description = item.GetInnerText("description"),
                                  Link = item.GetInnerText("link")
                              };
                    var enclosureElement = item["enclosure"];
                    if (enclosureElement != null) episode.AudioFile = enclosureElement.Attributes["url"].InnerText;
                    podcast.Episodes.Add(episode);
                }
            }
        }
    }

    static class XmlElementExtensions
    {
        public static string GetInnerText(this XmlNode element, string attributeName)
        {
            var attribute = element[attributeName];
            return attribute != null ? attribute.InnerText : null;
        }
    }
}
