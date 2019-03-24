using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.IO;

namespace ReportGenerator.Utilities.Parsers
{
    class JSONParser:Parser
    {
        public override List<Order> GetOrdersFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();

                ValidateJsonSchema(json);
            }

            return orders;
        }

        public void ValidateJsonSchema(string json)
        {
            JSchema schema = JSchema.Parse(Properties.Resources.json_OrderSchema);

            JObject requests = JObject.Parse(json);

            IList<string> tempErrors = new List<string>();

            foreach (var request in requests["requests"])
            {
                if (request.IsValid(schema, out tempErrors))
                {
                    orders.Add(new Order
                    {
                        ClientId = request["clientId"].Value<string>(),
                        RequestId = request["requestId"].Value<long>(),
                        Name = request["name"].Value<string>(),
                        Quantity = request["quantity"].Value<int>(),
                        Price = request["price"].Value<decimal>()
                    });
                }
                errorMessages.AddRange(tempErrors);
            }
        }
    }
}
