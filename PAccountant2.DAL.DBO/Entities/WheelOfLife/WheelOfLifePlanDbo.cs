using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities.WheelOfLife
{
    public class WheelOfLifePlanDbo
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool isFinished { get; set; }

        public int ProblemId { get; set; }

        public WheelOfLifeProblemDbo Problem { get; set; }
    }
}
