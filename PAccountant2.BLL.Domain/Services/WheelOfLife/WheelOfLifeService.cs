using System;
using System.Threading.Tasks;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities.WheelOfLife;
using PAccountant2.BLL.Domain.Enum;
using PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife;
using PAccountant2.BLL.Interfaces.WheelOfLife;

namespace PAccountant2.BLL.Domain.Services.WheelOfLife
{
    public class WheelOfLifeService: IWheelOfLifeService
    {
        private readonly IMapper _mapper;
        private readonly IWheelOfLifeDataService _dataService;

        public WheelOfLifeService(IMapper mapper, IWheelOfLifeDataService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }
        public async Task<int> AddNewProblemAsync(WheelOfLifeProblemViewItem mappedModel)
        {
            if (!await _dataService.IsElementExists(mappedModel.ElementId))
            {
                throw new NullReferenceException("no element were found");
            }

            WheelOfLifeElementDataItem element = await _dataService.GetElementAsync(mappedModel.ElementId);
            var elementEntity = _mapper.Map<WheelOfLifeElementEntity>(element);

            elementEntity.ChangeScore(IncrementalChange.Decrease);

            var mappedProblem = _mapper.Map<WheelOfLifeProblemDataItem>(mappedModel);
            mappedProblem.IsFinished = false;
            int problemId = await _dataService.AddProblemAsync(mappedProblem);

            await _dataService.ChangeElementScoreAsync(elementEntity.Id, elementEntity.Score);

            return problemId;
        }

        public async Task FinishProblemAsync(int elementId, int problemId)
        {
            if (!await _dataService.IsElementExists(elementId))
            {
                throw new NullReferenceException("no element were found");
            }

            if (!await _dataService.IsProblemExistsAsync(problemId))
            {
                throw new NullReferenceException("problem not found");
            }

            var element = await _dataService.GetElementAsync(elementId);
            var elementEntity = _mapper.Map<WheelOfLifeElementEntity>(element);
            
            elementEntity.ChangeScore(IncrementalChange.Increase);
            await _dataService.ChangeElementScoreAsync(elementEntity.Id, elementEntity.Score);

            await _dataService.FinishProblemAsync(problemId);
        }

        public async Task<int> AddNewPlanAsync(WheelOfLifePlanViewItem model)
        {
            if (!await _dataService.IsProblemExistsAsync(model.ProblemId))
            {
                throw new NullReferenceException("problem not found");
            }

            var mappedModel = _mapper.Map<WheelOfLifePlanDataItem>(model);
            int newPlanId = await _dataService.AddPlanAsync(mappedModel);

            return newPlanId;
        }

        public async Task FinishPlanAsync(int problemId, int planId)
        {
            if (!await _dataService.IsProblemExistsAsync(problemId))
            {
                throw new NullReferenceException("problem not found");
            }

            if (!await _dataService.IsPlanExistsAsync(planId))
            {
                throw new NullReferenceException("plan not found");
            }

            await _dataService.FinishPlanAsync(planId);
        }
    }
}
