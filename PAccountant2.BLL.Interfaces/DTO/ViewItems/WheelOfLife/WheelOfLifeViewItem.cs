using System;
using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife
{
    public class WheelOfLifeViewItem
    {
        public int TotalScore { get; set; }

        public DateTime WheelDate { get; set; }
        
        public IEnumerable<WheelOfLifeElementViewItem> Elements { get; set; }
    }
}
