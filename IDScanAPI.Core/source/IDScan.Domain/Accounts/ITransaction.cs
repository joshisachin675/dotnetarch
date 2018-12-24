namespace IDScan.Domain.Accounts {
    using System;
    using IDScan.Domain.ValueObjects;

    public interface ITransaction {
        Amount Amount { get; }
        string Description { get; }
        DateTime TransactionDate { get; }
    }
}