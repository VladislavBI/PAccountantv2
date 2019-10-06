using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAccountantv2.Host.Api.Infrastructure.Helper
{
    public interface ITokenService
    {
        string CreateToken(string userEmail, string tokenKey);
    }
}
