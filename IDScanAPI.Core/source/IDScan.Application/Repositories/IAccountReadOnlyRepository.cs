namespace IDScan.Application.Repositories {
    using System.Threading.Tasks;
    using System;
    using IDScan.Domain.Accounts;

    public interface IAccountReadOnlyRepository {
        Task<Account> Get (Guid id);
    }
}