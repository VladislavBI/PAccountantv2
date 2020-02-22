using System;
using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.WheelOfLife
{
    public class WheelOfLifeProblemAddViewModel
    {
        [Required]
        [MaxLength(1024, ErrorMessage = "Exceed max description length")]
        public string Description { get; set; }

        [Required]
        [MaxLength(1024, ErrorMessage = "Exceed max result length")]
        public string ExpectedResult { get; set; }

        public DateTime EndDate { get; set; }
    }
}
