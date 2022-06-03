using OriolOr.Maneko.Infrastructure;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Source.Services
{
    public class AccountService
    {
        public Account Account;
        

        public AccountService(Account account) {
            this.Account = account;
        }

        public double GetCurrentBalanceFromDb(UserCredentials userCredentials)
        {
           return MongoDbConfigurator.GetAccountCurrentBalance();
        }

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials)
        {
            return MongoDbConfigurator.GetYearBalance();
        }
   }
}
