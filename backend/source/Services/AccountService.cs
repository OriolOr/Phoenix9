using OriolOr.Maneko.Infrastructure;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using System.Collections.ObjectModel;
using OriolOr.Maneko.Services.Interfaces;

namespace OriolOr.Maneko.Services
{
    public class AccountService : IAccountService
    {
        public AccountDataRepository AccountDataRepository;
        
        public AccountService() {
            this.AccountDataRepository = new AccountDataRepository(); 
        }

        public double GetCurrentBalanceFromDb(UserCredentials userCredentials)
            
            => AccountDataRepository.GetAccountCurrentBalance(MongoDbConfigurator.DataBase);
        

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials)

            => AccountDataRepository.GetYearBalance(MongoDbConfigurator.DataBase);

   }
}
