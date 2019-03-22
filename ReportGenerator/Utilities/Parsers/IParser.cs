using System.Collections.Generic;

namespace ReportGenerator.Utilities.Parsers
{
    interface IParser
    {
        List<Order> GetOrdersFromFile(string filePath);
    }
}
