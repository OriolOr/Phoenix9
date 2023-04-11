using OriolOr.Maneko.API.Domain.IdentityManagement;

namespace OriolOr.Maneko.API.Service.Interfaces
{
    public interface IUserCredentialsService
    {
        public bool Authenticate(UserCredentials userCredentials);

        public string GenerateToken(string userName);
    }
}
