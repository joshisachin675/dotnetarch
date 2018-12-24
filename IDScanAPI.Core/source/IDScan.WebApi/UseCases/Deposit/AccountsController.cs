namespace IDScan.WebApi.UseCases.Deposit {
    using System.Threading.Tasks;
    using IDScan.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class AccountsController : Controller {
        private readonly IDepositUseCase _depositUseCase;
        private readonly Presenter _presenter;

        public AccountsController (
            IDepositUseCase depositUseCase,
            Presenter presenter) {
            _depositUseCase = depositUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Deposit to an account
        /// </summary>
        [HttpPatch ("Deposit")]
        public async Task<IActionResult> Deposit ([FromBody] DepositRequest message) {
            var output = await _depositUseCase.Execute (message.AccountId, message.Amount);
            _presenter.Populate (output);
            return _presenter.ViewModel;
        }
    }
}