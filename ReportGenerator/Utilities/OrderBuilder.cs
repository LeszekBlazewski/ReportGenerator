namespace ReportGenerator.Utilities
{
    class OrderBuilder
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
