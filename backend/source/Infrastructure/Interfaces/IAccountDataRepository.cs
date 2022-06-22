using MongoDB.Driver;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Infrastructure.Interfaces
{
    public interface IAccountDataRepository
    {
        public string CollectionName { get;}
        public void LoadAccountData(IMongoDatabase database, UserCredentials userCredentials);
        public double GetAccountCurrentBalance(IMongoDatabase database);
        public Collection<YearBalance> GetYearBalance(IMongoDatabase database);
    }
}
