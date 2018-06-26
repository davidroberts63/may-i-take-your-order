using System;
using Xunit;

namespace Tests
{
    public class ItemTests
    {
        [Fact]
        public void HashcodeForItemsWithSameDataShouldMatch()
        {
            var itemA = new Exam.Item(1, "Burger", 2.50m);
            var itemB = new Exam.Item(1, "Burger", 2.50m);

            Assert.Equal(itemA.GetHashCode(), itemB.GetHashCode());
        }
    }
}
