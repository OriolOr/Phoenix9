using Microsoft.AspNetCore.Mvc;

namespace OriolOr.Maneko.API.Controllers;

public class HomeMortageController : Controller
{
    [HttpGet("GetCurrentHomeMortage")]
    public IActionResult Index()
    {
        return Ok();
    }




}