using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.Host.Domain.ViewModels.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/accounting/{acctingId}/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAccountService _service;

        public AccountController(IMapper mapper, IAccountService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Create new account in the accounting
        /// </summary>
        /// <param name="acctingId">id of accounting to create in</param>
        /// <response code="200">new account id</response>
        [HttpPost]
        public async Task<IActionResult> AddNewAccount(int acctingId)
        {
            var acId = await _service.CreateNewAccountAsync(acctingId);

            return Ok(acId);
        }

        /// <summary>
        /// Get balance of the account
        /// </summary>
        /// <param name="id">account to get id</param>
        /// <response code="200">account balance</response>
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountBalance(int id)
        {
            var viewItem = await _service.GetBalanceAsync(id);
            var viewModel = _mapper.Map<AccountBalanceViewModel>(viewItem);

            return Ok(viewModel);
        }

        /// <summary>
        /// Add money to account
        /// </summary>
        /// <param name="id">id of account to get</param>
        /// <param name="model">model of money amount to add</param>
        [Route("{id}/add")]
        [HttpPut]
        public async Task<IActionResult> AddMoneyToAccount(int id, MoneyChangeViewModel model)
        {
            var viewItem = _mapper.Map<MoneyChangeViewItem>(model);
            await _service.PutMoneyAsync(id, viewItem);

            return Ok();
        }

        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="id">id of account to withdraw</param>
        /// <param name="model">model of money amount to widthdraw</param>
        [Route("{id}/withdraw")]
        [HttpPut]
        public async Task<IActionResult> WithdrawMoneyFromAccount(int id, MoneyChangeViewModel model)
        {
            var viewItem = _mapper.Map<MoneyChangeViewItem>(model);
            await _service.WithdrawMoneyAsync(id, viewItem);

            return Ok();
        }

        /// <summary>
        /// Get account history by filters
        /// </summary>
        /// <param name="id">id of account to get</param>
        /// <param name="filters">filters model</param>
        /// <response code="200">history of account operations filtered</response>
        [Route("{id}/history")]
        [HttpGet]
        public async Task<IActionResult> GetAccountHistory(int id, [FromQuery]AccountHistoryFiltersViewModel filters)
        {
            var dataFilters = _mapper.Map<AccountHistoryFiltersViewItem>(filters);

            var historyItems = await _service.GetHistoryAsync(id, dataFilters);
            var historyViewModel = _mapper.Map<IEnumerable<AccountOperationViewModel>>(historyItems);

            return Ok(historyViewModel);
        }

        /// <summary>
        /// Delete account from accounting
        /// </summary>
        /// <param name="id">id of account to delete</param>
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _service.DeleteAccount(id);

            return Ok();
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="id">id of account to update</param>
        /// <param name="model">account update info</param>
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(int id, AccountUpdateViewModel model)
        {
            var mappedModel = _mapper.Map<AccountUpdateViewItem>(model);
            await _service.UpdateAccountAsync(id, mappedModel);

            return Ok();
        }
    }
}