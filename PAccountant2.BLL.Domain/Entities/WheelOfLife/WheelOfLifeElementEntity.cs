using System.Collections.Generic;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeElementEntity
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Name { get; set; }

        public IEnumerable<WheelOfLifeProblemEntity> Problems { get; set; }

        public IEnumerable<WheelOfLifeMementoEntity> Mementos { get; set; }

    }
}
