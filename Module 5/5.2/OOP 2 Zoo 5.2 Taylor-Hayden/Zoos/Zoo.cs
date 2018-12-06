﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Accounts;
using Animals;
using BoothItems;
using MoneyCollectors;
using People;
using VendingMachines;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent a zoo.
    /// </summary>
    [Serializable]
    public class Zoo
    {
        /// <summary>
        /// A list of all animals currently residing within the zoo.
        /// </summary>
        private List<Animal> animals;

        /// <summary>
        /// A list of cages for the zoo.
        /// </summary>
        private Dictionary<Type, Cage> cages;

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
        /// When a guest is added.
        /// </summary>
        [NonSerialized]
        private Action<Guest> onAddGuest;

        /// <summary>
        /// When the text is changed.
        /// </summary>
        [NonSerialized]
        private Action<Animal> onTextChange;

        /// <summary>
        /// The private backing field.
        /// </summary>
        [NonSerialized]
        private Action<double, double> OnBirthingRoomTemperatureChange;

        /// <summary>
        /// Updates the subscribers for adding animals.
        /// </summary>
        [NonSerialized]
        private Action<Animal> onAddAnimal;

        /// <summary>
        /// Updates the subscribers for removing animals. 
        /// </summary>
        [NonSerialized]
        private Action<Animal> onRemoveAnimal;

        /// <summary>
        /// When a guest is removed.
        /// </summary>
        [NonSerialized]
        private Action<Guest> onRemoveGuest;

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

            this.animalSnackMachine = new VendingMachine(animalFoodPrice, new Account());
            this.b168 = new BirthingRoom(vet);

            // Plugs the HandleBirthingRoomTemperatureChange method into the delegate.
            this.b168.OnTemperatureChange += this.HandleBirthingRoomTemperatureChange;

            this.capacity = capacity;
            this.cages = new Dictionary<Type, Cage>();
            this.guests = new List<Guest>();
            this.ladiesRoom = new Restroom(restroomCapacity, Gender.Female);
            this.mensRoom = new Restroom(restroomCapacity, Gender.Male);
            this.name = name;
            this.ticketBooth = new MoneyCollectingBooth(attendant, ticketPrice, waterBottlePrice, new MoneyBox());
            this.ticketBooth.AddMoney(boothMoneyBalance);
            this.informationBooth = new GivingBooth(attendant);

            //// Make a new list of aniamls and add them to the list.
            this.animals = new List<Animal>();
            //{
            //    new Chimpanzee("Bubbles", 3, 103.8, Gender.Female),
            //    new Dingo("Spot", 5, 41.3, Gender.Male),
            //    new Dingo("Maggie", 6, 37.2, Gender.Female),
            //    new Dingo("Toby", 0, 15.0, Gender.Male),
            //    new Eagle("Ari", 12, 10.1, Gender.Female),
            //    new Hummingbird("Buzz", 2, 0.02, Gender.Male),
            //    new Hummingbird("Bitsy", 1, 0.03, Gender.Female),
            //    new Kangaroo("Kanga", 8, 72.0, Gender.Female),
            //    new Kangaroo("Roo", 0, 23.9, Gender.Male),
            //    new Kangaroo("Jake", 9, 153.5, Gender.Male),
            //    new Ostrich("Stretch", 26, 231.7, Gender.Male),
            //    new Ostrich("Speedy", 30, 213.0, Gender.Female),
            //    new Platypus("Patti", 13, 4.4, Gender.Female),
            //    new Platypus("Bill", 11, 4.9, Gender.Male),
            //    new Platypus("Ted", 0, 1.1, Gender.Male),
            //    new Shark("Bruce", 19, 810.6, Gender.Female),
            //    new Shark("Anchor", 17, 458.0, Gender.Male),
            //    new Shark("Chum", 14, 377.3, Gender.Male),
            //    new Squirrel("Chip", 4, 1.0, Gender.Male),
            //    new Squirrel("Dale", 4, 0.9, Gender.Male)
            //};

            // Loop through the enumerator. Create a cage for every different type of animal.
            foreach (AnimalType a in Enum.GetValues(typeof(AnimalType)))
            {
                // Create a new cage and get the correct cage type.                
                Cage cage = new Cage(400, 800);

                // Add the created cage to the list of cages.
                this.cages.Add(Animal.ConvertAnimalTypeToType(a), cage);
            }

            //// Creates and adds lots of animals to their own lists of childern.
            //Animal brutus = new Dingo("Brutus", 3, 36.0, Gender.Male);
            //Animal coco = new Dingo("Coco", 7, 38.3, Gender.Female);
            //coco.AddChild(brutus);

            //Animal toby = new Dingo("Toby", 4, 42.5, Gender.Male);
            //Animal steve = new Dingo("Steve", 4, 41.1, Gender.Male);
            //Animal maggie = new Dingo("Maggie", 7, 34.8, Gender.Female);
            //maggie.AddChild(toby);
            //maggie.AddChild(steve);

            //Animal lucy = new Dingo("Lucy", 7, 36.5, Gender.Female);
            //Animal ted = new Dingo("Ted", 7, 39.7, Gender.Male);
            //Animal bella = new Dingo("Bella", 10, 40.2, Gender.Female);
            //bella.AddChild(coco);
            //bella.AddChild(maggie);
            //bella.AddChild(lucy);
            //bella.AddChild(ted);

            //List<Animal> tempList = new List<Animal>();
            //tempList.Add(bella);
            //tempList.Add(new Dingo("Max", 12, 46.9, Gender.Male));

            //// Call the recursive method.
            //this.AddAnimalsToZoo(tempList);
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
        /// Gets or sets the delegate.
        /// </summary>
        public Action<Animal> OnAddAnimal
        {
            get
            {
                return this.onAddAnimal;
            }
            set
            {
                this.onAddAnimal = value;
            }
        }

        /// <summary>
        /// Gets or sets the onAddGuest field.
        /// </summary>
        public Action<Guest> OnAddGuest
        {
            get
            {
                return this.onAddGuest;
            }
            set
            {
                this.onAddGuest = value;
            }
        }

        /// <summary>
        /// Gets or sets the birthing room temperature change.
        /// </summary>
        public Action <double, double> onBirthingRoomTemperatureChange
        {
            get
            {
                return this.OnBirthingRoomTemperatureChange;
            }
            set
            {
                this.OnBirthingRoomTemperatureChange = value;
            }
        }

        /// <summary>
        /// Gets or sets the delegate.
        /// </summary>
        public Action<Animal> OnRemoveAnimal
        {
            get
            {
                return this.onRemoveAnimal;
            }
            set
            {
                this.onRemoveAnimal = value;
            }
        }

        /// <summary>
        /// Gets or sets the onRemoveGuest field
        /// </summary>
        public Action<Guest> OnRemoveGuest
        {
            get
            {
                return this.onRemoveGuest;
            }
            set
            {
                this.onRemoveGuest = value;
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
            // Creates a new zoo and two new employees.
            Zoo zoo = new Zoo("Como Zoo", 1000, 4, 0.75m, 15.00m, 3640.25m, new Employee("Sam", 42), new Employee("Flora", 98), 3);

            // Add money to the animal snack machine.
            zoo.AnimalSnackMachine.AddMoney(42.75m);

            return zoo;
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {

            // Call the OnAddGuest Delegate.
            this.OnAddAnimal(animal);
            

            // Add the animal to the list of animals.
            this.animals.Add(animal);

            // Put the animal in the queue of reproducers if it's pregnant.
            if (animal.IsPregnant == true)
            {
                this.b168.PregnantAnimals.Enqueue(animal);
            }

            // Find the animals cage and give the cage the type of animal being put into the cage.
            Cage cage = this.cages[animal.GetType()];


            // Cage cage = this.FindCage(animal.GetType());

            // Add the animal to the cage.
            cage.Add(animal);
        }

        /// <summary>
        /// Adds the animals to the zoo.
        /// </summary>
        /// <param name="animals"> The collection of animals.</param>
        private void AddAnimalsToZoo(IEnumerable<Animal> animals)
        {
            if (animals != null)
            {
                // loop through passed-in list of animals
                foreach (Animal a in animals)
                {
                    // add the current animal to the list (use AddAnimal)
                    this.AddAnimal(a);

                    // using recursion, add the current animal's children to the zoo
                    this.AddAnimalsToZoo(a.Childern);
                }
            }
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

                // Check to see if the delegate is null.
                if (this.onAddGuest != null)
                {
                    // Call the OnAddGuest Delegate.
                    this.OnAddGuest(guest);
                }
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
        public void BirthAnimal()
        {
            // Birth animal.
            IReproducer baby = this.b168.BirthAnimal();

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
        /// Finds the cage based on the type of animal.
        /// </summary>
        /// <param name="animalType"> The type of animal.</param>
        /// <returns> The cage for the animal.</returns>
        public Cage FindCage(Type animalType)
        {
            Cage cage = null;

            // Finds the cage of the animals type and the cages type.
            this.cages.TryGetValue(animalType, out cage);

            return cage;
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
        /// Gets all of the animals.
        /// </summary>
        /// <param name="type"> The type of the animal to retrieve.</param>
        /// <returns> The animal being returned.</returns>
        public IEnumerable<Animal> GetAnimals(Type type)
        {
            // Create a new list of type animals.
            List<Animal> animals = new List<Animal>();

            // Go through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the type of animal is the same as the passed in type add it to the list of animals.
                if (type == a.GetType())
                {
                    animals.Add(a);
                }
            }
            return animals;
        }

        /// <summary>
        /// Handles the birthing room temperature.
        /// </summary>
        /// <param name="previousTemp"> What the temperature used to be.</param>
        /// <param name="currentTemp"> The current temperature.</param>
        private void HandleBirthingRoomTemperatureChange(double previousTemp, double currentTemp)
        {
            // Call the delegate.
            this.OnBirthingRoomTemperatureChange(previousTemp, currentTemp);
        }

        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <param name="fileName"> The name of the file being loaded.</param>
        /// <returns> The file that was loaded.</returns>
        public static Zoo LoadFromFile(string fileName)
        {
            Zoo result = null;

            // Create a binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Open and read a file using the passed-in file name
            // Use a using statement to automatically clean up object references
            // and close the file handle when the deserialization process is complete
            using (Stream stream = File.OpenRead(fileName))
            {
                // Deserialize (load) the file as a zoo
                result = formatter.Deserialize(stream) as Zoo;
            }

            return result;
        }

        public void OnDeserialized()
        {
            // Call the delegate and pass in the birthing room's current temperature for both values.
            this.OnBirthingRoomTemperatureChange(this.BirthingRoomTemperature, this.BirthingRoomTemperature);

            if (this.OnAddGuest != null)
            {
                // Simulates adding the guests so that they will appear in the guest box.
                foreach (Guest g in this.guests)
                {
                    this.OnAddGuest(g);
                }
            }

            if (this.OnAddAnimal != null)
            {
                foreach (Animal a in this.animals)
                {
                    this.OnAddAnimal(a);
                }
            }
        }

        /// <summary>
        /// Removes the animal from the zoo.
        /// </summary>
        /// <param name="animal"> The animal being removed from the zoo.</param>
        public void RemoveAnimal(Animal animal)
        {
            this.animals.Remove(animal);

            this.onRemoveAnimal(animal);

            // Loop through the zoo's list of guests.
            foreach(Guest g in this.guests)
            {
                // If any of the guests in the list of guests have adpoted then animal which is being removed...
                if(g.AdoptedAnimal == animal)
                {
                    // Remove the animal from the guest.
                    g.AdoptedAnimal = null;

                    // Remove the guest from the cage.
                    Cage newCage = this.FindCage(animal.GetType());
                    newCage.Remove(g);
                }
            }

            // Remove the animal from the list of animals.
            this.animals.Remove(animal);

            // Find the animals cage and give the cage the type of animal being put into the cage.
            Cage cage = this.cages[animal.GetType()];

            //Cage cage = this.FindCage(animal.GetType());

            // Removes the animal from the cage.
            cage.Remove(animal);
        }

        /// <summary>
        /// Removes the guest from the zoo.
        /// </summary>
        /// <param name="guest"> The guest being removed from the zoo.</param>
        public void RemoveGuest(Guest guest)
        {
            this.guests.Remove(guest);

            // Check to see if delegate is null.
            if (this.onRemoveGuest != null)
            {
                this.onRemoveGuest(guest);
            }
        }

        /// <summary>
        /// Saves the zoo to the file.
        /// </summary>
        /// <param name="fileName"> The file being saved.</param>
        public void SaveToFile(string fileName)
        {
            // Create a binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Create a file using the passed-in file name
            // Use a using statement to automatically clean up object references
            // and close the file handle when the serialization process is complete
            using (Stream stream = File.Create(fileName))
            {
                // Serialize (save) the current instance of the zoo
                formatter.Serialize(stream, this);
            }
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

        /// <summary>
        /// Sorts the animals in the list of animals.
        /// </summary>
        /// <param name="sortType"> Sorts the list of animals by this type.</param>
        /// <param name="sortValue"> Sorts the list of animals by this value.</param>
        /// <returns> The results of the sort.</returns>
        public SortResult SortAnimals(string sortType, string sortValue)
        {
            // Define variable of type SortResult and set to null.
            SortResult result = null;

            // Switch on the type of sort entered.
            switch (sortType)
            {
                // If "bubble" was entered, call the SortHelper's bubblesort method and give it the list of aniamls.
                case "bubble":
                    if (sortValue == "weight")
                    {
                        // Sort the animals by weight.
                        result = SortHelper.BubbleSortByWeight(this.animals);
                    }
                    if (sortValue == "name")
                    {
                        // Sort the animals by weight. 
                        result = SortHelper.BubbleSortByName(this.animals);
                    }
                    break;
                // If selection was typed then sort by selection.
                case "selection":
                    // If you want to sort by the weight value then type weight.
                    if (sortValue == "weight")
                    {
                        // Sort the animals by weight using a Selection sort.
                        result = SortHelper.SelectionSortByWeight(this.animals);
                    }
                    if (sortValue == "name")
                    {
                        // Sort the animals by their name.
                        result = SortHelper.SelectionSortByName(this.animals);
                    }
                    break;
                // If you want to sory by inesertion...
                case "insertion":
                    // If you want to sort by the weight value then type weight.
                    if (sortValue == "weight")
                    {
                        // Sort by the animals weight and insertion.
                        result = SortHelper.InsertionSortByWeight(this.animals);
                    }
                    // If you want to sort by the name value then type name.
                    if (sortValue == "name")
                    {
                        // Sort by the animals weight and insertion.
                        result = SortHelper.InsertionSortByName(this.animals);
                    }
                    break;
                // If you want to sort by quick...
                case "quick":

                    // Make a new sort result.
                    SortResult sort = new SortResult();

                    // Make a new stop watch and start the timer.
                    Stopwatch watch = new Stopwatch();
                    watch.Start();

                    // If you want to sort by weight.
                    if (sortValue == "name")
                    {
                        // Pass in the lowest left index (0), and the highest right index (the number of items in the list)
                        SortHelper.QuickSortByName(this.animals, 0, this.animals.Count - 1, sort);

                        // Stop the watch.
                        watch.Stop();

                        // Set the sorts elapsed milliseconds to the watch's total elapsed milliseconds property. 
                        sort.ElapsedMilliseconds = watch.Elapsed.TotalMilliseconds;

                        // Set the result variable to the sort resutl
                        result = sort;
                    }

                    // If you want to sort by weight.
                    if (sortValue == "weight")
                    {
                        // Pass in the lowest left index (0), and the highest right index (the number of items in the list)
                        SortHelper.QuickSortByWeight(this.animals, 0, this.animals.Count - 1, sort);

                        // Stop the watch.
                        watch.Stop();

                        // Set the sorts elapsed milliseconds to the watch's total elapsed milliseconds property. 
                        sort.ElapsedMilliseconds = watch.Elapsed.TotalMilliseconds;

                        // Set the result variable to the sort resutl
                        result = sort;
                    }
                    break;
            }

            return result;
        }
    }
}