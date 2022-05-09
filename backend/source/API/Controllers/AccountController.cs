using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.Source.Services;
using OriolOr.Maneko.Source.Contracts;

namespace OriolOr.Maneko.Source.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public Account account;
        public StatsManager stats;

        public AccountController()
        {
            this.account = new Account();
            this.stats = new StatsManager(this.account);
            DataManager.Initialize(account.YearHistory.First());
        }

        [HttpGet("GetCurrentBalance")]
        public float GetCurrentBalance()
        {
            var stats = new StatsManager(this.account);
            return stats.GetCurrentBalance();
        }

        [HttpGet("GetYearData")]
        public float GetYearData()
        {
            var stats = new StatsManager(this.account);
            return stats.GetCurrentBalance();
        }
    }
}