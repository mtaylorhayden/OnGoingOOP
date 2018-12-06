using System;
using System.Collections.Generic;
using Animals;
using BoothItems;
using People;
using Reproducers;
using VendingMachines;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent a zoo.
    /// </summary>
    public class Zoo
    {
        /// <summary>
        /// A list of all animals currently residing within the zoo.
        /// </summary>
        private List<Animal> animals;

        /// <summary>
        /// The zoo's vending machine which allows guests to buy snacks for animals.
        /// </summary>
        private VendingMachine animalSnackMachine;

        /// <summary>
        /// The zoo's room for birthing animals.
        /// </summary>
        private BirthingRoom b168;

        /// <summary>
        /// The zoo's information booth.
        /// </summary>
        private GivingBooth informationBooth;

        /// <summary>
        /// The zoo's ticket booth.
        /// </summary>
        private MoneyCollectingBooth ticketBooth;

        /// <summary>
        /// The maximum number of guests the zoo can accommodate at a given time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// A list of all guests currently visiting the zoo.
        /// </summary>
        private List<Guest> guests;

        /// <summary>
        /// The zoo's ladies' restroom.
        /// </summary>
        private Restroom ladiesRoom;

        /// <summary>
        /// The zoo's men's restroom.
        /// </summary>
        private Restroom mensRoom;

        /// <summary>
        /// The name of the zoo.
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the Zoo class.
        /// </summary>
        /// <param name="name">The name of the zoo.</param>
        /// <param name="capacity">The maximum number of guests the zoo can accommodate at a given time.</param>
        /// <param name="restroomCapacity">The capacity of the zoo's restrooms.</param>
        /// <param name="animalFoodPrice">The price of a pound of food from the zoo's animal snack machine.</param>
        /// <param name="ticketPrice">The price of an admission ticket to the zoo.</param>
        /// <param name="boothMoneyBalance">The initial money balance of the zoo's ticket booth.</param>
        /// <param name="attendant">The zoo's ticket booth attendant.</param>
        /// <param name="vet">The zoo's birthing room vet.</param>
        /// <param name="waterBottlePrice"> The price of the zoo's water bottles.</param>
        public Zoo(string name, int capacity, int restroomCapacity, decimal animalFoodPrice, decimal ticketPrice, decimal boothMoneyBalance, Employee attendant, Employee vet, decimal waterBottlePrice)
        {
            this.animals = new List<Animal>();
            this.animalSnackMachine = new VendingMachine(animalFoodPrice);
            this.b168 = new BirthingRoom(vet);
            this.capacity = capacity;
            this.guests = new List<Guest>();
            this.ladiesRoom = new Restroom(restroomCapacity, "Female");
            this.mensRoom = new Restroom(restroomCapacity, "Male");
            this.name = name;
            this.ticketBooth = new MoneyCollectingBooth(attendant, ticketPrice, waterBottlePrice);
            this.ticketBooth.AddMoney(boothMoneyBalance);
            this.informationBooth = new GivingBooth(attendant);
        }

        /// <summary>
        /// The list of animals being put into the list.
        /// </summary>
        public IEnumerable<Animal> Animals
        {
            get
            {
                return this.animals;
            }
        }

        /// <summary>
        /// Gets the zoo's animal snack machine.
        /// </summary>
        public VendingMachine AnimalSnackMachine
        {
            get
            {
                return this.animalSnackMachine;
            }
        }

        /// <summary>
        /// Gets the average weight of all animals in the zoo.
        /// </summary>
        public double AverageAnimalWeight
        {
            get
            {
                return this.TotalAnimalWeight / this.animals.Count;
            }
        }

        /// <summary>
        /// Gets or sets the temperature of the zoo's birthing room.
        /// </summary>
        public double BirthingRoomTemperature
        {
            get
            {
                return this.b168.Temperature;
            }

            set
            {
                this.b168.Temperature = value;
            }
        }

        /// <summary>
        /// The list of guests that is being enumerated
        /// </summary>
        public IEnumerable<Guest> Guests
        {
            get
            {
                return this.guests;
            }
        }

        /// <summary>
        /// Gets the total weight of all animals in the zoo.
        /// </summary>
        public double TotalAnimalWeight
        {
            get
            {
                // Define accumulator variable.
                double totalWeight = 0;

                // Loop through the list of animals.
                foreach (Animal a in this.animals)
                {
                    // Add current animal's weight to the total.
                    totalWeight += a.Weight;
                }

                return totalWeight;
            }
        }

        /// <summary>
        /// Creates a new zoo.
        /// </summary>
        /// <returns> The created zoo.</returns>
        public static Zoo NewZoo()
        {
            Zoo zoo = new Zoo("Como Zoo", 1000, 4, 0.75m, 15.00m, 3640.25m, new Employee("Sam", 42), new Employee("Flora", 98), 3);

            // Add money to the animal snack machine.
            zoo.AnimalSnackMachine.AddMoney(42.75m);

            // Define an animal variable.
            Animal animal;

            // Create a new Dingo and add him to the list of animals.
            animal = new Dingo("Dolly", 4, 35.3);

            animal.MakePregnant();

            zoo.AddAnimal(animal);

            // Create a new Dingo and add him to the list of animals.
            animal = new Dingo("Dixie", 3, 33.8);

            animal.MakePregnant();

            zoo.AddAnimal(animal);

            // Create a new platypus and add him to the list of animals.
            animal = new Platypus("Patty", 2, 15.5);

            animal.MakePregnant();

            zoo.AddAnimal(animal);

            // Create a new Hummingbird and add him to the list of animals.
            animal = new Hummingbird("Harold", 1, 0.5);

            zoo.AddAnimal(animal);

            // Create a new chimp and add him to the list of animals.
            animal = new Chimpanzee("Noah", 12, 500);

            zoo.AddAnimal(animal);

            // Create a new eagle and add him to the list of animals.
            animal = new Eagle("Tracy", 300, 10);

            zoo.AddAnimal(animal);

            // Create a new kangaroo and add him to the list of animals.
            animal = new Kangaroo("Jeff", 25, 30);

            zoo.AddAnimal(animal);

            // Create a new ostrich and add him to the list of animals.
            animal = new Ostrich("Jake", 40, 200);

            zoo.AddAnimal(animal);

            // Create a new shark and add him to the list of animals.
            animal = new Shark("Max", 23, 185);

            zoo.AddAnimal(animal);

            // Create a new squirrel and them to the list.
            animal = new Squirrel("Matt", 21, 200);

            zoo.AddAnimal(animal);

            // Create a guest.
            Guest guest = new Guest("Greg", 44, 150.35m, "Brown");

            // Add the guest and sell the ticket to the guest.
            zoo.AddGuest(guest, zoo.SellTicket(guest));

            // Create a guest.
            guest = new Guest("Darla", 11, 25.25m, "Salmon");

            // Add the guest and sell the ticket to the guest.
            zoo.AddGuest(guest, zoo.SellTicket(guest));

            return zoo;
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            this.animals.Add(animal);
        }

        /// <summary>
        /// Adds a guest to the zoo.
        /// </summary>
        /// <param name="guest">The guest to add.</param>
        /// <param name="ticket"> The ticket for the guest.</param>
        public void AddGuest(Guest guest, Ticket ticket)
        {
            // If the ticket isn't null and isn't redeemed then add the guest.
            if (ticket != null && ticket.Redeem())
            {
                
                // Adds the guest to the list.
                this.guests.Add(guest);
            }
            else
            {
                throw new NullReferenceException("Guest did not have a ticket");
            }
        }

        /// <summary>
        /// Aids a reproducer in giving birth.
        /// </summary>
        /// <param name="reproducer">The reproducer that is to give birth.</param>
        public void BirthAnimal(IReproducer reproducer)
        {
            // Birth animal.
            IReproducer baby = this.b168.BirthAnimal(reproducer);

            // If the baby is an animal...
            if (baby is Animal)
            {
                // Add the baby to the zoo's list of animals.
                this.AddAnimal(baby as Animal);
            }
        }

        /// <summary>
        /// Finds an animal based on type.
        /// </summary>
        /// <param name="type">The type of the animal to find.</param>
        /// <returns>The first matching animal.</returns>
        public Animal FindAnimal(Type type)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type)
                {
                    // Set the current animal to the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds an animal based on type and pregnancy status.
        /// </summary>
        /// <param name="type">The type of the animal to find.</param>
        /// <param name="isPregnant">The pregnancy status of the animal to find.</param>
        /// <returns>The first matching animal.</returns>
        public Animal FindAnimal(Type type, bool isPregnant)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type && a.IsPregnant == isPregnant)
                {
                    // Store the current animal in the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds the animal by name.
        /// </summary>
        /// <param name="name"> The name of the animal.</param>
        /// <returns> The animal found.</returns>
        public Animal FindAnimal(string name)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.Name == name)
                {
                    // Set the current animal to the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds a guest based on name.
        /// </summary>
        /// <param name="name">The name of the guest to find.</param>
        /// <returns>The first matching guest.</returns>
        public Guest FindGuest(string name)
        {
            // Define a variable to hold matching guest.
            Guest guest = null;

            // Loop through the list of guests.
            foreach (Guest g in this.guests)
            {
                // If the current guest matches...
                if (g.Name == name)
                {
                    // Store the current guest in the variable
                    guest = g;

                    // Break out of the loop
                    break;
                }
            }

            // Return the matching guest.
            return guest;
        }

        /// <summary>
        /// Sells the ticket.
        /// </summary>
        /// <param name="guest"> The guest who will have the ticket sold to them.</param>
        /// <returns> The ticket given to the guest.</returns>
        public Ticket SellTicket(Guest guest)
        {
            Ticket ticket = guest.VisitTicketBooth(this.ticketBooth);

            guest.VisitInformationBooth(this.informationBooth);

            return ticket;
        }
    }
}