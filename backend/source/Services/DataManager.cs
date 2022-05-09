using OriolOr.Maneko.Source.Contracts;
using Newtonsoft.Json;
using OriolOr.Maneko.Services.Properties;

namespace OriolOr.Maneko.Source.Services
{
    public static class DataManager
    {
        public static YearBalance Initialize(YearBalance yearBalance)
        {

           
            var data = JsonConvert.DeserializeObject<YearBalance>(Resources.BankData.ToString());


            MonthBalance JanuaryBalance = new MonthBalance() { Month = "January", InitialBalance = 31885.06f , FinalBalance = 30396.86f};
            MonthBalance FebruaryBalance = new MonthBalance() { Month = "February", InitialBalance = 32271.70f, FinalBalance = 30447.94f };
            MonthBalance MarchBalance = new MonthBalance() { Month = "March", InitialBalance = 32334.44f, FinalBalance = 28642.47f };
            MonthBalance AprilBalance = new MonthBalance() { Month = "April", InitialBalance = 31615.18f, FinalBalance = 29876.61f };

            yearBalance.MonthBalances.Add(JanuaryBalance);
            yearBalance.MonthBalances.Add(FebruaryBalance);
            yearBalance.MonthBalances.Add(MarchBalance);
            yearBalance.MonthBalances.Add(AprilBalance);

            return yearBalance; 

        }

    }
}