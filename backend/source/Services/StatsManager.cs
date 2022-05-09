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
            return 13.3f;
        }
        public float GetLastBalance()
        {

            return 21.3f;
        }

        public float GetMonthlyIncome()
        {
            return 10.0f;
        }

        public float GetMonthlyExpenses()
        {
            return 43.0f;
        }
   }
}
