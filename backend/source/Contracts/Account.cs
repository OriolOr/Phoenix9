
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Source.Contracts
{
    public class Account
    {
        public Account()
        {
            this.YearHistory = new Collection<YearBalance>();
        }

        public IEnumerable<YearBalance> YearHistory;
        public float CurrentBalance; 
    }
}
