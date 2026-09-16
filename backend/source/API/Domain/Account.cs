using System.Collections.ObjectModel;

namespace OriolOr.Maneko.API.Domain
{
    public class Account
    {
        public Account()
        {
            this.YearHistory = new Collection<YearBalance>();
        }

        public Collection<YearBalance> YearHistory;
        public double CurrentBalance;
        public string AccountNumberId;
        public DateTime LastUpdate;
    }
}