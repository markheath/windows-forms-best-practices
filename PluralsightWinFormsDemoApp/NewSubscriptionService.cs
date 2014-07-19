using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    internal class NewSubscriptionService : INewSubscriptionService
    {
        public string GetSubscriptionUrl()
        {
            var form = new NewPodcastForm();
            return form.ShowDialog() == DialogResult.OK ? form.PodcastUrl : null;
        }
    }

    internal interface INewSubscriptionService
    {
        string GetSubscriptionUrl();
    }
}