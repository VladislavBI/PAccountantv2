using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountFilterViewModel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Amount bellow cann't be negative")]
        public decimal? AmountBellow { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount above cann't be negative")]
        public decimal? AmountAbove { get; set; }
    }
}
