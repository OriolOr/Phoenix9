using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Source.Contracts
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