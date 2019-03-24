using ReportGenerator.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ReportGenerator.ViewModel
{
    class OrderViewModel
    {
        private readonly OrdersDatabase database = new OrdersDatabase();

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

        public List<Order> GetAllOrders()
        {
            var orders = database.Orders
                                       .Select(x => new Order { RequestId = x.RequestId, Price = (x.Price * x.Quantity) })
                                       .GroupBy(order => order.RequestId)
                                       .Select(g => new Order { RequestId = g.Key, Price = g.Sum(x => x.Price) })
                                       .ToList();
            return orders;
        }

        public List<Order> GetAllOrdersForSpecificClient(string clientId)
        {
            var clientOrders = database.Orders
                                      .Select(x => new Order { RequestId = x.RequestId, ClientId = x.ClientId, Price = (x.Price * x.Quantity) })
                                      .Where(z => z.ClientId == clientId)
                                      .GroupBy(order => order.RequestId)
                                      .Select(g => new Order { RequestId = g.Key, Price = g.Sum(x => x.Price) })
                                      .ToList();

            return clientOrders;
        }

        public int GetNumberOfOrders()
        {
            return database.Orders
                                 .Select(order => order.RequestId)
                                 .Distinct()
                                 .Count();
        }

        public int GetNumberOfOrdersForSpecificClient(string clientId)
        {
            return database.Orders
                                 .Select(x => new Order { RequestId = x.RequestId, ClientId = x.ClientId })
                                 .Where(z => z.ClientId == clientId)
                                 .GroupBy(order => order.RequestId)
                                 .Select(g => g.Key)
                                 .Count();
        }

        public decimal GetTotalPriceOfOrders()
        {
            decimal totalPrice = database.Orders
                                                .Select(x => new Order { RequestId = x.RequestId, Price = (x.Price * x.Quantity) })
                                                .GroupBy(order => order.RequestId)
                                                .Sum(x => x.Sum(y => y.Price));
            return totalPrice;
        }

        public decimal GetTotalPriceOfOrdersForSpecificClient(string clientId)
        {
            var totalPriceOfOrdersForClient = database.Orders
                                                             .Select(x => new Order { RequestId = x.RequestId,ClientId = x.ClientId, Price = (x.Price * x.Quantity)})
                                                             .Where(z => z.ClientId == clientId)
                                                             .GroupBy(order => order.RequestId)
                                                             .Sum(x => x.Sum(y => y.Price));

            return totalPriceOfOrdersForClient;
        }

 
        public decimal GetAveragePriceOfOrder()
        {
            decimal averagePriceOfOrder = database.Orders
                                                        .Select(x => new Order { RequestId = x.RequestId, Price = (x.Price * x.Quantity) })
                                                        .GroupBy(order => order.RequestId)
                                                        .Average(x => x.Sum(y => y.Price));

            return averagePriceOfOrder;
        }

        public decimal GetAveragePriceOfOrderOfSpecificClient(string clientId)
        {
            decimal averagePriceOfOrder = database.Orders
                                                       .Select(x => new Order { RequestId = x.RequestId, ClientId = x.ClientId, Price = (x.Price * x.Quantity) })
                                                       .Where(order => order.ClientId == clientId)
                                                       .GroupBy(order => order.RequestId)
                                                       .Average(x => x.Sum(y => y.Price));
            return averagePriceOfOrder;
        }

        public List<Order> GetNumberOfOrdersGroupedByName()
        {
            var orders = database.Orders
                                        .Select(x => new Order { RequestId = x.RequestId, Name = x.Name, Quantity = x.Quantity })
                                        .GroupBy(order => order.Name )
                                        .Select(g => new Order { Name = g.Key, Quantity = g.Sum(z => z.Quantity) }) 
                                        .ToList();

            return orders;
        }

        public List<Order> GetNumberOfOrdersGroupedByNameForSpecificClient(string clientId)
        {
            var clientOrders = database.Orders
                                       .Select(x => new Order { RequestId = x.RequestId, Name = x.Name, Quantity = x.Quantity, ClientId = x.ClientId })
                                       .Where(z => z.ClientId == clientId)
                                       .GroupBy(order => order.Name)
                                       .Select(g => new Order { Name = g.Key, Quantity = g.Sum(z => z.Quantity) })
                                       .ToList();

            return clientOrders;
        }

        public List<Order> GetOrdersInGivenRange(decimal lowerBound, decimal upperBound)
        {
            var ordersInGivenPriceInterval = database.Orders
                                                            .Select(x => new Order { RequestId = x.RequestId, Price = (x.Price * x.Quantity) })
                                                            .GroupBy(order => order.RequestId)
                                                            .Select(g => new Order { RequestId = g.Key, Price = g.Sum(x => x.Price) })
                                                            .Where(z => z.Price >= lowerBound && z.Price <= upperBound)
                                                            .ToList();

            return ordersInGivenPriceInterval;
        }

        public List<Order> GetAllRequests()
        {
            return database.Orders.ToList();
        }
    }
}
