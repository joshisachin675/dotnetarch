namespace IDScan.Application.UseCases.Withdraw {
    using IDScan.Domain.Accounts;
    using IDScan.Domain.ValueObjects;

    public sealed class WithdrawOutput {
        public TransactionOutput Transaction { get; }
        public decimal UpdatedBalance { get; }

        public WithdrawOutput (Debit transaction, Amount updatedBalance) {
            Transaction = new TransactionOutput (
                transaction.Description,
                transaction.Amount,
                transaction.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}