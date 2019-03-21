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

        public List<Order> GetAllOrdersForSpecificClient(string clientId)
        {
            var clientOrders = database.Orders.Select(x => new Order { RequestId = x.RequestId, ClientId = clientId, Price = (x.Price * x.Quantity) })
                                      .Where(z => z.ClientId == clientId)
                                      .GroupBy(order => order.RequestId)
                                      .Select(g => new Order { RequestId = g.Key, Price = g.Sum(x => x.Price) })
                                      .ToList();

            return clientOrders;
        }

        public List<Order> GetAllOrders()
        {
           var orders = database.Orders.Select(x => new Order { RequestId = x.RequestId, Price = (x.Price * x.Quantity) })
                                      .GroupBy(order => order.RequestId)
                                      .Select(g => new Order { RequestId = g.Key, Price = g.Sum(x => x.Price) })
                                      .ToList();
           return orders;
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
