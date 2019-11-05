using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Investment;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.Host.Domain.ViewModels.Investment;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/accounting/{acctingId}/investment")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvestmentService _service;

        public InvestmentController(IInvestmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("loan/to")]
        public async Task<IActionResult> AddLoanTo(int acctingId, AddLoanViewModel model)
        {
            var mappedModel = _mapper.Map<AddLoanViewItem>(model);
            var newLoanId = await _service.AddLoanToAsync(acctingId, mappedModel);

            return Ok(newLoanId);
        }

    }
}
