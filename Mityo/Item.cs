using System;

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
    public class Item
    {
        public int Key { get; private set; }
        public string Name { get; private set; }
        public float Price { get; private set; }
        
        public Item(int key, string name, float price)
        {
            this.Key = key;
            this.Name = name;
            this.Price = price;
        }

        public int GetKey()
        {
            return Key;
        }

        public string GetName()
        {
            return Name;
        }

        public float GetPrice()
        {
            return Price;
        }
    }
}