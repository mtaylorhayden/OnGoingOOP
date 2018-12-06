using BoothItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    /// <summary>
    /// The class used to represent the Giving Booth.
    /// </summary>
    public class GivingBooth : Booth
    {
        /// <summary>
        /// Initializes a new instance of the GivingBooth class.
        /// </summary>
        /// <param name="attendant"> The employee who will work the booth.</param>
        public GivingBooth(Employee attendant)
            : base(attendant)
        {
            // Make 5 coupon books and stop at 5.
            for (int c = 0; c < 5; c++)
            {
                // Create a variable of type coupon book and pass in the correct parameters.
                CouponBook couponBook = new CouponBook(DateTime.Now, DateTime.Now.AddYears(1), 0.8);

                this.Items.Add(couponBook);
            }

            // Make 10 maps.
            for (int m = 0; m < 10; m++)
            {
                // Create a variable of type map and pass in the correct parameters.
                Map map = new Map(.5, DateTime.Now);

                this.Items.Add(map);
            }
        }

        /// <summary>
        /// Gives a coupon book away for free.
        /// </summary>
        /// <returns> The coupon book that is being given away.</returns>
        public CouponBook GiveFreeCouponBook()
        {
            CouponBook couponBook = null;

            // Find the coupon book.
            couponBook = this.Attendant.FindItem(this.Items, typeof(CouponBook)) as CouponBook;

            return couponBook;
        }

        /// <summary>
        /// Gives a free map away.
        /// </summary>
        /// <returns> The map that will be given away.</returns>
        public Map GiveFreeMap()
        {
            Map map = null;

            // Find the map.
            map = this.Attendant.FindItem(this.Items, typeof(Map)) as Map;

            return map;
        }
    }
}
