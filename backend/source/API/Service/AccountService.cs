using OriolOr.Maneko.API.Infrastructure;
using OriolOr.Maneko.API.Infrastructure.Interfaces;
using OriolOr.Maneko.API.Models;
using OriolOr.Maneko.API.Models.IdentityManagement;
using OriolOr.Maneko.API.Service.Interfaces;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.API.Service
{
    public class AccountService : IAccountService
    {
        public IAccountDataRepository AccountDataRepository;
        
        public AccountService(IAccountDataRepository accountDataRepository) {
            this.AccountDataRepository = accountDataRepository;
        }

        public double GetCurrentBalanceFromDb(UserCredentials userCredentials)
            
            => AccountDataRepository.GetAccountCurrentBalance(MongoDbConfigurator.DataBase);
        

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials)

            => AccountDataRepository.GetYearBalance(MongoDbConfigurator.DataBase);

   }
}
