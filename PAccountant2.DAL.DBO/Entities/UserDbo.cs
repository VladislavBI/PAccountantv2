using PAccountant2.DAL.DBO.Entities.Accounting;

namespace PAccountant2.DAL.DBO.Entities
{
    public class UserDbo
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public  AccountingDbo Accounting { get; set; }
    }
}
