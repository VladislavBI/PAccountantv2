using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.Host.Domain.ViewModels.Investment;
using System.Threading.Tasks;

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
        [Route("{invType}")]
        public async Task<IActionResult> AddNewInvestment(int acctingId, int invType, AddInvestmentViewModel model)
        {
            var mappedModel = _mapper.Map<AddLoanViewItem>(model);
            int newInvestmentId = await _service.AddNewInvestment(acctingId, invType, mappedModel);

            return Ok(newInvestmentId);
        }
    }
}
