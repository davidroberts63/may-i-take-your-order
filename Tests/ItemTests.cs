using System;
using Xunit;

namespace Tests
{
    public class ItemTests
    {
        [Fact]
        public void GetKeyShouldReturnKeyGivenInCtor()
        {
            var item = new Exam.Item(1, "Burger", 2.50m);
            Assert.Equal(1, item.GetKey());
        }

        [Fact]
        public void GetNameShouldReturnNameGivenInCtor()
        {
            var item = new Exam.Item(1, "Burger", 2.50m);
            Assert.Equal("Burger", item.GetName());
        }

        [Fact]
        public void GetPriceShouldReturnPriceGivenInCtor()
        {
            var item = new Exam.Item(1, "Burger", 2.50m);
            Assert.Equal(2.50m, item.GetPrice());
        }

        [Fact]
        public void HashcodeForItemsWithSameDataShouldMatch()
        {
            var itemA = new Exam.Item(1, "Burger", 2.50m);
            var itemB = new Exam.Item(1, "Burger", 2.50m);

            Assert.Equal(itemA.GetHashCode(), itemB.GetHashCode());
        }
    }
}
