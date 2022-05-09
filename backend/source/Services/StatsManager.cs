using OriolOr.Maneko.Source.Contracts;

namespace OriolOr.Maneko.Source.Services
{
    public class StatsManager
    {
        public Account Account;

        public StatsManager(Account account) {
            this.Account = account;
        }

        public float GetCurrentBalance()
        {
           return Account.YearHistory.FirstOrDefault().MonthBalances.LastOrDefault().FinalBalance;
        }



   }
}
