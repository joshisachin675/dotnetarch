namespace IDScan.Application.UseCases.Deposit {
    using System.Threading.Tasks;
    using System;
    using IDScan.Domain.ValueObjects;

    public interface IDepositUseCase {
        Task<DepositOutput> Execute (Guid accountId, Amount amount);
    }
}