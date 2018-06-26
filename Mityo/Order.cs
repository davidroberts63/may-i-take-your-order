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
        /// <summary>
        /// What's in the order.
        /// </summary>
        /// <remarks>The item ordered as well as quantiy of each item</remarks>
        [DataMember]
        public ICollection<IOrderItem> OrderItems { get; private set; }
        
        /// <summary>
        /// All individual items in the order.
        /// </summary>
        /// <remarks>Note that this will have duplicate items if the quantity ordered is more than one.</remarks>
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

        /// <summary>
        /// Calculates the total order cost after tax has been applied.
        /// </summary>
        /// <param name="taxRate">Decimal tax rate to apply to subtotal</param>
        /// <returns>Order total cost</returns>
        public decimal GetOrderTotal(decimal taxRate)
        {
            decimal subtotal = OrderItems.Sum(oi => oi.Item.Price * oi.Quantity);
            decimal taxable = OrderItems.Sum(oi => oi.TaxablePrice * oi.Quantity);
            return System.Math.Round(subtotal + (taxable * taxRate), 2);
        }
    }
}