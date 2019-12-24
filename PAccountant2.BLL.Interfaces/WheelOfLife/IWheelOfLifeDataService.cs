using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife;

namespace PAccountant2.BLL.Interfaces.WheelOfLife
{
    public interface IWheelOfLifeDataService
    {
        Task<bool> IsElementExists(int elementId);
        
        Task<WheelOfLifeElementDataItem> GetElementAsync(int elementId);
        
        Task<int> AddProblemAsync(WheelOfLifeProblemDataItem problem);
        
        Task ChangeElementScoreAsync(int elementId, int newScore);

        Task FinishProblemAsync(int problemId);

        Task<bool> IsProblemExistsAsync(int modelProblemId);
        
        Task<int> AddPlanAsync(WheelOfLifePlanDataItem mappedModel);

        Task<bool> IsPlanExistsAsync(int id);
        
        Task FinishPlanAsync(int planId);

        Task<IEnumerable<WheelOfLifeElementDataItem>> GetWheelAsync();
    }
}
