using MongoDB.Driver;
using OriolOr.Maneko.API.Domain.IdentityManagement;
using System.IdentityModel.Tokens.Jwt;

namespace OriolOr.Maneko.API.Infrastructure.Interfaces
{
    public interface IUserDataRepository
    {
        public string CollectionName { get; }
        public void AddUser(UserCredentials userCredentials);
        public bool CheckUsernameExists(string userName);
        public string GetPasswordEncoded(string userName);
        public void LoadUserData(IMongoDatabase database);
        public string GetUserToken(string userName);
        public IEnumerable<string> GetAllTokens();
        public void SetUserToken(string userName, string token);

    }
}
