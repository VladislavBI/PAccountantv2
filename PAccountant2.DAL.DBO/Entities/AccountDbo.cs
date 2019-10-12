using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.DAL.DBO.Entities
{
    public class AccountDbo
    {
        public int Id { get; set; }

        public float Amount { get; set; }

        public UserDbo User { get; set; }

        public string UserId { get; set; }
    }
}
