using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                UserName = "sp",
                Password = "password"
            };

            if (UserCredentialsService.Authenticate(userCredentials))
            {
                var token = UserCredentialsService.GenerateToken();
                return Ok(JsonConvert.SerializeObject(token));
            }

            else return StatusCode(StatusCodes.Status401Unauthorized);

        }
    }
}
