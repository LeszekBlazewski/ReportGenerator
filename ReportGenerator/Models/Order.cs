using CsvHelper.Configuration.Attributes;
using System.Xml.Serialization;

namespace ReportGenerator.Utilities
{
    [XmlType("request")]
    public class Order
    {
        [XmlIgnore]
        [Ignore]
        public int Id { get; set; }

        [XmlElement("clientId")]
        [Name("Client_Id")]
        public string ClientId { get; set; }

        [XmlElement("requestId")]
        [Name("Request_id")]
        public long RequestId { get; set; }

        [XmlElement("name")]
        [Name("Name")]
        public string Name { get; set; }

        [XmlElement("quantity")]
        [Name("Quantity")]
        public int Quantity { get; set; }

        [XmlElement("price")]
        [Name("Price")]
        public decimal Price { get; set; }
    }
}
