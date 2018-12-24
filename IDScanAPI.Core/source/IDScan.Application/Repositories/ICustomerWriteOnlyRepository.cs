namespace IDScan.Application.Repositories {
    using System.Threading.Tasks;
    using IDScan.Domain.Customers;

    public interface ICustomerWriteOnlyRepository {
        Task Add (Customer customer);
        Task Update (Customer customer);
    }
}