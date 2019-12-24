using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife;
using PAccountant2.BLL.Interfaces.WheelOfLife;
using PAccountant2.DAL.Context;
using System.Threading.Tasks;
using PAccountant2.DAL.DBO.Entities.WheelOfLife;
using Remotion.Linq.Clauses;

namespace PAccountant2.DAL.Services.WheelOfLife
{
    public class WheelOfLifeDataService : IWheelOfLifeDataService
    {
        private readonly IMapper _mapper;
        private readonly PaccountantContext _context;

        public WheelOfLifeDataService(PaccountantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> IsElementExists(int elementId) =>
            await _context.WheelOfLifeElements.AnyAsync(el => el.Id == elementId);

        public async Task<WheelOfLifeElementDataItem>  GetElementAsync(int elementId)
        {
            var dbElement = await _context.WheelOfLifeElements.FirstOrDefaultAsync(el => el.Id == elementId);
            var mappedModel = _mapper.Map<WheelOfLifeElementDataItem>(dbElement);

            return mappedModel;
        }

        public async Task<int> AddProblemAsync(WheelOfLifeProblemDataItem problem)
        {
            var dbProblem = _mapper.Map<WheelOfLifeProblemDbo>(problem);

            _context.WheelOfLifeProblems.Add(dbProblem);
            await _context.SaveChangesAsync();

            return dbProblem.Id;
        }

        public async Task ChangeElementScoreAsync(int elementId, int newScore)
        {
            var dbElement = await _context.WheelOfLifeElements.FirstOrDefaultAsync(el => el.Id == elementId);

            dbElement.Score = newScore;

            await _context.SaveChangesAsync();
        }

        public async Task FinishProblemAsync(int problemId)
        {
            var problem = await _context.WheelOfLifeProblems.FirstOrDefaultAsync(pr => pr.Id == problemId);
            problem.IsFinished = true;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsProblemExistsAsync(int id)
            => await _context.WheelOfLifeProblems.AnyAsync(pr => pr.Id == id);

        public async Task<int> AddPlanAsync(WheelOfLifePlanDataItem model)
        {
            var dbPlan = _mapper.Map<WheelOfLifePlanDbo>(model);
            _context.WheelOfLifePlans.Add(dbPlan);

            await _context.SaveChangesAsync();

            return dbPlan.Id;
        }

        public async Task<bool> IsPlanExistsAsync(int id)
            => await _context.WheelOfLifePlans.AnyAsync(pl => pl.Id == id);

        public async Task FinishPlanAsync(int planId)
        {
            var dbPlan = await _context.WheelOfLifePlans.FirstOrDefaultAsync(pl => pl.Id == planId);

            dbPlan.isFinished = true;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WheelOfLifeElementDataItem>> GetWheelAsync()
        {
            var elements = await _context.WheelOfLifeElements
                .Include(el => el.Problems)
                .ThenInclude(pr => pr.Plans)
                .ToListAsync();

            var mappedElements = _mapper.Map<IEnumerable<WheelOfLifeElementDataItem>>(elements);

            return mappedElements;
        }
    }
}
