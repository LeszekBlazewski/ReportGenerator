using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.IO;

namespace ReportGenerator.Utilities.Parsers
{
    class JSONParser:Parser
    {
        private List<string> errorMessages = new List<string>();

        public List<string> GetErrorMessages() => errorMessages;

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
            JSchema schema = JSchema.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Utilities\\json-OrderSchema.json"));  // json-OrderSchema.json is always copied to output directory

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
