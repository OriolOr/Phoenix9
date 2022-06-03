using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.Source.Services;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using Newtonsoft.Json;

namespace OriolOr.Maneko.Source.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountService AccountService;

        public AccountController()
        {
            this.AccountService = new AccountService();
        }

        [HttpGet("GetCurrentBalance")]
        public string GetCurrentBalance(UserCredentials userCredentials)
        {

            return JsonConvert.SerializeObject(this.AccountService.GetCurrentBalanceFromDb(userCredentials));
        }

        [HttpGet("GetYearData")]
        public string GetYearData(UserCredentials userCredentials)
        {

            return JsonConvert.SerializeObject(this.AccountService.GetYearBalanceFromDb(userCredentials).FirstOrDefault());
        }
    }
}