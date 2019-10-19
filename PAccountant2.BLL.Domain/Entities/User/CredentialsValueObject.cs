using PAccountant2.Common.Encription;

namespace PAccountant2.BLL.Domain.Entities.User
{
    public class CredentialsValueObject
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public bool IsPasswordCorrect(string password)
        {
            var receivedPasswordEncrypted = Encryption.Encrypt(password);

            return Encryption.IsEqual(receivedPasswordEncrypted, Password);
        }
    }
}
