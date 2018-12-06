﻿using System;
using System.Collections.Generic;
using People;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent a birthing room.
    /// </summary>
    [Serializable]
    public class BirthingRoom
    {
        /// <summary>
        /// The minimum allowable temperature of the birthing room.
        /// </summary>
        public static readonly double MinTemperature = 35.0;

        /// <summary>
        /// The maximum allowable temperature of the birthing room.
        /// </summary>
        public static readonly double MaxTemperature = 95.0;    

        /// <summary>
        /// The initial temperature of the birthing room.
        /// </summary>
        private readonly double initialTemperature = 77.0;

        /// <summary>
        /// The current temperature of the birthing room.
        /// </summary>
        private double temperature;

        /// <summary>
        /// The employee currently assigned to be the vet of the birthing room.
        /// </summary>
        private Employee vet;

        /// <summary>
        /// Initializes a new instance of the BirthingRoom class.
        /// </summary>
        /// <param name="vet">The employee to be the birthing room's vet.</param>
        public BirthingRoom(Employee vet)
        {
            this.Temperature = this.initialTemperature;
            this.vet = vet;

            // Makes a new queue or reproducers.
            this.PregnantAnimals = new Queue<IReproducer>();
        }

        /// <summary>
        /// Ges or sets the the pregnant animals field.
        /// </summary>
        public Queue<IReproducer> PregnantAnimals { get; private set; }

        /// <summary>
        /// The action that changes the temperature.
        /// </summary>
        public Action<double, double> OnTemperatureChange { get; set; }

        /// <summary>
        /// Gets or sets the birthing room's temperature.
        /// </summary>
        public double Temperature
        {
            get
            {
                return this.temperature;
            }

            set
            {
                // Store the temperature in a local variable.
                double previousTemp = this.temperature;

                 // If the value is in range...
                 if (value >= MinTemperature && value <= MaxTemperature)
                 {
                     this.temperature = value;

                    // If the delegate is not null...
                    if (this.OnTemperatureChange != null)
                    {
                        this.OnTemperatureChange(previousTemp, this.temperature);
                    }

                 }
                else
                {
                    if (value < MinTemperature)
                    {
                        throw new ArgumentOutOfRangeException("temperature", "The temperature must be above 35 degrees.");
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("temperature", "The temperature must be below 95 degrees.");
                    }
                }
            }
        }

        /// <summary>
        /// Births a reproducer.
        /// </summary>
        /// <param name="reproducer">The reproducer that is to give birth.</param>
        /// <returns>The resulting baby reproducer.</returns>
        public IReproducer BirthAnimal()
        {
            IReproducer baby = null;

            // If the reproducer is present and is pregnant...
            if (this.PregnantAnimals != null && this.PregnantAnimals.Count != 0)
            {
                // Give the deliver animal method the first animal in the stack.
                baby = this.vet.DeliverAnimal(this.PregnantAnimals.Dequeue());

                // Increase the temperature due to the heat generated from birthing.
                this.Temperature += 0.5;
            }

            return baby;
        }
    }
}