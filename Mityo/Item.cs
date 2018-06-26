using System;
using System.Runtime.Serialization;

namespace Exam
{

    /// <summary>
    /// Represents a part or service that can be sold.
    ///
    /// Care should be taken to ensure that this class is immutable since it
    /// is sent to other systems for processing that should not be able to
    /// change it in any way.
    ///
    /// </summary>
    [DataContract]
    public class Item
    {
        public int Key { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Item(int key, string name, decimal price)
        {
            this.Key = key;
            this.Name = name;
            this.Price = price;
            
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int) 12073;
                hash = (hash * 379) ^ Key.GetHashCode();
                hash = (hash * 379) ^ Name.GetHashCode();
                hash = (hash * 379) ^ Price.GetHashCode();
                return hash;
            }
        }
    }
}