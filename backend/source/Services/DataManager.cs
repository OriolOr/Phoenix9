using Newtonsoft.Json;
using OriolOr.Maneko.ExternalCom;
using OriolOr.Maneko.Services.Properties;
using OriolOr.Maneko.Source.Contracts;
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

        public static double GetScrappingData(string user , string pass)
        {

            WebScrapper scrapper = new WebScrapper(user, pass);
            return scrapper.ScrapCurrentBalance();
        }

    }
}