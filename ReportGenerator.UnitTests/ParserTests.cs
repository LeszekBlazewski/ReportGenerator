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
        public void GetRequestsFromJsonString_AllRequestsAreValid_RequestsAsOrdersAreReturned()
        {
            //Arrange
            string json = @"{
                        'requests': [
                        {
                            'clientId': '1',
                            'requestId': 1,
                            'name': 'Bułka',
                            'quantity': 1,
                            'price': 10.00
                         },
                         {
                             'clientId': '1',
                             'requestId': 2,
                             'name': 'Chleb',
                             'quantity': 2,
                             'price': 15.00
                          }
                         ]
                        }";
   
            var parserFactory = new ParserFactory();
            var jsonParser = parserFactory.CreateParser(ParserFactory.ParserSort.JSONParser);

            //Action
            ((JSONParser)jsonParser).ValidateJsonSchema(json);
            List<Order> orders = ((JSONParser)jsonParser).GetOrders();

            //Assert
            Assert.AreEqual(2, orders.Count);
        }

        [TestMethod]
        public void GetRequestsFromJsonString_ClientIdTagMissing_OneRequestIsReturned()
        {
            //Arrange
            string json = @"{
                        'requests': [
                        {
                            'requestId': 1,
                            'name': 'Bułka',
                            'quantity': 1,
                            'price': 10.00
                         },
                         {
                             'clientId': '1',
                             'requestId': 2,
                             'name': 'Chleb',
                             'quantity': 2,
                             'price': 15.00
                          }
                         ]
                        }";

            var parserFactory = new ParserFactory();
            var jsonParser = parserFactory.CreateParser(ParserFactory.ParserSort.JSONParser);

            //Action
            ((JSONParser)jsonParser).ValidateJsonSchema(json);
            List<Order> orders = ((JSONParser)jsonParser).GetOrders();
            IList<string> errorMessages = ((JSONParser)jsonParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(1, errorMessages.Count);
        }

        [TestMethod]
        public void GetRequestsFromXMLFile_AllRequestsAreValid_TwoRequestAreReturned()
        {
            //Arrange
            var parserFactory = new ParserFactory();
            var xmlParser = parserFactory.CreateParser(ParserFactory.ParserSort.XMLParser);
            string xmlFilePath = Directory.GetCurrentDirectory() + "\\Utilities\\Data.xml";

            //Action
             List<Order> orders = xmlParser.GetOrdersFromFile(xmlFilePath);
             IList<string> errorMessages = ((XMLParser)xmlParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual(0, errorMessages.Count);
         }

        [TestMethod]
        public void GetRequestsFromCSVFile_AllRequestsAreValid_TwoRequestAreReturned()
        {
            //Arrange
            var parserFactory = new ParserFactory();
            var csvParser = parserFactory.CreateParser(ParserFactory.ParserSort.CSVParser);
            //Action
            List<Order> orders = csvParser.GetOrdersFromFile(Directory.GetCurrentDirectory() + "\\Utilities\\Data.csv");
            IList<string> errorMessages = ((CSVParser)csvParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(4, orders.Count);
            Assert.AreEqual(0, errorMessages.Count);
        }
    }
}
