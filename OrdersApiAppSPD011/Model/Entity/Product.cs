namespace OrdersApiAppSPD011.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Article { get; set; }
        public int Price { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
