 
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Source.Contracts
{
    public class Account
    {
        public Account()
        {
            this.YearHistory = new Collection<YearBalance>();
        }

        public Collection<YearBalance> YearHistory;
        public float CurrentBalance; 
    }
}
