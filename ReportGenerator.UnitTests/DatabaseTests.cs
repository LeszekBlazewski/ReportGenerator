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
            Order order = new Order
            {
                ClientId = "Client",
                RequestId = 124,
                Name = "Roll",
                Quantity = 1,
                Price = 12.2m,
            };

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
            Order order = new Order
            {
                ClientId = "Client123",// client id can only by 6 signs
                RequestId = 1243465,
                Name = "Roll",
                Quantity = 1,
                Price = 12.2m,
            };

            //Action && Assert
            Assert.ThrowsException<NMemory.Exceptions.ConstraintException>(() => viewModel.AddNewOrder(order));
        }

        [TestMethod]
        public void CreateNewUnvalidOrderNameToLong_OrderIsNotAdded_ObjectIsNotInserted()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string orderName = new string('a', 256);
            Order order = new Order
            {
                ClientId = "Client",
                RequestId = 1243465,
                Name = orderName,
                Quantity = 1,
                Price = 12.2m,
            };

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
            // Add two orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = "id" + i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i * 12,
                    Price = 12.2m,
                });
            }
            // Add next order with same request id to database to check whether orders will be aggregated
            viewModel.AddNewOrder(new Order
            {
                ClientId = "id",
                RequestId = 1,
                Name = "Roll",
                Quantity = 10,
                Price = 10.0m,
            });

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
            Assert.IsTrue(0  == clientOrders.Count);
        }

        [TestMethod]
        public void FetchAllOrdersForSpecificClient_OrdersExistInDatabase_OrdersForClientAreReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string clientId = "id1";
            // Add three orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = "id" + i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i * 12,
                    Price = 12.2m,
                });
            }

            // Add order for client with same request id to database to check whether orders will be aggregated
            viewModel.AddNewOrder(new Order
            {
                ClientId = clientId,
                RequestId = 1,
                Name = "Roll",
                Quantity = 10,
                Price = 10.0m,
            });

            //Action
            var clientOrders = viewModel.GetAllOrdersForSpecificClient(clientId);

            //Assert
            Assert.IsTrue(1 == clientOrders.Count);
        }

        [TestMethod]
        public void GetNumberOfOrders_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            // Add three orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = "id" + i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i * 12,
                    Price = 12.2m,
                });
            }

            // Add next order with same request id to database to check whether orders will be aggregated
            viewModel.AddNewOrder(new Order
            {
                ClientId = "id",
                RequestId = 1,
                Name = "Roll",
                Quantity = 10,
                Price = 10.0m,
            });

            //Action
            int numberOfOrders = viewModel.GetNumberOfOrders();

            //Assert
            Assert.IsTrue(2 == numberOfOrders);
        }

        [TestMethod]
        public void GetNumberOfOrdersForSpecificClient_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            string clientId = "id";
            // Add three orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = clientId,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i * 12,
                    Price = 12.2m,
                });
            }

            // Add next order with same request id and client id to database to check whether orders will be aggregated
            viewModel.AddNewOrder(new Order
            {
                ClientId = clientId,
                RequestId = 1,
                Name = "Roll",
                Quantity = 12,
                Price = 12.2m,
            });

            //Action
            int numberOfOrdersForClient = viewModel.GetNumberOfOrdersForSpecificClient(clientId);

            //Assert
            Assert.IsTrue(2 == numberOfOrdersForClient);
        }

        [TestMethod]
        public void GetTotalPriceOfOrders_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            // Add two orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = "id"+i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i,
                    Price = 1.5m + i,
                });
            }
            // add order with same request id to check if data is aggregated correctly
            viewModel.AddNewOrder(new Order
            {
                ClientId = "id",
                RequestId = 1,
                Name = "Roll",
                Quantity = 1,
                Price = 1.5m,
            });

            //Action
            decimal totalPriceOfOrders = viewModel.GetTotalPriceOfOrders();
            decimal result = 11m;
            //Assert
            Assert.AreEqual(result, totalPriceOfOrders);
        }

        [TestMethod]
        public void GetTotalPriceOfOrdersForSpecificClient_OrdersExistInDatabase_NumberOfOrdersIsReturned()
        {
            //Arrange
            var viewModel = new OrderViewModel();
            decimal result = 2.5m;

            // Add two orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = "id",
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i,
                    Price = 1.5m + i,
                });
            }

            //Action
            decimal totalPriceOfOrdersForClient = viewModel.GetTotalPriceOfOrdersForSpecificClient("");
           
            //Assert
            Assert.AreEqual(result, totalPriceOfOrdersForClient);
        }

        [TestMethod]
        public void test()
        {
            OrderViewModel viewModel = new OrderViewModel();

            // Add two orders to database
            for (int i = 1; i < 3; i++)
            {
                viewModel.AddNewOrder(new Order
                {
                    ClientId = "id",
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i,
                    Price = 1.5m + i,
                });
            }

            var orders = viewModel.test();
        }
    }
}
