using System.Collections.Generic;

namespace ReportGenerator.Utilities.Parsers
{
    abstract class Parser : IParser
    {
        protected List<Order> orders = new List<Order>();

        public abstract List<Order> GetOrdersFromFile(string filePath);
      
        // 1. CLientID can NOT contain any spaces AND can't be longer than 6 characters
        // 2. Name can NOT be longer than 255 characters
        protected void FilterOrders()
        {
            // maybe usefult not sure now 
        }
    }
}
