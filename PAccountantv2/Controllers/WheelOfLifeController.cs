using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife;
using PAccountant2.BLL.Interfaces.WheelOfLife;
using PAccountant2.Host.Domain.ViewModels.Investment;
using PAccountant2.Host.Domain.ViewModels.WheelOfLife;

namespace PAccountantv2.Host.Api.Controllers
{
    [Route("api/wheel")]
    [ApiController]
    public class WheelOfLifeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWheelOfLifeService _service;

        public WheelOfLifeController(IWheelOfLifeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("element/{id}/problem")]
        public async Task<IActionResult> AddNewProblem(int id, WheelOfLifeProblemAddViewModel model)
        {
            var mappedModel = _mapper.Map<WheelOfLifeProblemViewItem>(model);
            mappedModel.ElementId = id;
            int newProblemId = await _service.AddNewProblemAsync(mappedModel);

            return Ok(newProblemId);
        }

        [HttpPut]
        [Route("element/{id}/problem/{problemId}/finish")]
        public async Task<IActionResult> FinishProblem(int id, int problemId)
        {
            await _service.FinishProblemAsync(id, problemId);

            return Ok();
        }

        [HttpPost]
        [Route("problem/{problemId}/plan")]
        public async Task<IActionResult> AddNewPlan(int problemId, WheelOfLifePlanAddViewModel model)
        {
            var mappedModel = _mapper.Map<WheelOfLifePlanViewItem>(model);
            mappedModel.ProblemId = problemId;
            int newPlanId = await _service.AddNewPlanAsync(mappedModel);

            return Ok(newPlanId);
        }

        [HttpPut]
        [Route("problem/{problemId}/plan/{planId}/finish")]
        public async Task<IActionResult> FinishPlan(int problemId, int planId)
        {
            await _service.FinishPlanAsync(problemId, planId);

            return Ok();
        }
    }
}