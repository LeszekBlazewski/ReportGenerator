using System.Collections.Generic;

namespace ReportGenerator.Utilities.Parsers
{
    abstract class Parser : IParser
    {
        protected List<Order> orders = new List<Order>();

        protected List<string> errorMessages = new List<string>();

        public List<string> GetErrorMessages() => errorMessages;

        public abstract List<Order> GetOrdersFromFile(string filePath);
      
    }
}
