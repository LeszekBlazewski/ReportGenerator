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
                RequestId = 1243465,
                Name = "Roll",
                Quantity = 1,
                Price = 12.2m,
            };

            //Action
            viewModel.AddNewOrder(order);
            var clientOrdersInDatabase = viewModel.GetAllOrdersForSpecificClient("Client");
            //Assert
            clientOrdersInDatabase.ForEach(entry => Assert.AreEqual(entry.ClientId, order.ClientId));
        }

        [TestMethod]
        public void CreateNewUnvalidOrderClientIdToLong_ReportIsNotAdded_ObjectIsNotInserted()
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

            //Action
            Assert.ThrowsException<NMemory.Exceptions.ConstraintException>(() => viewModel.AddNewOrder(order));
        }
    }
}
