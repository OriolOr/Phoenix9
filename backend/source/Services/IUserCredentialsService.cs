using OriolOr.Maneko.Domain.IdentityManagement;

namespace OriolOr.Maneko.Services
{
    internal interface IUserCredentialsService
    {
        public bool CheckCredentials(UserCredentials userCredentials);

        public string EncodeMD5HashPassword(string password);
    }
}
