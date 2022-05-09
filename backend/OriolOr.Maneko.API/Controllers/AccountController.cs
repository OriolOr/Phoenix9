using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.Source.Services;

namespace OriolOr.Maneko.Source.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        public AccountController()
        {
        }

        [HttpGet("GetCurrentBalance")]
        public float GetCurrentBalance()
        {
            var service = new AccountService();
            return service.GetCurrentBalance();

        }

        [HttpGet("GetYearData")]
        public void GetYearData()
        {
            //var service = new AccountService();
            //return service.GetCurrentBalance();
            //return 0.0f;
        }
    }
}