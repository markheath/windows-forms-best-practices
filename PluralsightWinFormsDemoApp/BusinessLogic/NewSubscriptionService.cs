using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal class NewSubscriptionService : INewSubscriptionService
    {
        public string GetSubscriptionUrl()
        {
            var form = new NewPodcastForm();
            return form.ShowDialog() == DialogResult.OK ? form.PodcastUrl : null;
        }
    }
}