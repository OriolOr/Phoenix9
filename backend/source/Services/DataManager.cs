using OriolOr.Maneko.Source.Contracts;
using Newtonsoft.Json;
using OriolOr.Maneko.Services.Properties;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Source.Services
{
    public static class DataManager
    {
        public static void LoadJsonData(Account account)
        {

            var newYearBalance = new YearBalance();

            newYearBalance.Year = 2022;
            newYearBalance.MonthBalances = JsonConvert.DeserializeObject<Collection<MonthBalance>>(Resources.BankData);
            
            account.YearHistory.Add(newYearBalance); 

        }

    }
}