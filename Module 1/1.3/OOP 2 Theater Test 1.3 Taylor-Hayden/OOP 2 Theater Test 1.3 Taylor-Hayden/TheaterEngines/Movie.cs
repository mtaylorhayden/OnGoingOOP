using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterEngine
{
    /// <summary>
    /// The class which is used to represent a theater.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// The indicator of whether or not the movie is 3D.
        /// </summary>
        private bool is3d;

        /// <summary>
        /// The MPAA rating of the movie.
        /// </summary>
        private string rating;

        /// <summary>
        /// The runtime of the movie (in minutes).
        /// </summary>
        private int runtime;

        /// <summary>
        /// The title of the movie.
        /// </summary>
        private string title;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="is3d"></param>
        /// <param name="rating"></param>
        /// <param name="runtime"></param>
        /// <param name="title"></param>
        public Movie(bool is3d, string rating, int runtime, string title)
        {
            this.is3d = is3d;
            this.rating = rating;
            this.runtime = runtime;
            this.title = title;

        }

        /// <summary>
        /// Gets and sets the is3d field.
        /// </summary>
        public bool Is3d
        {
            get
            {
                return this.is3d;
            }
            set
            {
                value = this.is3d;
            }
        }
        /// <summary>
        /// Gets and sets the rating for the movie.
        /// </summary>
        public string Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                value = this.rating;
            }
        }

        /// <summary>
        /// Gets and sets the runtime for the movie.
        /// </summary>
        public int RunTime
        {
            get
            {
                return this.runtime;
            }
            set
            {
                value = this.runtime;
            }
        }

        /// <summary>
        /// Gets and sets the title for the movie.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                value = this.title;
            }
        }

        /// <summary>
        /// The overriden to string method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{this.Title}, {this.Rating}, {this.RunTime}");
        }
    }
}