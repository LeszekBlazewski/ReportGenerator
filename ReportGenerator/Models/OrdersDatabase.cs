using NMemory;
using NMemory.Constraints;
using NMemory.Tables;

namespace ReportGenerator.Utilities
{
    public class OrdersDatabase:Database
    {

        public ITable<Order> Orders { get; private set; }


        public OrdersDatabase()
        {
            var orders = Tables.Create(x => x.Id, new IdentitySpecification<Order>(s => s.Id,1,1));

            // Constrains referring not nullable fields.
            // There are no length restricions because they are validated during parsing process
            orders.Contraints.Add(new NotNullableConstraint<Order, string>(x => x.ClientId));
            orders.Contraints.Add(new NotNullableConstraint<Order, long>(x => x.RequestId));
            orders.Contraints.Add(new NotNullableConstraint<Order, string>(x => x.Name));
            orders.Contraints.Add(new NotNullableConstraint<Order, decimal>(x => x.Price));

            Orders = orders;
        }
    }
}
