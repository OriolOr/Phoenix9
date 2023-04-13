using OriolOr.Maneko.API.Domain.IdentityManagement;
using System.IdentityModel.Tokens.Jwt;

namespace OriolOr.Maneko.API.Service.Interfaces
{
    public interface IUserCredentialsService
    {
        public bool Authenticate(UserCredentials userCredentials);
        public string AddToken(string UserName);
        private JwtSecurityToken GenerateToken(string userName);

    }
}
