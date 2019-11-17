using System;
using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountOperationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int OperationType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount cann't be negative")]
        public decimal Amount { get; set; }
    }
}
