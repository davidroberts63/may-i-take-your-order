using System.Collections.Generic;

namespace Exam
{
    /// <summary>
    /// Represents and Order that contains a collection of items.
    ///
    /// Care should be taken to ensure that this class is immutable since it
    /// is sent to other systems for processing that should not be able
    /// to change it in any way.
    /// </summary>
    public class Order
    {
        public ICollection<Item> Items { get; private set; }
        
        public Order(OrderItem[] orderItems)
        {
            this.Items = orderItems;
        }

        // Returns the total order cost after the tax has been applied
        public float GetOrderTotal(float taxRate)
        {
            return 0; // implement this method
        }

        /**
         * Returns a Collection of all items sorted by item name
         * (case-insensitive).
         *
         * @return ICollection<Item>
         */
        public ICollection<Item> GetItems()
        {
            return Items;// implement this method
        }
    }
}