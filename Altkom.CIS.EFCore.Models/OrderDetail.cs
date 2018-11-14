namespace Altkom.CIS.EFCore.Models
{
    public class OrderDetail : Base
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderDetail()
        {
        }

        public OrderDetail(Item item, int quantity = 1)
            : this()
        {
            this.Item = item;
            this.Quantity = quantity;
            this.UnitPrice = item.UnitPrice;
        }
    }
}
