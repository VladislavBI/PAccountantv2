using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PAccountant2.DAL.DBO.Entities
{
    public class UserDbo
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public  AccountingDbo Accounting { get; set; }
    }
}
