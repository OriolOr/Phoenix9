using System.Collections.ObjectModel;

namespace OriolOr.Maneko.API.Domain
{
    public class YearBalance
    {
        public YearBalance()
        {
            this.MonthBalances = new Collection<MonthBalance>();
        }

        public int Year;
        public Collection<MonthBalance> MonthBalances;
    }
}