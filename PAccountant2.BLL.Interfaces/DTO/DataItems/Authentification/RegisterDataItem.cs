using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification
{
    public class RegisterDataItem
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

    }
}
