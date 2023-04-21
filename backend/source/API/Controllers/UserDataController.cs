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

        [HttpPost("LoginCredentials")]
        public IActionResult GetLoginCredentials(string userName, string password) {

            var userCredentials = new UserCredentials()
            {
                UserName = userName,
                Password = password
            };

            if (UserCredentialsService.Authenticate(userCredentials))
            {
                var token = UserCredentialsService.AddToken(userCredentials.UserName);
                
                return Ok(JsonConvert.SerializeObject(token));
            }

            else return StatusCode(StatusCodes.Status401Unauthorized);

        }

        [HttpPost("SignInUser")]
        public IActionResult SignInUser(string userName, string password) {

            var userCredentials = new UserCredentials()
            {
                UserName = userName,
                Password = password,
                Role = RoleType.User
            };
            if (UserCredentialsService.AddNewUser(userCredentials))
                return Ok();
            else 
                return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}
