using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Exam
{
    /// <summary>
    /// Represents and Order that contains a collection of items.
    ///
    /// Care should be taken to ensure that this class is immutable since it
    /// is sent to other systems for processing that should not be able
    /// to change it in any way.
    /// </summary>
    [DataContract]
    public class Order
    {
        [DataMember]
        public ICollection<IOrderItem> OrderItems { get; private set; }
        public ICollection<Item> Items
        {
            get
            {
                var stuff = OrderItems.SelectMany((IOrderItem oi) => {
                    var result = new Item[oi.Quantity];
                    for (var i = 0; i < oi.Quantity; i++)
                    {
                        result[i] = oi.Item;
                    }
                    return result;
                }).ToList();

                return new Collection<Item>(stuff.OrderBy(i => i.Name).ToList());
            }
        }

        public Order(IEnumerable<IOrderItem> orderItems)
        {
            this.OrderItems = new ReadOnlyCollection<IOrderItem>(orderItems.ToList());
        }

        // Returns the total order cost after the tax has been applied
        public decimal GetOrderTotal(decimal taxRate)
        {
            decimal subtotal = OrderItems.Sum(oi => oi.Item.Price * oi.Quantity);
            decimal taxable = OrderItems.Sum(oi => oi.TaxablePrice * oi.Quantity);
            return System.Math.Round(subtotal + (taxable * taxRate), 2);
        }

        /**
         * Returns a Collection of all items sorted by item name
         * (case-insensitive).
         *
         * @return ICollection<Item>
         */
        public ICollection<Item> GetItems()
        {
            return Items;
        }
    }
}