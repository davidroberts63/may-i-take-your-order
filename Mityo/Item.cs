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
        private int key;
        private string name;
        private float price;

        public Item(int key, string name, float price)
        {
            this.key = key;
            this.name = name;
            this.price = price;
        }

        public int GetKey()
        {
            return key;
        }

        public string GetName()
        {
            return name;
        }

        public float GetPrice()
        {
            return price;
        }
    }
}