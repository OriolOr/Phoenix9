using OriolOr.Maneko.Source.Contracts;

namespace OriolOr.Maneko.Source.Services
{
    public class StatsManager
    {
        public Account Account;

        public StatsManager(Account account) {
            this.Account = account;
        }

        public double GetCurrentBalance(string user ,string password)
        {
            return DataManager.GetScrappingData(user, password);
        }
   }
}
