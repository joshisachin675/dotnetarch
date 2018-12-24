namespace IDScan.Application.Repositories {
    using System.Threading.Tasks;
    using IDScan.Domain.Accounts;

    public interface IAccountWriteOnlyRepository {
        Task Add (Account account, Credit credit);
        Task Update (Account account, Credit credit);
        Task Update (Account account, Debit debit);
        Task Delete (Account account);
    }
}