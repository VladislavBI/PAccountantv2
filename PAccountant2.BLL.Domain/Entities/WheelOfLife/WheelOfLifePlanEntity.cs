using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Domain.Entities.WheelOfLife
{
    public class WheelOfLifePlanEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool isFinished { get; set; }

        public WheelOfLifeProblemEntity Problem { get; set; }
    }
}
