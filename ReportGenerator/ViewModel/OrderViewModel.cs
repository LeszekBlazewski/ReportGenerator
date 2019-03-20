using ReportGenerator.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ReportGenerator.ViewModel
{
    class OrderViewModel
    {
        private readonly OrdersDatabase database = new OrdersDatabase();

        // ** THIS FUNCTION MIGHT BE USED TO INSERT ROW INTO DATABASE DIRECTLY FROM THE APP NOT FROM PARSERS**
        public void AddNewOrder(Order order)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                database.Orders.Insert(order);
                tran.Complete();
            }
        }

        public void AddNewOrders(List<Order> orders)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                orders.ForEach(report => database.Orders.Insert(report));
                tran.Complete();
            }
        }

        //TODO: REPAIR
        public List<Order> GetAllOrdersForSpecificClient(string clientId)
        {
            var orders = database.Orders.ToList();
            List<Order> clientOrders = orders.Where(order => order.ClientId == clientId).ToList();

            return clientOrders;
        }

        public List<dynamic> GetAllOrders()
        {
            var query = (from order in database.Orders
                        select new { order.RequestId, Value = order.Price * order.Quantity })
                        .GroupBy(order => order.RequestId).ToList<dynamic>();
            return query;
        }

        public int GetNumberOfOrders()
        {
            return database.Orders.Select(order => order.RequestId).Distinct().Count();
        }

        public int GetNumberOfOrdersForSpecificClient(string clientId)
        {
            return database.Orders.Where(order => order.ClientId == clientId).Select(order => order.RequestId).Distinct().Count();
        }

        //TODO: CHECK IF THIS WORKS
        public decimal TotalPriceOfOrders()
        {
            return database.Orders.Sum(order => (order.Price * order.Quantity));
        }

        //TODO: CHECK IF THIS WORKS
        public decimal TotalPriceOfOrdersForSpecificClient(string clientId)
        {
            return database.Orders.Where(order => order.ClientId == clientId).Sum(order => (order.Price * order.Quantity));
        }

        //TODO: FIX
        public decimal AveragePriceOfOrder()
        {
            return database.Orders.Average(order => order.Price);
        }
        //TODO: FIX
        public decimal AveragePriceOfOrderOfSpecificClient(string clientId)
        {
            return database.Orders.Where(order => order.ClientId == clientId).Average(order => order.Price);
        }

        public void NumberOfRequestsGroupedByName()
        {

        }
    }
}
