using System.Collections.Generic;

namespace ReportGenerator.Utilities.Parsers
{
    abstract class Parser : IParser
    {
        public List<Order> GetOrders() => orders;

        public List<string> GetErrorMessages() => errorMessages;

        protected List<Order> orders = new List<Order>();

        protected List<string> errorMessages = new List<string>();

        public abstract List<Order> GetOrdersFromFile(string filePath);
      
    }
}
