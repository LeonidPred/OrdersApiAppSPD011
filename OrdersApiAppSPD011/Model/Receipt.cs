namespace OrdersApiAppSPD011.Model
{
    public class Receipt
    {
        public int Sum { get; set; }
        public int Id { get; set; }
        public List<string>? ProductName { get; set; }
        public List<int>? Count { get; set; }
        public List<int>? Price { get; set; }    
    }
}
