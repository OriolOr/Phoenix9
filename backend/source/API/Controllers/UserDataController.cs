using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public IActionResult LoginCredentials(UserCredentials userCredentials) {

            if (userCredentials.Password.IsNullOrEmpty() || userCredentials.Password.IsNullOrEmpty())
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (UserCredentialsService.Authenticate(userCredentials))
            {
                var token = UserCredentialsService.AddToken(userCredentials.UserName);
                
                return Ok(JsonConvert.SerializeObject(token));
            }

            return StatusCode(StatusCodes.Status401Unauthorized);

        }

        [HttpPost("SignInUser")]
        public IActionResult SignInUser(UserCredentials userCredentials) {

            if (userCredentials.Password.IsNullOrEmpty() || userCredentials.Password.IsNullOrEmpty())
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            userCredentials.Role = RoleType.User;
      
            if (UserCredentialsService.AddNewUser(userCredentials))
                return Ok();
            
            return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}
