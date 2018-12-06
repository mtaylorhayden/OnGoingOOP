﻿using People;

namespace Animals
{
    /// <summary>
    /// The class used to represent an animal factory.
    /// </summary>
    public static class AnimalFactory
    {
        /// <summary>
        /// Creates aniamls for the factory.
        /// </summary>
        /// <param name="type"> The type of animal that will be created.</param>
        /// <param name="name"> The name of the animal.</param>
        /// <param name="age"> The age of the animal.</param>
        /// <param name="weight"> The weight of the animal.</param>
        /// <param name="gender"> The gender of the animal.</param>
        public static Animal CreateAnimal(AnimalType type, string name, int age, double weight, Gender gender)
        {
            Animal result = null;

            switch (type)
            {
                case AnimalType.Chimpanzee:
                    result = new Chimpanzee(name, age, weight, gender);

                    break;

                case AnimalType.Dingo:
                    result = new Dingo(name, age, weight, gender);

                    break;

                case AnimalType.Eagle:
                    result = new Eagle(name, age, weight, gender);

                    break;

                case AnimalType.Hummingbird:
                    result = new Hummingbird(name, age, weight, gender);

                    break;

                case AnimalType.Kangaroo:
                    result = new Kangaroo(name, age, weight, gender);

                    break;

                case AnimalType.Ostrich:
                    result = new Ostrich(name, age, weight, gender);

                    break;

                case AnimalType.Platypus:
                    result = new Platypus(name, age, weight, gender);

                    break;

                case AnimalType.Shark:
                    result = new Shark(name, age, weight, gender);

                    break;

                case AnimalType.Squirrel:
                    result = new Squirrel(name, age, weight, gender);

                    break;

                default:
                    break;

                    
            }

            return result;
        }
        
    }
}
