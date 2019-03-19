using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Utilities
{
    class ReportBuilder
    {
        private Order _report;

        public void BuildReport(string clientId, long requestId, string name, int quantity, decimal price)
        {
            _report = new Order
            {
                ClientId = clientId,
                RequestId = requestId,
                Name = name,
                Quantity = quantity,
                Price = price
            };
        }

        public Order GetReport() => _report;
    }
}
