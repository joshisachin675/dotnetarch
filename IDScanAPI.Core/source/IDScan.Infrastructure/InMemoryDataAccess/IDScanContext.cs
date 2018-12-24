namespace IDScan.Infrastructure.InMemoryDataAccess {
    using System.Collections.ObjectModel;
    using IDScan.Domain.Accounts;
    using IDScan.Domain.Customers;

    public sealed class IDScanContext {
        public Collection<Customer> Customers { get; set; }
        public Collection<Account> Accounts { get; set; }


        public IDScanContext () {
            Customers = new Collection<Customer> ();
            Accounts = new Collection<Account> ();
        }
    }
}