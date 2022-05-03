using OriolOr.Maneko.Contracts;

namespace OriolOr.Maneko.Services
{
    public class DataInitializer
    {
        public void Initialize()
        {
            YearBalance yearBalance = new YearBalance();

            MonthBalance JanuaryBalance = new MonthBalance() { Month = "January", InitialBalance = 23.4f , FinalBalance = 12.3f};
            MonthBalance FebruaryBalance = new MonthBalance() { Month = "February", InitialBalance = 33.4f, FinalBalance = 12.3f };
            MonthBalance MarchBalance = new MonthBalance() { Month = "March", InitialBalance = 213.4f, FinalBalance = 349.3f };
            MonthBalance AprilBalance = new MonthBalance() { Month = "April", InitialBalance = 2313.4f, FinalBalance = 875.4f };
            MonthBalance MayBalance = new MonthBalance() { Month = "May", InitialBalance = 223.4f, FinalBalance = 134.3f };

            yearBalance.MonthBalances.Add(JanuaryBalance);
            yearBalance.MonthBalances.Add(FebruaryBalance);
            yearBalance.MonthBalances.Add(MarchBalance);
            yearBalance.MonthBalances.Add(AprilBalance);
            yearBalance.MonthBalances.Add(MayBalance);

        }

    }
}