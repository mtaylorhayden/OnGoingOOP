using System;
using System.Collections.Generic;

namespace Scratchpad
{
    /// <summary>
    /// The class which is used to represent a news publisher.
    /// </summary>
    public class Publisher : ISubject
    {
        /// <summary>
        /// The list of observers (i.e subscribers).
        /// </summary>
        private List<IObserver> observers = new List<IObserver>();

        /// <summary>
        /// Gets or sets a multi cast action that people can subscribe to.
        /// </summary>
        public Action<string> BroadcastNewsAction { get; set; }

        /// <summary>
        /// Gets the current news.
        /// </summary>
        public string News { get; private set; }

        public void NotifyObservers()
        {
            foreach (IObserver o in this.observers)
            {
                o.Update(this);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            // Add the observer to the list of observers.
            this.observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            // Remove the observer from the list.
            this.observers.Remove(observer);
        }

        public void UpdateNews(string news)
        {
            this.News = news;
        }

        public void BroadCastNewsToObservers(string news)
        {
            this.UpdateNews(news);

            this.NotifyObservers();
        }

        public void BroadCastNews(string news)
        {
            this.UpdateNews(news);

            // If there are subscribers, notify them.
            if (this.BroadcastNewsAction != null)
            {
                // Calls all method that were plugged into the delegate (action).
                this.BroadcastNewsAction(this.News);
            }
        }
    }
}