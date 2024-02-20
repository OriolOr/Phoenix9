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
        public int  GetCurrentBalance()
        {
            return 9017;
        }

        [HttpGet("GetCurrentYearData")]
        public IActionResult GetCurrentYearData()
        {
            var balance = new Collection<MonthBalance>();
            balance.Add(new MonthBalance(){Month = "January", InitialBalance = 200, FinalBalance = 590});
            balance.Add(new MonthBalance() {Month = "February", InitialBalance = 1298, FinalBalance = 2545});
            balance.Add(new MonthBalance() {Month = "March", InitialBalance = 4959, FinalBalance = 3049});


            var yearBalance = new YearBalance()
            {
                Year = 2023,
                MonthBalances = balance

            };

            return Ok(JsonConvert.SerializeObject(yearBalance));
        }


    }
}