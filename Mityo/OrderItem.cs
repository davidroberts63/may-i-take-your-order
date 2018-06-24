using System.Runtime.Serialization;

namespace Exam
{
    public interface IOrderItem
    {
        Item Item { get; }
        int Quantity { get; }
    }

    [DataContract]
    public class ServiceOrderItem : IOrderItem
    {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        public ServiceOrderItem(Item item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
    }

    [DataContract]
    public class MaterialOrderItem : IOrderItem
    {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        public MaterialOrderItem(Item item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
    }

}