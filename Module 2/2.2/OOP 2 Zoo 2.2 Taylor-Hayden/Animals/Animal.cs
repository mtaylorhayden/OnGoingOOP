using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Documents;
using CagedItems;
using Foods;
using People;
using Utilities;
using Timer = System.Timers.Timer;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent an animal.
    /// </summary>
    public abstract class Animal : IEater, IMover, IReproducer, ICageable
    {
        /// <summary>
        /// The age of the animal.
        /// </summary>
        private int age;

        /// <summary>
        /// The weight of a newborn baby (as a percentage of the parent's weight).
        /// </summary>
        private double babyWeightPercentage;

        /// <summary>
        /// The gender of the animal.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// A value indicating whether or not the animal is pregnant.
        /// </summary>
        private bool isPregnant;

        /// <summary>
        /// The name of the animal.
        /// </summary>
        private string name;

        /// <summary>
        /// The weight of the animal (in pounds).
        /// </summary>
        private double weight;

        /// <summary>
        /// The random field for animal.
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The timer for the animals.
        /// </summary>
        private Timer moveTimer;

        /// <summary>
        /// Initializes a new instance of the Animal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        public Animal(string name, int age, double weight, Gender gender)
        {
            // Set the animals fields.
            this.Age = age;
            this.gender = gender;
            this.name = name;
            this.weight = weight;

            // Set the move distance.
            this.MoveDistance = 10;

            // Setting animal position, direction, and how far it moves.
            this.MoveDistance = random.Next(10);

            // Make a new timer and set it to 1000 millisecond intervals. 
            this.moveTimer = new Timer(1000);

            // Attach the elapsed event to the move handler.
            this.moveTimer.Elapsed += this.MoveHandler;

            // Start the timer.
            this.moveTimer.Start();

            // If the number is 0 the direction is left, if the number is 1, the direction is right.
            this.XDirection = (random.Next(0, 2) == 0) ? HorizontalDirection.Left : HorizontalDirection.Right;

            // If the number is 0 the direction is up, if the number is 1, the direction is down.
            this.YDirection = (random.Next(0, 2) == 0) ? VerticalDirection.Up : VerticalDirection.Down;

            // Set the X and Y max positions.
            this.XPositionMax = 800;
            this.XPosition = random.Next(1, this.XPositionMax);
            this.YPositionMax = 400;
            this.YPosition = random.Next(1, this.YPositionMax);
        }

        /// <summary>
        /// Initializes a new instance of the animal class. A chain constructor.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="weight">The weight of the animal.</param>
        /// <param name="gender">The animal's gender.</param>
        public Animal(string name, double weight, Gender gender)
            : this(name, 0, weight, gender)
        {
            this.gender = Gender;
            this.name = name;
            this.weight = weight;
        }

        /// <summary>
        /// Gets or sets the move distance.
        /// </summary>
        public int MoveDistance { get; set; }

        /// <summary>
        /// Gets or sets the x direction.
        /// </summary>
        public HorizontalDirection XDirection { get; set; }

        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        public int XPosition { get; set; }

        /// <summary>
        /// Gets or set the Y position.
        /// </summary>
        public int XPositionMax { get; set; }

        /// <summary>
        /// Gets or set the y direction.
        /// </summary>
        public VerticalDirection YDirection { get; set; }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        public int YPosition { get; set; }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        public int YPositionMax { get; set; }

        /// <summary>
        /// Gets the display size for the animal.
        /// </summary>
        public virtual double DisplaySize
        {
            get
            {
                // Ternary operator, If the animal's age is 0, make a smaller display size.
                return this.age == 0 ? 0.5 : 1.0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the animal is pregnant.
        /// </summary>
        public bool IsPregnant
        {
            get
            {
                return this.isPregnant;
            }
        }

        /// <summary>
        /// Gets the gender of the animal.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the animal.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                // If the name contains only letters and spaces, set it to value, other wise output exception.
                if (!Regex.IsMatch(value, @"^[a-zA-Z ]+$"))
                {
                    throw new FormatException("The name must only contain letters and spaces.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        /// <summary>
        /// Gets the resource key of the animal.
        /// </summary>
        public string ResourceKey
        {
            get
            {
                // Returns the type name and the words baby or adult based on age.
                return this.GetType().Name + (this.age == 0 ? "Baby" : "Adult");
            }
        }

        /// <summary>
        /// Gets or sets the animal's weight (in pounds).
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                // If the weight is between 1000 and 0 then set it.
                if(value < 1000 && value > 0)
                {
                    this.weight = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets and sets the age field.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                // Passed in value must between 100 and 0
                if(value < 100 && value >= 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the weight of a newborn baby (as a percentage of the parent's weight).
        /// </summary>
        protected double BabyWeightPercentage
        {
            get
            {
                return this.babyWeightPercentage;
            }

            set
            {
                this.babyWeightPercentage = value;
            }
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        protected abstract double WeightGainPercentage
        {
            get;
        }

        /// <summary>
        /// Converts the animal type to type.
        /// </summary>
        /// <param name="animalType"> The type of animal.</param>
        /// <returns> The type of the animal.</returns>
        public static Type ConvertAnimalTypeToType(AnimalType animalType)
        {
            Type result = null;

            switch (animalType)
            {
                case AnimalType.Chimpanzee:
                    result = typeof(Chimpanzee);

                    break;
                case AnimalType.Dingo:
                    result = typeof(Dingo);

                    break;
                case AnimalType.Eagle:
                    result = typeof(Eagle);

                    break;
                case AnimalType.Hummingbird:
                    result = typeof(Hummingbird);

                    break;
                case AnimalType.Kangaroo:
                    result = typeof(Kangaroo);

                    break;
                case AnimalType.Ostrich:
                    result = typeof(Ostrich);

                    break;
                case AnimalType.Platypus:
                    result = typeof(Platypus);

                    break;
                case AnimalType.Shark:
                    result = typeof(Shark);

                    break;
                case AnimalType.Squirrel:
                    result = typeof(Squirrel);

                    break;
            }
            return result;
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public virtual void Eat(Food food)
        {
            // Increase animal's weight as a result of eating food.
            this.Weight += food.Weight * (this.WeightGainPercentage / 100);
        }

        /// <summary>
        /// Makes the animal pregnant.
        /// </summary>
        public void MakePregnant()
        {
            this.isPregnant = true;
        }

        /// <summary>
        /// Moves about.
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        public virtual IReproducer Reproduce()
        {
            // Create a baby reproducer.
            Animal baby = Activator.CreateInstance(this.GetType(), string.Empty, 0, this.Weight * (this.BabyWeightPercentage / 100)) as Animal;

            // Reduce mother's weight by 25 percent more than the value of the baby's weight.
            this.Weight -= baby.Weight * 1.25;

            // Make mother not pregnant after giving birth.
            this.isPregnant = false;

            return baby;
        }

        /// <summary>
        /// Generates a string representation of the animal.
        /// </summary>
        /// <returns>A string representation of the animal.</returns>
        public override string ToString()
        {
            return this.name + ": " + this.GetType().Name + " (" + this.Age + ", " + this.Weight + ")";
        }

        /// <summary>
        /// The event that moves the animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveHandler(object sender, ElapsedEventArgs e)
        {
            // Conditional Directives.
            #if DEBUG
            this.moveTimer.Stop();
            #endif
            this.Move();
            #if DEBUG
            this.moveTimer.Start();
            #endif
        }
    }
}