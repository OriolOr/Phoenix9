using OriolOr.Maneko.API.Models.IdentityManagement;

namespace OriolOr.Maneko.API.Service.Interfaces
{
    public interface IUserCredentialsService
    {
        public bool CheckCredentials(UserCredentials userCredentials);
    }
}
