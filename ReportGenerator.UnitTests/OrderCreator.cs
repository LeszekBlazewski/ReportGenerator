using ReportGenerator.Utilities;
using System.Collections.Generic;

namespace ReportGenerator.UnitTests
{
    /// <summary>
    /// Class contains methods which create specific data to fill the database for various unit tests.
    /// </summary>
    class OrderCreator
    {
        /// <summary>
        /// Creates list of three orders where two orders refer to same request id.
        /// Used in tests to check if order aggregation based on request id works.
        /// </summary>
        /// <returns>list of orders </returns>
        public static List<Order> CreateOrders_TwoOrdersWithSameReuquestId()
        {
            List<Order> orders = new List<Order>();

            // Add two orders to list
            for (int i = 1; i < 3; i++)
            {
                orders.Add(new Order
                {
                    ClientId = "id" + i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i * 12,
                    Price = 12.2m,
                });
            }

            // Add next order with same request id to database to check whether orders will be aggregated
            orders.Add(new Order
            {
                ClientId = "id",
                RequestId = 1,
                Name = "Roll",
                Quantity = 10,
                Price = 10.0m,
            });

            return orders;
        }

        /// <summary>
        /// Creates list of three orders.
        /// Two orders refere to same clientId and two orders refere to same request id.
        /// Used to check if aggregation of orders for specific client works.
        /// </summary>
        /// <returns>list of orders</returns>
        public static List<Order> CreateOrders_ForSpecificCLient_TwoOrdersWithSameRequestId(string clientId)
        {
            List<Order> orders = new List<Order>();
            // Create two orders
            for (int i = 1; i < 3; i++)
            {
                orders.Add(new Order
                {
                    ClientId = "id" + i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i * 12,
                    Price = 12.2m,
                });
            }

            // Add order for client with same request id and clientId to database to check whether orders will be aggregated
            orders.Add(new Order
            {
                ClientId = clientId,
                RequestId = 1,
                Name = "Roll",
                Quantity = 10,
                Price = 10.0m,
            });

            return orders;
        }

        /// <summary>
        /// Creates single order for client based on parameters.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="requestId"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static Order CreateOrder(string clientId, long requestId, string name, int quantity, decimal price)
        {
            Order order = new Order
            {
                ClientId = clientId,
                RequestId = requestId,
                Name = name,
                Quantity = quantity,
                Price = price
            };

            return order;
        }

        /// <summary>
        /// Creates four orders.
        /// Two orders have the same name, so they should be aggregated durning tests.
        /// </summary>
        /// <returns></returns>
        public static List<Order> CreateOrdersForGroupByNameTest()
        {
            List<Order> orders = new List<Order>();
            // Add two orders to database
            for (int i = 1; i < 3; i++)
            {
                orders.Add(new Order
                {
                    ClientId = "id" + i,
                    RequestId = i,
                    Name = "Roll",
                    Quantity = i,
                    Price = 1.5m + i,
                });
            }

            // add order with same request id but different name
            orders.Add(new Order
            {
                ClientId = "id",
                RequestId = 1,
                Name = "Stuck",
                Quantity = 1,
                Price = 1.5m,
            });

            // add order with same request id  && client id but different name
            orders.Add(new Order
            {
                ClientId = "id" + 1,
                RequestId = 2,
                Name = "Car",
                Quantity = 1,
                Price = 1.5m,
            });

            return orders;
        }
    }
}
