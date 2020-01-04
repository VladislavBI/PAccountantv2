using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife;

namespace PAccountant2.BLL.Interfaces.WheelOfLife
{
    public interface IWheelOfLifeService
    {
        Task<int> AddNewProblemAsync(WheelOfLifeProblemViewItem mappedModel);
        
        Task FinishProblemAsync(int id, int problemId);

        Task<int> AddNewPlanAsync(WheelOfLifePlanViewItem model);

        Task FinishPlanAsync(int id, int planId);
        
        Task<IEnumerable<WheelOfLifeElementViewItem>> GetWheelAsync(DateTime? wheelDate);

        Task<DateTime> CreateWheelMementoAsync(DateTime now);

        Task<IEnumerable<WheelOfLifeMementoDateViewItem>> GetWheelMementosAsync();
    }
}
