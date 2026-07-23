using OriolOr.Maneko.API.Domain;
using OriolOr.Maneko.API.Service.Interfaces;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.API.Service
{
    public class BalanceService : IBalanceService
    {

        public BalanceService() {

        }
        

        public bool ValidateMonth(string month)
        {
           return Enum.TryParse<MonthEnum>(month, true , out _);
        }
    }
}
