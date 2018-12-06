using System;
using System.Collections.Generic;
using Animals;
using BoothItems;
using Foods;
using Reproducers;

namespace People
{
    /// <summary>
    /// The class which is used to represent an employee.
    /// </summary>
    public class Employee : IEater
    {
        /// <summary>
        /// The name of the employee.
        /// </summary>
        private string name;

        /// <summary>
        /// The employee's identification number.
        /// </summary>
        private int number;

        /// <summary>
        /// The number of rooms the employee has sterilized.
        /// </summary>
        private int numberOfRoomsSterilized;

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="number">The employee's identification number.</param>
        public Employee(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        /// <summary>
        /// Gets the weight of the employee.
        /// </summary>
        public double Weight
        {
            get
            {
                // Confidential.
                return 0.0;
            }
        }

        /// <summary>
        /// Aids the specified reproducer in delivering its baby.
        /// </summary>
        /// <param name="reproducer">The reproducer that is to give birth.</param>
        /// <returns>The resulting baby reproducer.</returns>
        public IReproducer DeliverAnimal(IReproducer reproducer)
        {
            // Sterilize birthing area.
            this.SterilizeBirthingArea();

            // Give birth.
            IReproducer baby = reproducer.Reproduce();

            if (baby is IMover)
            {
                // Make the baby move.
                (baby as IMover).Move();
            }

            if (baby is Animal)
            {
                // Name the baby.
                (baby as Animal).Name = "Baby";
            }

            return baby;
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public void Eat(Food food)
        {
            // Eat the food.
        }

        /// <summary>
        /// Finds the item for the employee.
        /// </summary>
        /// <param name="items"> The list of items.</param>
        /// <param name="type"> The type of items.</param>
        /// <returns></returns>
        public Item FindItem(List<Item> items, Type type)
        {
            Item item = null;

            // If the amount of items in the list is more than 0...
            if(items.Count != 0)
            {
                foreach(Item i in items)
                {
                    // If the item is the same type as the passed in type.
                    if(i.GetType() == type)
                    {
                        item = i;

                        items.Remove(i);

                        break;
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// Finds the coupon book.
        /// </summary>
        /// <param name="couponStack"> The coupon stack.</param>
        /// <returns> The coupon book that gets found.</returns>
        public CouponBook FindCouponBook(List<CouponBook> couponStack)
        {
            CouponBook couponBook = null;

            // If there are more than one coupon books left.
            if (couponStack.Count > 0)
            {
                // Take a coupon book away.
                couponBook = couponStack[0];

                // Remove the coupon book from the list.
                couponStack.Remove(couponBook);
            }

            return couponBook;
        }

        /// <summary>
        /// Finds the map.
        /// </summary>
        /// <param name="
        /// tack"> The map from the list.</param>
        /// <returns> The map that gets found.</returns>
        public Map FindMap(List<Map> mapStack)
        {
            Map map = null;

            // If the map count is higher than 0.
            if (mapStack.Count > 0)
            {
                // Take one map.
                 map = mapStack[0];

                // Remove the map from the list of maps.
                 mapStack.Remove(map);
            }

            return map;
        }

        /// <summary>
        /// Finds the ticket.
        /// </summary>
        /// <param name="ticketStack"> The list of tickets.</param>
        /// <returns> The ticket that was found.</returns>
        public Ticket FindTicket(List<Ticket> ticketStack)
        {
            Ticket ticket = null;

            // If the ticket count is greater than 0.
            if (ticketStack.Count > 0)
            {
                // Takes out the ticket and stores it into the ticket.
                ticket = ticketStack[0];

                // Removes the ticket from the ticket stack.
                ticketStack.Remove(ticket);
            }

            return ticket;
        }

        /// <summary>
        /// Finds the water bottle.
        /// </summary>
        /// <param name="bottleBox"> The list of water bottles.</param>
        /// <returns> The water bottle that was found.</returns>
        public WaterBottle FindWaterBottler(List<WaterBottle> bottleBox)
        {
            WaterBottle waterBottle = null;

            // If there are still water bottles in stock then subtract one from the list.
            if (bottleBox.Count > 0)
            {
                // Take one water bottle.
                waterBottle = bottleBox[0];

                // Remove the water bottle from the list.
                bottleBox.Remove(waterBottle);
            }

            return waterBottle;
        }

        /// <summary>
        /// Sterilizes the birthing area in preparation for delivering a baby.
        /// </summary>
        private void SterilizeBirthingArea()
        {
            this.numberOfRoomsSterilized++;
        }
    }
}