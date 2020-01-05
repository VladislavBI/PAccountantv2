using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife;
using PAccountant2.BLL.Interfaces.WheelOfLife;
using PAccountant2.Host.Domain.ViewModels.WheelOfLife;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime? wheelDate)
        {
            var model = await _service.GetWheelAsync(wheelDate);
            var mappedModel = _mapper.Map<IEnumerable<WheelOfLifeElementViewModel>>(model);

            return Ok(mappedModel);
        }

        [HttpGet]
        [Route("memento")]
        public async Task<IActionResult> GetMementosDates()
        {
            IEnumerable<WheelOfLifeMementoDateViewItem> model = await _service.GetWheelMementosAsync();
            var mappedModel = _mapper.Map<IEnumerable<WheelOfLifeMementoDateViewModel>>(model);

            return Ok(mappedModel);
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

        [HttpPost]
        [Route("memento")]
        public async Task<IActionResult> CreateCurrentWheelMemento()
        {
            DateTime mementoDate = await _service.CreateWheelMementoAsync(DateTime.Now);

            return Ok(mementoDate);
        }
    }
}