using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountant2.Host.Domain.ViewModels.Account;
using PAccountant2.Host.Domain.ViewModels.Authentification;

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

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddMoneyToAccount(AddMoneyViewModel model)
        {
            var viewItem = _mapper.Map<AddMoneyViewItem>(model);
            await _service.AddMoneyAsync(viewItem);

            return Ok();
        }
    }
}