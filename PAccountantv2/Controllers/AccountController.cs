using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.Host.Domain.ViewModels.Account;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/account")]
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

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountBalance(int id)
        {
            var viewItem = await _service.GetBalanceAsync(id);
            var viewModel = _mapper.Map<AccountBalanceViewModel>(viewItem);

            return Ok(viewModel);
        }

        [Route("{id}/add")]
        [HttpPost]
        public async Task<IActionResult> AddMoneyToAccount(int id, MoneyChangeViewModel model)
        {
            var viewItem = _mapper.Map<MoneyChangeViewItem>(model);
            await _service.AddMoneyAsync(id, viewItem);

            return Ok();
        }

        [Route("{id}/withdraw")]
        [HttpPost]
        public async Task<IActionResult> withdrawMoneyFromAccount(int id, MoneyChangeViewModel model)
        {
            var viewItem = _mapper.Map<MoneyChangeViewItem>(model);
            await _service.WithdrawMoneyAsync(id, viewItem);

            return Ok();
        }
    }
}