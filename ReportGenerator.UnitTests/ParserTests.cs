using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGenerator.Utilities;
using ReportGenerator.Utilities.Parsers;
using System.Collections.Generic;
using System.IO;

namespace ReportGenerator.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void GetRequestsFromJsonFile_RequestsExist_RequestInListAreReturned()
        {
            var parserFactory = new ParserFactory();
            string jsonPath = Directory.GetCurrentDirectory() + "\\Data.JSON";
            var jsonParser = parserFactory.CreateParser(ParserFactory.ParserSort.JSONParser);
            List<Order> orders = jsonParser.GetOrdersFromFile(jsonPath);
        }
    }
}
