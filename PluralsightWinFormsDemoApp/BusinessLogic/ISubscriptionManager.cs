using System.Collections.Generic;
using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    internal interface ISubscriptionManager
    {
        void Save();

        void AddSubscription(Podcast podcast);
        void RemoveSubscription(Podcast podcast);
        IEnumerable<Podcast> Subscriptions { get; }
    }
}