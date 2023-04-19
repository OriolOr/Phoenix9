using OriolOr.Maneko.API.Infrastructure;
using OriolOr.Maneko.API.Infrastructure.Interfaces;
using OriolOr.Maneko.API.Domain;
using OriolOr.Maneko.API.Domain.IdentityManagement;
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

        public double GetCurrentBalanceFromDb()
            
            => AccountDataRepository.GetAccountCurrentBalance(MongoDbConfigurator.DataBase);
        

        public Collection<YearBalance> GetYearBalanceFromDb()

            => AccountDataRepository.GetYearBalance(MongoDbConfigurator.DataBase);

   }
}
