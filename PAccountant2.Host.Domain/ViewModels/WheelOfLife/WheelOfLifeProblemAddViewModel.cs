using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.WheelOfLife
{
    public class WheelOfLifeProblemAddViewModel
    {
        [Required]
        [MaxLength(1024, ErrorMessage = "Exceed max length")]
        public string Description { get; set; }
    }
}
