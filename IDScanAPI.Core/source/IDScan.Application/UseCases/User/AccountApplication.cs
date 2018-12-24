namespace IDScan.Application.UseCases.User
{
    using IDScan.Application.Repositories;
    using IDScan.Domain;

    public sealed class AccountApplication  : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        public AccountApplication (IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public UserDTO CheckUserExistWithEmailAndAdd(UserDTO objUser)
        {

          return  _accountRepository.CheckUserExistWithEmailAndAdd(objUser);
        }


        }
    }
