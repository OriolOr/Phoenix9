using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OriolOr.Maneko.API.Domain.IdentityManagement;
using OriolOr.Maneko.API.Service.Interfaces;


namespace OriolOr.Maneko.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public IAccountService AccountService;
        public IUserCredentialsService UserCredentialsService;

        public AccountController(IAccountService accountService, IUserCredentialsService userCredentialsService)
        {
            this.AccountService = accountService;
            this.UserCredentialsService = userCredentialsService;
        }

 
        [HttpGet("GetCurrentBalance")]
        public IActionResult GetCurrentBalance(string user , string password)
        {

            var userCredentials = new UserCredentials()
            {
                UserName = user,
                Password = password
            };

            if (this.UserCredentialsService.Authenticate(userCredentials)) return Ok(JsonConvert.SerializeObject(this.AccountService.GetCurrentBalanceFromDb(userCredentials)));

            else return StatusCode(StatusCodes.Status401Unauthorized);
        }

        

        [HttpGet("GetYearData")]
        public IActionResult GetYearData(string user, string password)
        {
            var userCredentials = new UserCredentials()
            {
                UserName = user,
                Password = password
            };
            if (this.UserCredentialsService.Authenticate(userCredentials)) return Ok(JsonConvert.SerializeObject(this.AccountService.GetYearBalanceFromDb(userCredentials).FirstOrDefault()));

            else return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}