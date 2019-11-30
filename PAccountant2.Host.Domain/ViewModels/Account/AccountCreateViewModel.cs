using System.ComponentModel.DataAnnotations;
using PAccountant2.Common.Constants;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountCreateViewModel
    {
        [Required]
        [MaxLength(StringLengthConsts.NameLength, ErrorMessage = "Account name length exceeded")]
        public string Name { get; set; }

        [Required]
        public int CurrencyId { get; set; }
    }
}
