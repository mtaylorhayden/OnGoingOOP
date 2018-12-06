using MoneyCollectors;
using Stands;
using System.Collections.Generic;

namespace TheaterEngine
{
    /// <summary>
    /// The class which is used to represent a theater.
    /// </summary>
    public class Theater
    {
        /// <summary>
        /// The guest for the theater.
        /// </summary>
        private Guest guest;

        /// <summary>
        /// The list of movies.
        /// </summary>
        private List<Movie> movies;

        /// <summary>
        /// 
        /// </summary>
        private List<Guest> guests;

        /// <summary>
        /// The name of the theater.
        /// </summary>
        private string name;

        /// <summary>
        /// The popcorn stand.
        /// </summary>
        private PopcornStand popcornStand;

        /// <summary>
        /// The theater's screening room 1.
        /// </summary>
        private ScreeningRoom screeningRoom;

        /// <summary>
        /// The stand that sells soda.
        /// </summary>
        private SodaStand sodaStand; 
        
        /// <summary>
        /// The stand for the soda cups.
        /// </summary>
        private SodaCupStand sodaCupStand;

        private IMoneyCollector moneyBox;

        /// <summary>
        /// Initializes a new instance of the theater class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="screeningRoom"></param>
        /// <param name="moneyBoxInitialMoneyBalance"></param>
        /// <param name="popcornPrice"></param>
        /// <param name="sodaCupPrice"></param>
        public Theater(SodaStand sodaStand, SodaCupStand sodacupStand, PopcornStand popcornStand, string name, ScreeningRoom screeningRoom, decimal moneyBoxInitialMoneyBalance, decimal popcornPrice, decimal sodaCupPrice)
        {
            this.sodaStand = sodaStand;

            this.sodaCupStand = sodacupStand;

            this.popcornStand = popcornStand;

            this.name = name;

            this.screeningRoom = screeningRoom;

            this.guests = new List<Guest>();

            this.movies = new List<Movie>();
        }

        public static Theater NewTheater()
        {
            MoneyCollector moneyBox = new MoneyCollector(450);

            SodaStand sodaStand = new SodaStand();

            SodaCupStand sodaCupStand = new SodaCupStand(4, moneyBox);

            PopcornStand popcornStand = new PopcornStand(5, moneyBox);

            Theater marcusTheater = new Theater(sodaStand, sodaCupStand, popcornStand, "Marcus Theater", new ScreeningRoom(true, 78), 450, 5, 4);

            Wallet wallet = new Wallet("Salmon", 12);

            Guest guest;

            guest =  new Guest(26, "The Godfather", "PrDepper", wallet);

            marcusTheater.guests.Add(guest);

            wallet = new Wallet("Brown", 15);

            guest = new Guest(34, "August Rush", "Dolt", wallet);

            marcusTheater.guests.Add(guest);

            Movie movie = new Movie(false, "R", 175, "The God Father");

            marcusTheater.movies.Add(movie);

            movie = new Movie(true, "PG", 95, "Despicable Me");

            marcusTheater.movies.Add(movie);

            

            return marcusTheater;
        }

        /// <summary>
        /// Gets the average movies runtime.
        /// </summary>
        public double AverageMovieRuntime
        {
            get
            {
                double totalRunTime = 0;

                foreach (Movie m in movies)
                {

                    totalRunTime = m.RunTime;

                    totalRunTime /= movies.Count;

                    break;
                }

                return totalRunTime;
            }
        }

        /// <summary>
        /// Gets or sets the name of the theater.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets or sets screening room 1.
        /// </summary>
        public ScreeningRoom ScreeningRoom
        {
            get
            {
                return this.screeningRoom;
            }
        }

        /// <summary>
        /// Gets the popcorn stand.
        /// </summary>
        public PopcornStand PopcornStand
        {
            get
            {
                return this.popcornStand;
            }
        }

        /// <summary>
        /// Gets the soda cup stand.
        /// </summary>
        public SodaCupStand SodaCupStand
        {
            get
            {
                return this.sodaCupStand;
            }
        }

        /// <summary>
        /// Gets the soda stand.
        /// </summary>
        public SodaStand SodaStand
        {
            get
            {
                return this.sodaStand;
            }
        }

        /// <summary>
        /// Adds the guest.
        /// </summary>
        /// <param name="guest"></param>
        public void AddGuest(Guest guest)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        public void AddMovie(Movie movie)
        {

        }
    }
}