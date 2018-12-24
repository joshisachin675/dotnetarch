namespace IDScan.Infrastructure.InMemoryDataAccess.Repositories {
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using IDScan.Application.Repositories;
    using IDScan.Domain.Customers;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository {
        private readonly IDScanContext _context;

        public CustomerRepository (IDScanContext context) {
            _context = context;
        }

        public async Task Add (Customer customer) {
            _context.Customers.Add (customer);
            await Task.CompletedTask;
        }

        public async Task<Customer> Get (Guid id) {
            Customer customer = _context.Customers
                .Where (e => e.Id == id)
                .SingleOrDefault ();

            return await Task.FromResult<Customer> (customer);
        }

        public async Task Update (Customer customer) {
            Customer customerOld = _context.Customers
                .Where (e => e.Id == customer.Id)
                .SingleOrDefault ();

            customerOld = customer;
            await Task.CompletedTask;
        }
    }
}