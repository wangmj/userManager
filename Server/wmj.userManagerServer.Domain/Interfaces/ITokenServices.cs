using System.Collections.Generic;
using System.Security.Claims;

namespace wmj.userManagerServer.Domain.Interfaces
{
    public interface ITokenServices
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
