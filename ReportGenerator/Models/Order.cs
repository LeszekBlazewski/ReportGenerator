using Newtonsoft.Json;

namespace ReportGenerator.Utilities
{
    public class Order
    {
        public int Id { get; set; }

        public string ClientId { get; set; }

        public long RequestId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
