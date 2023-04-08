using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OriolOr.Maneko.API.Controllers
{
    public class UserDataController : Controller
    {
        public UserDataController() { }

        [HttpGet("GetLoginCredentials")]
        public IActionResult GetLoginCredentials() {
            
            return Ok(); 
        }
    }
}
