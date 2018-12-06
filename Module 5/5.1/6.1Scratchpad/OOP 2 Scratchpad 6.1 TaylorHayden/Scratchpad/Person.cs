using System;

namespace Scratchpad
{
    /// <summary>
    /// The class which is used to represent a person.
    /// </summary>
    public class Person : IObserver
    {
        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the salary of the person.
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets the number of news items the person has read.
        /// </summary>
        public int NumberOfNewsItemsRead { get; private set; }

        /// <summary>
        /// Reads the current news.
        /// </summary>
        /// <param name="news">The news to read.</param>
        public void ReadNews(string news)
        {
            Console.WriteLine(string.Format("{0} read: {1}", this.FirstName, news));

            this.NumberOfNewsItemsRead++;
        }

        /// <summary>
        /// Called to notify person of an updated news item.
        /// </summary>
        /// <param name="subject"> The news provided.</param>
        public void Update(ISubject subject)
        {
            // Cast subject as a publisher.
            Publisher publisher = subject as Publisher;

            Console.WriteLine(publisher.News);

            this.NumberOfNewsItemsRead++;
        }
    }
}