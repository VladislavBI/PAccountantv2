using System;
using System.Collections.Generic;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeMementoEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<WheelOfLifeElementEntity> ElementMementos { get; set; }
    }
}
