namespace OrdersApiAppSPD011.Model
{
    public class Info
    {
        public int Id { get; set; }
        public string Description { get; set; } = "Описание";
        public int Count { get; set; }
        public Dictionary<string, int>? ProductCount { get; set; }

    }
}
