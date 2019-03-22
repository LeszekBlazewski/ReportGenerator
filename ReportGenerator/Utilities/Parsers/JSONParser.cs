using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ReportGenerator.Utilities.Parsers
{
    class JSONParser:Parser
    {
        private RootObject requests;

        public override List<Order> GetOrdersFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                requests = JsonConvert.DeserializeObject<RootObject>(json);
            }

            return orders;
        }

        private void FilterRequests()
        {
            requests.requests
        }
    }
}
