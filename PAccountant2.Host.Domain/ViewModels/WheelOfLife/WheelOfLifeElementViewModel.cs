using System;
using System.Collections.Generic;

namespace PAccountant2.Host.Domain.ViewModels.WheelOfLife
{
    public class WheelOfLifeElementViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<WheelOfLifeProblemViewModel> Problems { get; set; }
    }
}
