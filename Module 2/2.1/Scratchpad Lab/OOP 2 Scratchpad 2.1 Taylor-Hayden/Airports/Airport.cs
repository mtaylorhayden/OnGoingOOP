using System.Collections.Generic;
using Airplanes;
using System;
using People;

namespace Airports
{
    /// <summary>
    /// The class which is used to represent an airport.
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// A list of the airplanes currently located within the airport.
        /// </summary>
        private List<Airplane> airplanes = new List<Airplane>();

        private List<Person> people = new List<Person>();

        /// <summary>
        /// The cost of parking.
        /// </summary>
        private decimal parkingCost;

        /// <summary>
        /// Gets or sets a list of the airplanes currently located within the airport.
        /// </summary>
        public List<Airplane> Airplanes
        {
            get
            {
                return this.airplanes;
            }

            set
            {
                this.airplanes = value;
            }
        }


        public IEnumerable<Person> People
        {
            get
            {
                return this.people;
            }
        }
        
        /// <summary>
        /// Gets and sets the parking cost.
        /// </summary>
        public decimal ParkingCost
        {
            get
            {
                return parkingCost;
            }
            set
            {
                if(value >= 0 && value <= 100)
                {
                parkingCost = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ParkingCost", "Parking cost was out of range.");
                }
            }
        }

        public void AddPerson(int age, string firstName)
        {
            Person person = new Person();
            person.Age = age;
            person.FirstName = firstName;

            this.people.Add(person);
        }

        public void AddPerson(Person person)
        {
            this.people.Add(person);
        }
    }
}