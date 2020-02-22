using System;
using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife
{
    public class WheelOfLifeProblemViewItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ElementId { get; set; }

        public bool IsFinished { get; set; }
        
        public string ExpectedResult { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<WheelOfLifePlanViewItem> Plans { get; set; }
    }
}
