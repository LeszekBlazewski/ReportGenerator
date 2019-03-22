using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGenerator.Utilities;
using ReportGenerator.ViewModel;

namespace ReportGenerator.UnitTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CreateNewValidOrder_OrderIsAddedInDatabase_ObjectIsInDatabase()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            Order order = OrderCreator.CreateOrder("Client", 124, "Roll", 1, 12.2m);

            //Action
            viewModel.AddNewOrder(order);
            int numberOfOrders = viewModel.GetNumberOfOrders();

            //Assert
            Assert.AreEqual(1, numberOfOrders);
        }

        [TestMethod]
        public void CreateNewUnvalidOrderClientIdToLong_OrderIsNotAdded_ObjectIsNotInserted()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string unvalidCLientId = "Client123";   // client_id can obly be 6 characters long
            Order order = OrderCreator.CreateOrder(unvalidCLientId, 1243465, "Roll", 1, 12.2m); //pass CLientId longer than 6 characters
           

            //Action && Assert
            Assert.ThrowsException<NMemory.Exceptions.ConstraintException>(() => viewModel.AddNewOrder(order));
        }

        [TestMethod]
        public void CreateNewUnvalidOrderNameToLong_OrderIsNotAdded_ObjectIsNotInserted()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string orderName = new string('a', 256);    // create string which contains 256 'a' characters
            Order order = OrderCreator.CreateOrder("Client", 1243465, orderName, 1, 12.2m); //pass orderName longer tahn 255 chars


            //Action && Assert
            Assert.ThrowsException<NMemory.Exceptions.ConstraintException>(() => viewModel.AddNewOrder(order));
        }

        [TestMethod]
        public void FetchAllOrders_NoOrderdsInDatabase_NoneOrdersAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();

            //Action
            var orders = viewModel.GetAllOrders();

            //Assert
            Assert.IsTrue(0 == orders.Count);
        }

        [TestMethod]
        public void FetchAllOrders_OrdersAreInDatabase_AllOrdersAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            // create three orders where 2 refere to same request id 
            var ordersToAdd = OrderCreator.CreateOrders_TwoOrdersWithSameReuquestId();
            // add them to database
            viewModel.AddNewOrders(ordersToAdd);

            //Action
            var orders = viewModel.GetAllOrders();
            //Assert
            Assert.IsTrue(2 == orders.Count);
        }

        [TestMethod]
        public void FetchAllOrdersForSpecificClient_OrdersDontExistInDatabase_NoOrdersAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
 
            //Action
            var clientOrders = viewModel.GetAllOrdersForSpecificClient("cli");

            //Assert
            Assert.AreEqual(0,clientOrders.Count);
        }

        [TestMethod]
        public void FetchAllOrdersForSpecificClient_OrdersExistInDatabase_OrdersForClientAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string clientId = "id1";
            var orderForSpecificCLientToAdd = OrderCreator.CreateOrders_ForSpecificCLient_TwoOrdersWithSameRequestId(clientId);
            viewModel.AddNewOrders(orderForSpecificCLientToAdd);

            //Action
            var clientOrders = viewModel.GetAllOrdersForSpecificClient(clientId);

            //Assert
            Assert.AreEqual(1,clientOrders.Count);
        }

        [TestMethod]
        public void GetNumberOfOrders_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            var ordersToAdd = OrderCreator.CreateOrders_TwoOrdersWithSameReuquestId();
            viewModel.AddNewOrders(ordersToAdd);

            //Action
            int numberOfOrders = viewModel.GetNumberOfOrders();

            //Assert
            Assert.AreEqual(2,numberOfOrders);
        }

        [TestMethod]
        public void GetNumberOfOrdersForSpecificClient_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string clientId = "id1";
            var ordersToAdd = OrderCreator.CreateOrders_ForSpecificCLient_TwoOrdersWithSameRequestId(clientId);
            viewModel.AddNewOrders(ordersToAdd);

            //Action
            int numberOfOrdersForClient = viewModel.GetNumberOfOrdersForSpecificClient(clientId);

            //Assert
            // There are three orders in database, but only two refere to client id ("id1"), and those two orders
            // refere to same request_id so in fact client has only one order 
            Assert.AreEqual(1,numberOfOrdersForClient);
        }

        [TestMethod]
        public void GetTotalPriceOfOrders_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            var ordersToAdd = OrderCreator.CreateOrders_TwoOrdersWithSameReuquestId();
            viewModel.AddNewOrders(ordersToAdd);
            decimal result = 539.2m;       // calculated based on the orders added into database
                                           // first request => 12 * 12.2m = 146.4, second request => 24 * 12.2 = 292.8, third request => 10*10 = 100
                                           // sum = 539.2
            //Action
            decimal totalPriceOfOrders = viewModel.GetTotalPriceOfOrders();
            //Assert
            Assert.AreEqual(result, totalPriceOfOrders);
        }

        [TestMethod]
        public void GetTotalPriceOfOrdersForSpecificClient_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            string clientId = "id1";
            var viewModel = new OrderViewModel();
            var ordersToAdd = OrderCreator.CreateOrders_ForSpecificCLient_TwoOrdersWithSameRequestId(clientId);
            viewModel.AddNewOrders(ordersToAdd);
            decimal result = 246.4m;      // calculated based on the orders added into database for specific client
                                         // first request => 12 * 12.2 + 10 * 10 = 246.4 because first and second order have same request_id
                                        // sum = 246.4


            //Action
            decimal totalPriceOfOrdersForClient = viewModel.GetTotalPriceOfOrdersForSpecificClient("id1");
           
            //Assert
            Assert.AreEqual(result, totalPriceOfOrdersForClient);
        }

        [TestMethod]
        public void GetAveragePriceOfOrder_OrdersExistInDatabase_AveragePriceIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            var ordersToAdd = OrderCreator.CreateOrders_TwoOrdersWithSameReuquestId();
            viewModel.AddNewOrders(ordersToAdd);
            decimal average = 269.6m;  // calculated based on the orders added into database
                                       // first request => 12 * 12.2 + 10 * 10 = 246.4, second request => 24 * 12.2 = 292.8
                                       // Average = 269.6
            decimal averagePrice = viewModel.GetAveragePriceOfOrder();

            //Assert
            Assert.AreEqual(average, averagePrice);
        }

        [TestMethod]
        public void GetAveragePriceOfOrderOfSpecificClient_OrdersExistInDatabase_AveragePriceIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string clientId = "id1";
            var ordersToAdd = OrderCreator.CreateOrders_ForSpecificCLient_TwoOrdersWithSameRequestId(clientId);
            var orderWithDifferentRequestIdForSameClient = OrderCreator.CreateOrder(clientId, 2, "Roll", 2, 4m);
            viewModel.AddNewOrder(orderWithDifferentRequestIdForSameClient);
            viewModel.AddNewOrders(ordersToAdd);
            decimal average = 127.2m;    // calculated based on the orders added into database for specific client
                                        // first request => 12 * 12.2 + 10 * 10 = 246.4 because first and second order have same request_id
                                        // second request => 2 * 4 = 8
                                        // average = 127.2

            //Action
            decimal averagePrice = viewModel.GetAveragePriceOfOrderOfSpecificClient("id1");

            //Assert
            Assert.AreEqual(average, averagePrice);
        }


        [TestMethod]
        public void GetNumberOfRequestsGroupedByName_OrdersExistInDatabase_GrouppedRequestsAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            var ordersToAdd = OrderCreator.CreateOrdersForGroupByNameTest();
            viewModel.AddNewOrders(ordersToAdd);

            //Action
            var groupedOrders = viewModel.GetNumberOfOrdersGroupedByName();

            //Assert
            // only 3 orders should be returned because two orders referee to same name
            Assert.AreEqual(3, groupedOrders.Count);
        }

        [TestMethod]
        public void GetNumberOfRequestsGroupedByNameForSpecificClient_OrdersExistInDatabase_GrouppedRequestsAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            var ordersToAdd = OrderCreator.CreateOrdersForGroupByNameTest();
            viewModel.AddNewOrders(ordersToAdd);
           

            var groupedOrdersForClient = viewModel.GetNumberOfOrdersGroupedByNameForSpecificClient("id1");

            // Assert
            // Only 2 orders should be returned because two orders referee to same name
            Assert.AreEqual(2, groupedOrdersForClient.Count);
        }

        [TestMethod]
        public void GetOrdersInGivenRange_OrdersExistInDatabase_OrdersInGivenRangeAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            decimal lowerBound = 1.5m;
            decimal upperBound = 5.7m;
            var ordersToAdd = OrderCreator.CreateOrders_TwoOrdersWithSameReuquestId();

           
            //Action
            var ordersInGivenRange = viewModel.GetOrdersInGivenRange(lowerBound, upperBound);

            // Assert
            // Orders in range( price >= lowerBound && price <= upperBound) are returned
            ordersInGivenRange.ForEach(order => Assert.IsTrue(order.Price >= lowerBound && order.Price <= upperBound));
        }
    }
}
