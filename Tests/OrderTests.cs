using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class OrderTests
    {
        [Fact]
        public void ItemsShouldReturnItemsTimesQuantityInOrderItem()
        {
            var originalOrderItems = new List<Exam.IOrderItem>()
            {
                new Exam.MaterialOrderItem(new Exam.Item(1,"A",1), 1),
                new Exam.MaterialOrderItem(new Exam.Item(2,"B",2), 2)
            };
            var order = new Exam.Order(originalOrderItems);

            Assert.Equal(3, order.Items.Count);
            Assert.Equal(2, order.Items.Count(i => i.Name == "B"));
            Assert.Equal(1, order.Items.Count(i => i.Name == "A"));
        }

        [Fact]
        public void ShouldNotBeAbleToAddNewOrderItemsToAnOrder()
        {
            var originalOrderItems = new List<Exam.IOrderItem>()
            {
                new Exam.MaterialOrderItem(new Exam.Item(1,"A",1), 1),
                new Exam.MaterialOrderItem(new Exam.Item(2,"B",2), 1)
            };
            var order = new Exam.Order(originalOrderItems);

            // Testing for a specific type is not quite the preferred way
            // but in this case it's the only way. Can't call Add on a class
            // that doesn't publicly provide it.
            Assert.IsType(typeof(ReadOnlyCollection<Exam.IOrderItem>), order.OrderItems);

            // Also, safe to say, can't add, then can't remove given the above.
            // Also, the OrderItem itself is readonly so can't change that either.
        }

        [Fact]
        public void ShouldBeSerializable()
        {
            var originalOrderItems = new List<Exam.IOrderItem>()
            {
                new Exam.MaterialOrderItem(new Exam.Item(1,"A",1), 2),
                new Exam.MaterialOrderItem(new Exam.Item(2,"B",2), 1)
            };
            var order = new Exam.Order(originalOrderItems);

            var stream = new System.IO.MemoryStream();
            var itemTypes = new [] {typeof(Exam.MaterialOrderItem), typeof(Exam.ServiceOrderItem)};
            var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Exam.Order), itemTypes);
            serializer.WriteObject(stream, order);
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            var deserializedOrder = serializer.ReadObject(stream) as Exam.Order;

            Assert.NotNull(deserializedOrder);
            Assert.Equal(order.OrderItems.Count, deserializedOrder.OrderItems.Count);
            Assert.Equal("A", order.OrderItems.First().Item.Name);
            Assert.Equal(2, order.OrderItems.First().Quantity);
        }

        [Fact]
        public void OrderTotalOfServiceOrderItemsDoesNotIncludeTax()
        {
            var originalOrderItems = new List<Exam.IOrderItem>()
            {
                new Exam.ServiceOrderItem(new Exam.Item(1,"A",1.21m), 2),
                new Exam.ServiceOrderItem(new Exam.Item(2,"B",2.08m), 1)
            };
            var order = new Exam.Order(originalOrderItems);

            Assert.Equal(4.50m, order.GetOrderTotal(0m));
        }

        [Theory]
        [InlineData(0.10, 4.95)]
        [InlineData(0.0876, 4.89)]
        public void OrderTotalOfMaterialOrderItemsIncludesTax(decimal rate, decimal expected)
        {
            var originalOrderItems = new List<Exam.IOrderItem>()
            {
                new Exam.MaterialOrderItem(new Exam.Item(1,"A",1.21m), 2),
                new Exam.MaterialOrderItem(new Exam.Item(2,"B",2.08m), 1)
            };
            var order = new Exam.Order(originalOrderItems);

            Assert.Equal(expected, order.GetOrderTotal(rate));
        }
        
    }
}
