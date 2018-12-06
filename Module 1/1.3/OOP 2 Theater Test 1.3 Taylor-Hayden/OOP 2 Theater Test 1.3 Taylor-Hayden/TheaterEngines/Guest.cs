using ConcessionItems;
using Stands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterEngine
{
    /// <summary>
    /// The class used to represent a guest.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// 
        /// </summary>
        private int age;

        /// <summary>
        /// 
        /// </summary>
        private List<ConcessionItem> concessionItems;

        /// <summary>
        /// 
        /// </summary>
        private string desiredMovieTitle;

        /// <summary>
        /// 
        /// </summary>
        private List<Movie> moviesSeen;

        /// <summary>
        /// 
        /// </summary>
        private string preferredSodaFlavor;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        private Wallet wallet;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="age"></param>
        /// <param name="desiredMovieTitle"></param>
        /// <param name="preferredSodaFlavor"></param>
        /// <param name="wallet"></param>
        public Guest(int age, string desiredMovieTitle, string preferredSodaFlavor, Wallet wallet)
        {
            this.age = age;
            this.desiredMovieTitle = desiredMovieTitle;
            this.preferredSodaFlavor = preferredSodaFlavor;
            this.wallet = wallet;
            this.concessionItems = new List<ConcessionItem>();
            this.moviesSeen = new List<Movie>();
        }

        /// <summary>
        /// Gets and sets the age of the guest.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        /// <summary>
        /// Gets and sets the title of the movie.
        /// </summary>
        public string DesiredMovieTitle
        {
            get
            {
                return this.desiredMovieTitle;
            }
            set
            {
                this.desiredMovieTitle = value;
            }
        }

        /// <summary>
        /// Gets the guest money balanace.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.wallet.MoneyBalance;
            }
        }

        /// <summary>
        /// Gets and sets the soda flavor preference.
        /// </summary>
        public string PreferredSodaFlavor
        {
            get
            {
                return this.preferredSodaFlavor;
            }
            set
            {
                this.preferredSodaFlavor = value;
            }
        }

        /// <summary>
        /// Gets the guest wallet.
        /// </summary>
        //public Wallet Wallet
        //{
        //    get
        //    {
        //        return this.wallet;
        //    }
        //}

        ///// <summary>
        ///// The movie the guest wants to see.
        ///// </summary>
        ///// <param name="movie"></param>
        //public void AddMovieSeen(Movie movie)
        //{

        //}

        ///// <summary>
        ///// Sells the guest concessions.
        ///// </summary>
        ///// <param name="popcornStand"></param>
        ///// <param name="sodaCupStand"></param>
        ///// <param name="sodaStand"></param>
        //public void BuyConcessions(PopcornStand popcornStand, SodaCupStand sodaCupStand, SodaStand sodaStand)
        //{

        //}

        /// <summary>
        /// Lets the guest buy popcorn.
        /// </summary>
        /// <param name="popcorn"></param>
        /// <returns></returns>
        private Popcorn BuyPopcorn(PopcornStand popcorn)
        {
            Popcorn pCorn = new Popcorn();

            return pCorn;
        }

        /// <summary>
        /// Sells the guest soda.
        /// </summary>
        /// <param name="sodaCupStand"></param>
        /// <param name="soda"></param>
        /// <returns></returns>
        private SodaCup BuySoda(SodaCupStand sodaCupStand, SodaStand soda)
        {
            return null;
        }

        /// <summary>
        /// Fills the guest's soda.
        /// </summary>
        /// <param name="sodaCup"></param>
        /// <param name="sodaStand"></param>
        private void FillSoda(SodaCup sodaCup, SodaStand sodaStand)
        {

        }

        /// <summary>
        /// The to string method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{this.Age}, {this.DesiredMovieTitle}");
            //return ToString() + this.Age + this.DesiredMovieTitle;
        }
    }
}
