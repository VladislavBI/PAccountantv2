using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifeProblemEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

        public bool IsFinished { get; set; }

        public WheelOfLifeElementEntity Element { get; set; }

        public IEnumerable<WheelOfLifePlanEntity> Plans { get; set; }
    }
}
