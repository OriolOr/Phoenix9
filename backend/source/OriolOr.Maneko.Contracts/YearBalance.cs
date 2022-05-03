using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Contracts
{
    public class YearBalance
    {
        public YearBalance()
        {
            this.MonthBalances = new Collection<MonthBalance>();
        }
       public Collection<MonthBalance> MonthBalances;
    }
}