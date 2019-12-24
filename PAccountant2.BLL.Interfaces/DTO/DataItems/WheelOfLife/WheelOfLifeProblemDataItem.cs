using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife
{
    public class WheelOfLifeProblemDataItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ElementId { get; set; }

        public bool IsFinished { get; set; }

        public IEnumerable<WheelOfLifePlanDataItem> Plans { get; set; }
    }
}
