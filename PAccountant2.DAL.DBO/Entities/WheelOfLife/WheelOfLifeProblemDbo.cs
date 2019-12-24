using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PAccountant2.DAL.DBO.Entities.WheelOfLife
{
    public class WheelOfLifeProblemDbo
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

        public bool IsFinished { get; set; }

        public int ElementId { get; set; }

        public WheelOfLifeElementDbo Element { get; set; }

        public ICollection<WheelOfLifePlanDbo> Plans { get; set; }
        
    }
}
