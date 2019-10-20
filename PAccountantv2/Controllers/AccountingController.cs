using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Account;
using System.Threading.Tasks;
using PAccountant2.Host.Domain.ViewModels.Account;

namespace PAccountantv2.Host.Api.Controllers
{
    [Route("api/accounting")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingService _accountingService;

        private readonly IMapper _mapper;

        public AccountingController(IAccountingService accountingService, IMapper mapper)
        {
            _accountingService = accountingService;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountingWithAccounts(int id)
        {
            var accountingModel = await _accountingService.GetAccountingWithAccountsAsync(id);

            var mappedData = _mapper.Map<AccountingWithAccountsViewModel>(accountingModel);

            return Ok(mappedData);
        }
    }
}