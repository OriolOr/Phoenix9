using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
