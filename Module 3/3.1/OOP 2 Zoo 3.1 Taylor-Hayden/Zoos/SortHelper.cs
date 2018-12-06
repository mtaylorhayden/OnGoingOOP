using Animals;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zoos
{
    /// <summary>
    /// The class used to represent the SortHelper class.
    /// </summary>
    public static class SortHelper
    {
        /// <summary>
        /// Sorts the animals names with the Bubble algorithm
        /// </summary>
        /// <param name="animals">The list of animals.</param>
        /// <returns> The sorted result.</returns>
        public static SortResult BubbleSortByName(List<Animal> animals)
        {
            // Initialize a compare counter variable.
            int compareCounter = 0;

            // Initialize a swap counter variable.
            int swapCounter = 0;

            // Create a new stop watch and start the timer.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Make a loop variable to one less than the length of the list and decrement the variable.
            for(int i = animals.Count - 1; i > 0; i--)
            {
                // Set at the point of comparison.
                compareCounter++;

                for (int j = 0; j < i; j++)
                {
                    if(animals[j].Name.CompareTo(animals[j + 1].Name) > 0)
                    {
                        // Swap the animals place in the index.
                        SortHelper.Swap(animals, j, j + 1);

                        // Increment the count.
                        swapCounter++;
                        compareCounter++;
                    }
                }
            }
            // Stops the stop watch.
            stopWatch.Stop();

            // Using an Object initializer, set the objects values, and return them.
            return new SortResult() { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopWatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Does a bubble sort by weight.
        /// </summary>
        /// <param name="animals"> The list of animals being sorted.</param>
        /// <returns> The results of the bubble sort.</returns>
        public static SortResult BubbleSortByWeight(List<Animal> animals)
        {
            // Initialize a compare counter variable.
            int compareCounter = 0;

            // Create a swap counter.
            int swapCounter = 0;

            // Create a new stop watch and start the timer.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Use a for loop to loop backward through the list.
            // Initialize the loop variable to one less than the length of the list and decrement the variable instead of increment.
            for (int i = animals.Count - 1; i > 0; i--)
            {
                // Loop forward as long as the loop variable is less than the outer loop variable.
                for(int j = 0; j < i; j++)
                {
                    // Set at the point of comparison.
                    compareCounter++;

                    // If the weight of the current animal is more than the weight of the next animal, swap the two animals and increment the swap count.
                    if (animals[j].Weight > animals[j + 1].Weight)
                    {
                        // Swap the animals place in the index.
                        SortHelper.Swap(animals,j, j + 1);

                        // Increment the count.
                        swapCounter++;

                    }
                }
            }
            // Stops the stop watch.
            stopWatch.Stop();

            // Using an Object initializer, set the objects values, and return them.
            return new SortResult() { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopWatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// The class used to sort by selection.
        /// </summary>
        /// <param name="animals"> The list of animals being sorted</param>
        /// <returns> The sorted result.</returns>
        public static SortResult SelectionSortByName(List<Animal> animals)
        {
            // Initialize a compare counter variable.
            int compareCounter = 0;

            // Make a counter.
            int swapCounter = 0;

            // Create a new stop watch and start the timer.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Loop forward through the list.
            for (int i = 0; i < animals.Count - 1; i++)
            {
                // Create a variable and set it to the current animal.
                // This variable should contain the animal with the current minimum name.
                Animal minimumAnimal = animals[i];

                for (int j = i + 1; j < animals.Count; j++)
                {
                    // Set at the point of comparison.
                    compareCounter++;

                    // Compares the the animals name to the animal with the current minium name.
                    if (animals[j].Name.CompareTo(minimumAnimal.Name) < 0)
                    {
                        // Set the miniumAnimal variable to the current animal.
                        minimumAnimal = animals[j];
                    }
                }
                // After finding the animal with the lowest name.
                // Compare the current animals name with the minimum name.
                if (animals[i].Name != minimumAnimal.Name)
                {
                    // Swap the two animals.
                    SortHelper.Swap(animals, i, animals.IndexOf(minimumAnimal));

                    // Increment the swap count.
                    swapCounter++;
                    compareCounter++;
                }
            }
            // Stops the stop watch.
            stopWatch.Stop();

            // Using an Object initializer, set the objects values, and return them.
            return new SortResult() { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopWatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// The class used to sort by selection.
        /// </summary>
        /// <param name="animals"> The list of animals being sorted</param>
        /// <returns> The sorted result.</returns>
        public static SortResult SelectionSortByWeight(List<Animal> animals)
        {
            // Initialize a compare counter variable.
            int compareCounter = 0;

            // Make a counter.
            int swapCounter = 0;

            // Create a new stop watch and start the timer.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Loop forward through the list.
            for (int i = 0; i < animals.Count - 1; i++)
            {
                // Create a variable and set it to the current animal.
                // This variable should contain the animal with the current minimum weight.
                Animal minimumAnimal = animals[i];

                // Loop through the remaining animals in the list to find the animal with the lowest weight.
                for (int j = i + 1; j < animals.Count; j++)
                {
                    // Set at the point of comparison.
                    compareCounter++;

                    // If the current animal's weight is less than the animal with the lowest weight..
                    if (animals[j].Weight < minimumAnimal.Weight)
                    {
                        // Set the miniumWeight variable to the current animal.
                        minimumAnimal = animals[j];
                    }
                }
                // After finding the animal with the lowest weight.
                // Compare the current animals weight with the minimum weight.
                if (animals[i].Weight != minimumAnimal.Weight)
                {
                    // Swap the two animals.
                    SortHelper.Swap(animals, i, animals.IndexOf(minimumAnimal));

                    // Increment the swap count.
                    swapCounter++;

                    compareCounter++;
                }

            }
            // Stops the stop watch.
            stopWatch.Stop();

            // Using an Object initializer, set the objects values, and return them.
            return new SortResult() { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopWatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// The class used to sort by insertion.
        /// </summary>
        /// <param name="animals"> The list of animals being sorted</param>
        /// <returns> The sorted result.</returns>
        public static SortResult InsertionSortByName(List<Animal> animals)
        {
            // Initialize a compare counter variable.
            int compareCounter = 0;

            // Initialize a swap counter variable
            int swapCounter = 0;

            // Create a new stop watch and start the timer.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // i will be the index identifier. As long as the index identifier is less than the amount of items in the list..
            for (int i = 1; i < animals.Count; i++)
            {

                // j is an index identifer. Loops over the sorted part of the array.
                // j is the smallest spot on the array.
                for (int j = 0; j < i; j++)
                {
                    // Set at the point of comparison.
                    compareCounter++;

                    // is j greater than i? i is where we are looking, j is where we are in the list.
                    if (animals[j].Name.CompareTo(animals[i].Name) > 0 && j >= 0)


                        // Change the index position in the array.
                        SortHelper.Swap(animals, i, j);

                    // Incrememnt the counter.
                    swapCounter++;

                    compareCounter++;
                }
            }
            // Stops the stop watch.
            stopWatch.Stop();

            return new SortResult() { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopWatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// The class used to sort by insertion.
        /// </summary>
        /// <param name="animals"> The list of animals being sorted</param>
        /// <returns> The sorted result.</returns>
        public static SortResult InsertionSortByWeight(List<Animal> animals)
        {
            // Initialize a compare counter variable.
            int compareCounter = 0;

            // Initialize a swap counter variable
            int swapCounter = 0;

            // Create a new stop watch and start the timer.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // i will be the index identifier. As long as the index identifier is less than the amount of items in the list..
            for (int i = 1; i < animals.Count; i++)
            {
                
                // j is an index identifer. Loops over the sorted part of the array.
                // j is the smallest spot on the array.
                for(int j = 0; j < i; j++)
                {
                    // Set at the point of comparison.
                    compareCounter++;

                    // is j greater than i? i is where we are looking, j is where we are in the list.
                    if (j >= 0 && animals[j].Weight > animals[i].Weight)
                    
                        // Change the index position in the array.
                        SortHelper.Swap(animals, i, j);

                        // Incrememnt the counter.
                        swapCounter++;

                        compareCounter++;
                }
            }
            // Stops the stop watch.
            stopWatch.Stop();

            return new SortResult() { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopWatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Swaps the animals in the list.
        /// </summary>
        /// <param name="animals"> The list of animals.</param>
        /// <param name="index1"> The first value.</param>
        /// <param name="index2"> The second value.</param>
        private static void Swap(List<Animal> animals, int index1, int index2)
        {
            // Set tmp to 1
            Animal tmp = animals[index1];

            // Set the 2 to 1.
            animals[index1] = animals[index2];

            // Set the 1 to 2.
            animals[index2] = tmp;
        }
    }
}
