using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.Domain.IdentityManagement;
using Newtonsoft.Json;
using OriolOr.Maneko.Services;

namespace OriolOr.Maneko.Source.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountService AccountService;
        public UserCredentialsService UserCredentialsService;

        public AccountController()
        {
            this.AccountService = new AccountService();
            this.UserCredentialsService = new UserCredentialsService();
        }

        [HttpGet("GetCurrentBalance")]
        public IActionResult GetCurrentBalance(string user , string password)
        {

            var userCredentials = new UserCredentials()
            {
                UserName = user,
                Password = password
            };

            if (this.UserCredentialsService.CheckCredentials(userCredentials)) return Ok(JsonConvert.SerializeObject(this.AccountService.GetCurrentBalanceFromDb(userCredentials)));

            else return StatusCode(StatusCodes.Status401Unauthorized);
        }

        [HttpGet("GetYearData")]
        public IActionResult GetYearData(UserCredentials userCredentials)
        {

            if (this.UserCredentialsService.CheckCredentials(userCredentials)) return Ok(JsonConvert.SerializeObject(this.AccountService.GetYearBalanceFromDb(userCredentials).FirstOrDefault()));

            else return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}