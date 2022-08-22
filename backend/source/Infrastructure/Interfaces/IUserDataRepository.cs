using MongoDB.Driver;

namespace OriolOr.Maneko.Infrastructure.Interfaces
{
    public interface IUserDataRepository
    {
        public string CollectionName { get; }
        public bool CheckUsernameExists(string userName);
        public string GetPasswordEncoded(string userName);
        public void LoadUserData(IMongoDatabase database);

    }
}
