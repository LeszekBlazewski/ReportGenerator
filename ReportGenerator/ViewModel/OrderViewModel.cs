using ReportGenerator.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ReportGenerator.ViewModel
{
    class OrderViewModel
    {
        private readonly OrdersDatabase database;

        public OrderViewModel()
        {
            database = new OrdersDatabase();
        }
        
        // ** THIS FUNCTION MIGHT BE USED TO INSERT ROW INTO DATABASE DIRECTLY FROM THE APP NOT FROM PARSERS**
        public void AddNewOrder(Order order)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                database.Orders.Insert(order);
                tran.Complete();
            }
        }

        public void AddNewOrder(List<Order> orders)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                orders.ForEach(report => database.Orders.Insert(report));
                tran.Complete();
            }
        }

        public List<Order> GetAllOrdersForSpecificClient(string clientId)
        {
            var orders = database.Orders.ToList();
            List<Order> clientOrders = orders.Where(order => order.ClientId == clientId).ToList();

            return clientOrders;
        }

        public List<Order> GetAllOrders()
        {
            var orders = database.Orders.ToList();
            return orders;
        }
    }
}
