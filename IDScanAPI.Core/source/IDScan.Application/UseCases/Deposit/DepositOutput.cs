namespace IDScan.Application.UseCases.Deposit {
    using IDScan.Domain.Accounts;
    using IDScan.Domain.ValueObjects;

    public sealed class DepositOutput {
        public TransactionOutput Transaction { get; }
        public decimal UpdatedBalance { get; }

        public DepositOutput (
            Credit credit,
            Amount updatedBalance) {
            Transaction = new TransactionOutput (
                credit.Description,
                credit.Amount,
                credit.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}