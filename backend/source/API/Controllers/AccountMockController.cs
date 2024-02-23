using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OriolOr.Maneko.API.Domain;



namespace OriolOr.Maneko.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountMockController : ControllerBase
    {

        [HttpGet("GetCurrentBalance")]
        public IActionResult  GetCurrentBalance()
        {
            return Ok(9017);
        }

        [HttpGet("GetCurrentYearData")]
        public IActionResult GetCurrentYearData()
        {
            var balance = new Collection<MonthBalance>();
            balance.Add(new MonthBalance(){Month = "January", InitialBalance = 200, FinalBalance = 90});
            balance.Add(new MonthBalance() {Month = "February", InitialBalance = 1298, FinalBalance = 545});
            balance.Add(new MonthBalance() {Month = "March", InitialBalance = 4959, FinalBalance = 8049});
            balance.Add(new MonthBalance() { Month = "April", InitialBalance = 12034, FinalBalance = 11590 });
            balance.Add(new MonthBalance() { Month = "May", InitialBalance = 12998, FinalBalance = 15455 });
            balance.Add(new MonthBalance() { Month = "June", InitialBalance = 14959, FinalBalance = 13049 });

            var yearBalance = new YearBalance()
            {
                Year = 2023,
                MonthBalances = balance
            };

            return Ok(JsonConvert.SerializeObject(yearBalance));
        }

    }
}