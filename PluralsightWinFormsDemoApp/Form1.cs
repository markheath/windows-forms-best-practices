using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PluralsightWinFormsDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var doc = new XmlDocument();
            doc.Load("http://hwpod.libsyn.com/rss");

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            var title = channel["title"].InnerText;
            var link = channel["link"].InnerText;
            var description = channel["description"].InnerText;

            foreach (var item in items)
            {                
                var podTitle = item["title"].InnerText;
                var poddescription = item["description"].InnerText;
                var podLink = item["link"].InnerText;
                //this.items.Add(rssItem);
                listBox2.Items.Add(podTitle);
            }

            // Rss20FeedFormatter didn't work
        }
    }
}
