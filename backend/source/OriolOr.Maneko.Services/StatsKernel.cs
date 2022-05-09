
namespace OriolOr.Maneko.Source.Services
{
    public class StatsKernel
    {
        public float GetLastBalance()
        {
           var DataManager = new DataManager();
           var data = DataManager.Initialize();

            return 21.3f;
        }

        public float GetMonthlyIncome()
        {
            return 0.0f;
        }

        public float GetMonthlyExpenses()
        {
            return 0.0f;
        }
   }
}
