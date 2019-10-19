﻿using PAccountant2.Common.Encription;
using System.Linq;
using PAccountant2.BLL.Domain.Entities.Accounting;

namespace PAccountant2.BLL.Domain.Entities.User
{
    public class UserEntity
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string StringPassword { get; set; }

        public CredentialsValueObject CreateCredentials()
        {
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
