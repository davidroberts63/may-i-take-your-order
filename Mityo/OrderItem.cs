namespace Exam
{
    public interface IOrderItem
    {
        public Item Item { get; }
        public int Quantity { get; }
    }

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