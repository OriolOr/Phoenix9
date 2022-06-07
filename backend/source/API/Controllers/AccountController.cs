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
        public string GetCurrentBalance(string user , string password)
        {


            var userCredentials = new UserCredentials()
            {
                UserName = user,
                Password = password
            };


            this.UserCredentialsService.CheckCredentials(userCredentials);

            return JsonConvert.SerializeObject(this.AccountService.GetCurrentBalanceFromDb(userCredentials));
        }

        [HttpGet("GetYearData")]
        public string GetYearData(UserCredentials userCredentials)
        {

            this.UserCredentialsService.CheckCredentials(userCredentials);

            return JsonConvert.SerializeObject(this.AccountService.GetYearBalanceFromDb(userCredentials).FirstOrDefault());
        }
    }
}