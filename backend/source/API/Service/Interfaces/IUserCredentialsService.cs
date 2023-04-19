using OriolOr.Maneko.API.Domain.IdentityManagement;
using System.IdentityModel.Tokens.Jwt;

namespace OriolOr.Maneko.API.Service.Interfaces
{
    public interface IUserCredentialsService
    {
        public bool Authenticate(UserCredentials userCredentials);
        public string AddToken(string userName);
        public void AddNewUser(UserCredentials userCredentials);
        public bool ValidateToken(string token);

    }
}
