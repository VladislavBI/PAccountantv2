using System;
using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountHistoryFiltersViewModel
    {
        [Range(0, int.MaxValue, ErrorMessage = "Amount bellow cann't be negative")]
        public int? AmountBellow { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Amount above cann't be negative")]
        public int? AmountAbove { get; set; }

        public DateTime? DateBefore { get; set; }

        public DateTime? DateAfter { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Operation type is not valid")]
        public int? OperationType { get; set; }
    }
}
