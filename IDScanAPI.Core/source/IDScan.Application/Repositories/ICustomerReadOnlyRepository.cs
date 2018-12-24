namespace IDScan.Application.Repositories {
    using System.Threading.Tasks;
    using System;
    using IDScan.Domain.Customers;

    public interface ICustomerReadOnlyRepository {
        Task<Customer> Get (Guid id);
    }
}