using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.Services;

namespace OriolOr.Maneko.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManekoController : ControllerBase
    {

        public ManekoController()
        {
        }

        [HttpGet(Name = "GetBalance")]
        public float Get()
        {
            var stats = new StatsKernel();
            var balance = stats.GetLastBalance();
            return balance;
        }
    }
}