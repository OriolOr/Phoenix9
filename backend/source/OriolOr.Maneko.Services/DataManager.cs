using OriolOr.Maneko.Source.Contracts;

namespace OriolOr.Maneko.Services
{
    public class DataManager
    {
        public YearBalance Initialize()
        {
            YearBalance yearBalance = new YearBalance();

            MonthBalance JanuaryBalance = new MonthBalance() { Month = "January", InitialBalance = 31885.06f , FinalBalance = 30396.86f};
            MonthBalance FebruaryBalance = new MonthBalance() { Month = "February", InitialBalance = 32271.70f, FinalBalance = 30447.94f };
            MonthBalance MarchBalance = new MonthBalance() { Month = "March", InitialBalance = 32334.44f, FinalBalance = 28642.47f };
            MonthBalance AprilBalance = new MonthBalance() { Month = "April", InitialBalance = 31615.18f, FinalBalance = 29876.61f };

            yearBalance.MonthBalances.Add(JanuaryBalance);
            yearBalance.MonthBalances.Add(FebruaryBalance);
            yearBalance.MonthBalances.Add(MarchBalance);
            yearBalance.MonthBalances.Add(AprilBalance);

            return yearBalance

        }

    }
}