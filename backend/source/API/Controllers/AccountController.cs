using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.Source.Services;
using OriolOr.Maneko.Source.Contracts;
using Newtonsoft.Json;

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
            DataManager.LoadJsonData(account);
        }

        [HttpGet("GetCurrentBalance")]
        public string GetCurrentBalance()
        {
            return JsonConvert.SerializeObject(this.stats.GetCurrentBalance());
        }

        [HttpGet("GetYearData")]
        public string GetYearData()
        {
            return JsonConvert.SerializeObject(this.account.YearHistory.FirstOrDefault());
        }
    }
}