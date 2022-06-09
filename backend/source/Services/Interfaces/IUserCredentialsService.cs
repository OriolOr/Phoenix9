using OriolOr.Maneko.Domain.IdentityManagement;

namespace OriolOr.Maneko.Services.Interfaces
{
    internal interface IUserCredentialsService
    {
        public bool CheckCredentials(UserCredentials userCredentials);
    }
}
