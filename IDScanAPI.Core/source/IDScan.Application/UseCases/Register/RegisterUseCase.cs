namespace IDScan.Application.UseCases.Register {
    using System.Threading.Tasks;
    using IDScan.Application.Repositories;
    using IDScan.Domain.Accounts;
    using IDScan.Domain.Customers;
    using IDScan.Domain.ValueObjects;

    public sealed class RegisterUseCase : IRegisterUseCase {
        private readonly ICustomerWriteOnlyRepository _customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

        public RegisterUseCase (
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository) {
            _customerWriteOnlyRepository = customerWriteOnlyRepository;
            _accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<RegisterOutput> Execute (Personnummer personnummer, Name name, Amount initialAmount) {
            Customer customer = new Customer (personnummer, name);

            Account account = new Account (customer.Id);
            account.Deposit (initialAmount);
            Credit credit = (Credit) account.GetLastTransaction ();

            customer.Register (account.Id);

            await _customerWriteOnlyRepository.Add (customer);
            await _accountWriteOnlyRepository.Add (account, credit);

            RegisterOutput output = new RegisterOutput (customer, account);
            return output;
        }
    }
}