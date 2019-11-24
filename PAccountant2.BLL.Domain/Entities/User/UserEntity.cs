using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
using PAccountant2.Common.Encription;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.User
{
    public class UserEntity
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string StringPassword { get; set; }

        public CredentialsValueObject CreateCredentials()
        {
            if (StringPassword == null && Password == null)
            {
                throw new WrongCredentialsException(Email);
            }

            Password = GetEncryptedPassword();

            var credentialsModel = new CredentialsValueObject
            {
                Email = Email,
                Password = Password
            };

            return credentialsModel;
        }

        public AccountingEntity CreateNewAccounting()
        {
            return new AccountingEntity
            {
                User = this
            };
        }

        public byte[] GetEncryptedPassword()
            => Password != null && Password.Any() ? Password : Encryption.Encrypt(StringPassword);
    }
}
