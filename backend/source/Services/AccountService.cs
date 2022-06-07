using OriolOr.Maneko.Infrastructure;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Services
{
    public class AccountService
    {
        public AccountDataRepository AccountDataRepository;
        
        public AccountService() {
            this.AccountDataRepository = new AccountDataRepository(); 
        }

        public double GetCurrentBalanceFromDb(UserCredentials userCredentials)
        {
            return AccountDataRepository.GetAccountCurrentBalance(MongoDbConfigurator.DataBase);
        }

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials)
        {
            return AccountDataRepository.GetYearBalance(MongoDbConfigurator.DataBase);
        }
   }
}
