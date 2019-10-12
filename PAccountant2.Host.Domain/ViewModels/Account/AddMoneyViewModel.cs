using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AddMoneyViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public float Amount { get; set; }
    }
}
