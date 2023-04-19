

using MongoDB.Bson.Serialization.Attributes;

namespace OriolOr.Maneko.API.Domain.IdentityManagement
{
    [BsonIgnoreExtraElements]
    public class  UserToken
    {
        public string Value;
        public DateTime ExpirationTime;

    } 
}
