namespace IDScan.Application.UseCases.Register {
    using System.Threading.Tasks;
    using IDScan.Domain.ValueObjects;

    public interface IRegisterUseCase {
        Task<RegisterOutput> Execute (Personnummer personnummer, Name name, Amount initialAmount);
    }
}