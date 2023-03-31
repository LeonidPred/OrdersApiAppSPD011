namespace OrdersApiAppSPD011.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; } = "Описание";
        public Client? Client { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
