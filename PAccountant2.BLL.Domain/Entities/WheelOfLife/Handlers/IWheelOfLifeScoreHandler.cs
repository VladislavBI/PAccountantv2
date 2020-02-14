using System.Collections.Generic;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife.Handlers
{
    interface IWheelOfLifeScoreHandler
    {

        IEnumerable<WheelOfLifeMementoDateValueObject> GetAllWheelScores(
            IEnumerable<WheelOfLifeElementEntity> elements,
            IEnumerable<WheelOfLifeMementoEntity> mementos);
    }
}
