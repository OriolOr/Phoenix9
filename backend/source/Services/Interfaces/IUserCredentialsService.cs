using OriolOr.Maneko.Domain.IdentityManagement;

namespace OriolOr.Maneko.Services.Interfaces
{
    public interface IUserCredentialsService
    {
        public bool CheckCredentials(UserCredentials userCredentials);
    }
}
