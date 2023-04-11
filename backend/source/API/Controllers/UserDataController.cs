using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.API.Domain.IdentityManagement;
using OriolOr.Maneko.API.Service.Interfaces;

namespace OriolOr.Maneko.API.Controllers
{
    public class UserDataController : Controller
    {
        public IUserCredentialsService UserCredentialsService;

        public UserDataController(IUserCredentialsService userCredentialsService)
        {
            this.UserCredentialsService = userCredentialsService;
        }

        [HttpGet("GetLoginCredentials")]
        public IActionResult GetLoginCredentials() {

            var userCredentials = new UserCredentials()
            {
                UserName = "user",
                Password = "password"
            };

            UserCredentialsService.Authenticate(userCredentials);
            return Ok(); 
        }
    }
}
