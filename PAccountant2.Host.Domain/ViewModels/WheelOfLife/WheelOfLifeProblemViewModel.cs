using System;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife;
using System.Collections.Generic;

namespace PAccountant2.Host.Domain.ViewModels.WheelOfLife
{
    public class WheelOfLifeProblemViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ElementId { get; set; }

        public bool IsFinished { get; set; }

        public string ExpectedResult { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<WheelOfLifePlanViewModel> Plans { get; set; }
    }
}
