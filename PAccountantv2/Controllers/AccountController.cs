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

        [HttpPost]
        public async Task<IActionResult> AddNewAccount(int acctingId)
        {
           var acId = await _service.CreateNewAccountAsync(acctingId);

            return Ok(acId);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountBalance(int id)
        {
            var viewItem = await _service.GetBalanceAsync(id);
            var viewModel = _mapper.Map<AccountBalanceViewModel>(viewItem);

            return Ok(viewModel);
        }

        [Route("{id}/add")]
        [HttpPut]
        public async Task<IActionResult> AddMoneyToAccount(int id, MoneyChangeViewModel model)
        {
            var viewItem = _mapper.Map<MoneyChangeViewItem>(model);
            await _service.AddMoneyAsync(id, viewItem);

            return Ok();
        }

        [Route("{id}/withdraw")]
        [HttpPut]
        public async Task<IActionResult> WithdrawMoneyFromAccount(int id, MoneyChangeViewModel model)
        {
            var viewItem = _mapper.Map<MoneyChangeViewItem>(model);
            await _service.WithdrawMoneyAsync(id, viewItem);

            return Ok();
        }

        [Route("{id}/history")]
        [HttpGet]
        public async Task<IActionResult> GetAccountHistory(int id)
        {
            var historyItems = await _service.GetHistoryAsync(id);
            var historyViewModel = _mapper.Map<IEnumerable<AccountOperationViewModel>>(historyItems);

            return Ok(historyViewModel);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _service.DeleteAccount(id);

            return Ok();
        }
    }
}