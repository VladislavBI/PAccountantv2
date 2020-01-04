using System;
using System.Collections.Generic;

namespace PAccountant2.Host.Domain.ViewModels.WheelOfLife
{
    class WheelOfLifeViewModel
    {
        public DateTime WheelDate { get; set; }

        public int  TotalScore { get; set; }

        public IEnumerable<WheelOfLifeElementViewModel> Elements { get; set; }
    }
}
