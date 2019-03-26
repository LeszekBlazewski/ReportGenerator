using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGenerator.Utilities;
using ReportGenerator.Utilities.Parsers;
using System.Collections.Generic;

namespace ReportGenerator.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        [DeploymentItem(".\\Properties\\CorrectJsonData.json", "Data")]
        public void GetRequestsFromJsonFile_FileContainsFourValidRequests_FourRequestsAreReturned()
        {
            //Arrange
            var jsonParser = ParserCreator.GetParser(ParserFactory.ParserSort.JSONParser);
            string jsonFilePath = @"Data\CorrectJsonData.json";

            //Action
            List<Order> orders = jsonParser.GetOrdersFromFile(jsonFilePath);
            List<string> errors = ((Parser)jsonParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(4, orders.Count);
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [DeploymentItem(".\\Properties\\MissingTagJsonData.json", "Data")]
        public void GetRequestsFromJsonFile_FileContainsOneValidRequest_ThreeJsonObjectAreMissingTags_OneRequestIsReturned()
        {
            //Arrange
            var jsonParser = ParserCreator.GetParser(ParserFactory.ParserSort.JSONParser);
            string jsonFilePath = @"Data\MissingTagJsonData.json";


            //Action

            List<Order> orders = jsonParser.GetOrdersFromFile(jsonFilePath);
            IList<string> errorMessages = ((JSONParser)jsonParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(3, errorMessages.Count);
        }

        [TestMethod]
        [DeploymentItem(".\\Properties\\CLientIdAndRequestNameUnvalid.json", "Data")]
        public void GetRequestsFromJsonFile_FileContainsOneValidRequests_ThreeJsonObjectProperitesAreUnvalid_OneRequestIsReturned()
        {
            //Arrange
            var jsonParser = ParserCreator.GetParser(ParserFactory.ParserSort.JSONParser);
            string jsonFilePath = @"Data\CLientIdAndRequestNameUnvalid.json";

            //Action

            List<Order> orders = jsonParser.GetOrdersFromFile(jsonFilePath);
            IList<string> errorMessages = ((JSONParser)jsonParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(3, errorMessages.Count);
        }

        [TestMethod]
        [DeploymentItem(".\\Properties\\CorrectXmlData.xml","Data")]
        [DeploymentItem(".\\Properties\\xml_Schema.xsd","Properties")]
        public void GetRequestsFromXMLFile_FileContainsFourValidRequests_FourRequestAreReturned()
        {
            //Arrange
            var xmlParser = ParserCreator.GetParser(ParserFactory.ParserSort.XMLParser);
            string xmlFilePath = @"Data\CorrectXmlData.xml";

            //Action

             List<Order> orders = xmlParser.GetOrdersFromFile(xmlFilePath);
             IList<string> errorMessages = ((XMLParser)xmlParser).GetErrorMessages();

            //Assert

            Assert.AreEqual(4, orders.Count);
            Assert.AreEqual(0, errorMessages.Count);
         }

        [TestMethod]
        [DeploymentItem(".\\Properties\\MissingTagXmlData.xml", "Data")]
        [DeploymentItem(".\\Properties\\xml_Schema.xsd", "Properties")]
        public void GetRequestsFromXMLFile_FileContainsOneValidRequest_FourRequestsAreMissingTags_OneRequestIsReturned()
        {
            //Arrange

            var xmlParser = ParserCreator.GetParser(ParserFactory.ParserSort.XMLParser);
            string xmlFilePath = @"Data\MissingTagXmlData.xml";

            //Action

            List<Order> orders = xmlParser.GetOrdersFromFile(xmlFilePath);
            IList<string> errorMessages = ((XMLParser)xmlParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(4, errorMessages.Count);
        }

        [TestMethod]
        [DeploymentItem(".\\Properties\\ClientIdAndRequestNameUnvalid.xml", "Data")]
        [DeploymentItem(".\\Properties\\xml_Schema.xsd", "Properties")]
        public void GetRequestsFromXMLFile_FileContainsOneValidRequest_ClientIdAndRequestNameAreUnvalid_OneRequestIsReturned()
        {
            //Arrange

            var xmlParser = ParserCreator.GetParser(ParserFactory.ParserSort.XMLParser);
            string xmlFilePath = @"Data\ClientIdAndRequestNameUnvalid.xml";

            //Action

            List<Order> orders = xmlParser.GetOrdersFromFile(xmlFilePath);
            IList<string> errorMessages = ((XMLParser)xmlParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(3, errorMessages.Count);
        }


        [TestMethod]
        [DeploymentItem(".\\Properties\\CorrectCsvData.csv", "Data")]
        public void GetRequestsFromCSVFile_AllRequestsAreValid_FourRequestAreReturned()
        {
            //Arrange
            var csvParser = ParserCreator.GetParser(ParserFactory.ParserSort.CSVParser);
            string csvFilePath = @"Data\CorrectCsvData.csv";

            //Action
            List<Order> orders = csvParser.GetOrdersFromFile(csvFilePath);
            IList<string> errorMessages = ((CSVParser)csvParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(4, orders.Count);
            Assert.AreEqual(0, errorMessages.Count);
        }

        [TestMethod]
        [DeploymentItem(".\\Properties\\MissingTagCsvData.csv", "Data")]
        public void GetRequestsFromCSVFile_ThreeRowsAreMissingValue_OneRequestIsReturned()
        {
            //Arrange
            var csvParser = ParserCreator.GetParser(ParserFactory.ParserSort.CSVParser);
            string csvFilePath = @"Data\MissingTagCsvData.csv";

            //Action
            List<Order> orders = csvParser.GetOrdersFromFile(csvFilePath);
            IList<string> errorMessages = ((CSVParser)csvParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(3, errorMessages.Count);
        }

        [TestMethod]
        [DeploymentItem(".\\Properties\\CLientIdAndRequestNameUnvalid.csv", "Data")]
        public void GetRequestsFromCSVFile_ThreeRowsHaveInvalidValue_OneRequestIsReturned()
        {
            //Arrange
            var csvParser = ParserCreator.GetParser(ParserFactory.ParserSort.CSVParser);
            string csvFilePath = @"Data\CLientIdAndRequestNameUnvalid.csv";

            //Action
            List<Order> orders = csvParser.GetOrdersFromFile(csvFilePath);
            IList<string> errorMessages = ((CSVParser)csvParser).GetErrorMessages();

            //Assert
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(3, errorMessages.Count);
        }
    }
}
