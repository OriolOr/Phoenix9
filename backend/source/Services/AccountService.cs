using OriolOr.Maneko.Infrastructure;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using System.Collections.ObjectModel;
using OriolOr.Maneko.Services.Interfaces;
using OriolOr.Maneko.Infrastructure.Interfaces;

namespace OriolOr.Maneko.Services
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
