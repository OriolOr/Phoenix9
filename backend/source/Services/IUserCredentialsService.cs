using OriolOr.Maneko.Domain.IdentityManagement;

namespace OriolOr.Maneko.Services
{
    internal interface IUserCredentialsService
    {
        public bool CheckCredentials(UserCredentials userCredentials);
    }
}
