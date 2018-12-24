namespace IDScan.Infrastructure.EntityFrameworkDataAccess
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using IDScan.Application.Repositories;
    using IDScan.Domain.Accounts;
    using Microsoft.EntityFrameworkCore;
    using IDScan.Domain;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository, IAccountRepository
    {
        private readonly IDScanContext _context;

        public AccountRepository(IDScanContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public UserDTO CheckUserExistWithEmailAndAdd(UserDTO objUser)
        {
            bool checkUser = _context.Users.Any(x => x.Email == objUser.Email & x.IsActive == true && x.IsDeleted == false);
            if (!checkUser)
            {
                //Entities.User user = new Entities.User();
                Entities.User userEntity = new Entities.User()
                {
                    UserID = Guid.NewGuid().ToString().ToUpper(),
                    FirstName = objUser.FirstName,
                    LastName = objUser.LastName,
                    UserName = objUser.UserName,
                    Email = objUser.Email,
                    Password = objUser.Password,
                    Identifier = objUser.Identifier,
                    IsActive = true,
                    IsDeleted = false,
                    Role = objUser.Role,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = objUser.CreatedBy,
                    DeletedBy = objUser.DeletedBy,
                    DeletedDate = objUser.DeletedDate,
                    LoginProvider = objUser.LoginProvider,
                    ProfileImage = objUser.ProfileImage,
                };
                _context.Users.Add(userEntity);
                _context.SaveChanges();
            }
            return new UserDTO();
        }


        public async Task Add(Account account, Credit credit)
        {
            Entities.Account accountEntity = new Entities.Account()
            {
                CustomerId = account.CustomerId,
                Id = account.Id
            };

            Entities.Credit creditEntity = new Entities.Credit()
            {
                AccountId = credit.AccountId,
                Amount = credit.Amount,
                Id = credit.Id,
                TransactionDate = credit.TransactionDate
            };

            await _context.Accounts.AddAsync(accountEntity);
            await _context.Credits.AddAsync(creditEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Account account)
        {
            string deleteSQL =
                @"DELETE FROM Credit WHERE AccountId = @Id;
                      DELETE FROM Debit WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            int affectedRows = await _context.Database.ExecuteSqlCommandAsync(
                deleteSQL, id);
        }

        public async Task<Account> Get(Guid id)
        {
            Entities.Account account = await _context
                .Accounts
                .FindAsync(id);

            List<Entities.Credit> credits = await _context
                .Credits
                .Where(e => e.AccountId == id)
                .ToListAsync();

            List<Entities.Debit> debits = await _context
                .Debits
                .Where(e => e.AccountId == id)
                .ToListAsync();

            List<ITransaction> transactions = new List<ITransaction>();

            foreach (Entities.Credit transactionData in credits)
            {
                Credit transaction = Credit.LoadFromDetails(
                    transactionData.Id,
                    transactionData.AccountId,
                    transactionData.Amount,
                    transactionData.TransactionDate);

                transactions.Add(transaction);
            }

            foreach (Entities.Debit transactionData in debits)
            {
                Debit transaction = Debit.LoadFromDetails(
                    transactionData.Id,
                    transactionData.AccountId,
                    transactionData.Amount,
                    transactionData.TransactionDate);

                transactions.Add(transaction);
            }

            var orderedTransactions = transactions.OrderBy(o => o.TransactionDate).ToList();

            TransactionCollection transactionCollection = new TransactionCollection();
            transactionCollection.Add(orderedTransactions);

            Account result = Account.LoadFromDetails(
                account.Id,
                account.CustomerId,
                transactionCollection);

            return result;
        }

        public async Task Update(Account account, Credit credit)
        {
            Entities.Credit creditEntity = new Entities.Credit
            {
                AccountId = credit.AccountId,
                Amount = credit.Amount,
                Id = credit.Id,
                TransactionDate = credit.TransactionDate
            };

            await _context.Credits.AddAsync(creditEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Account account, Debit debit)
        {
            Entities.Debit debitEntity = new Entities.Debit
            {
                AccountId = debit.AccountId,
                Amount = debit.Amount,
                Id = debit.Id,
                TransactionDate = debit.TransactionDate
            };

            await _context.Debits.AddAsync(debitEntity);
            await _context.SaveChangesAsync();
        }
    }
}