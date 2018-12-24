namespace IDScan.Application.UseCases.Withdraw {
    using System.Threading.Tasks;
    using System;
    using IDScan.Domain.ValueObjects;

    public interface IWithdrawUseCase {
        Task<WithdrawOutput> Execute (Guid accountId, Amount amount);
    }
}