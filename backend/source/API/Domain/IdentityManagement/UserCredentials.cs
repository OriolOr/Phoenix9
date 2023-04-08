using MongoDB.Bson.Serialization.Attributes;

namespace OriolOr.Maneko.API.Domain.IdentityManagement
{
    [BsonIgnoreExtraElements]
    public class UserCredentials
    {
        public string UserName;
        public string? Password;
        public string? AccountId;
    }
}
