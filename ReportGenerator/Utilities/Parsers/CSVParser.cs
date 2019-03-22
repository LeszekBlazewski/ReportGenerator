using System;
using System.Collections.Generic;

namespace ReportGenerator.Utilities.Parsers
{
    class CSVParser : Parser
    {
        // reads data from csv file and creates new rows which will be returned in order to be added into db.

        public override List<Order> GetOrdersFromFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
