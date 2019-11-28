using System.ComponentModel.DataAnnotations;
using PAccountant2.Common.Constants;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountUpdateViewModel
    {
        [MaxLength(StringLengthConsts.NameLength)]
        public string Name { get; set; }
    }
}
