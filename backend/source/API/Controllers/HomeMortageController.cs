using Microsoft.AspNetCore.Mvc;
using OriolOr.Maneko.API.Service;

namespace OriolOr.Maneko.API.Controllers;

public class HomeMortageController : Controller
{
    MortageService mortageService = new MortageService();
    
    [HttpGet("GetTotalMortage")]
    public IActionResult GetTotalMortage()
    {
        return Ok(mortageService.GetTotalMortage());
    }
    
    [HttpGet("GetAmortizedMortage")]
    public IActionResult GetAmortizedMortage()
    {
        return Ok(mortageService.GetAmortizedMortage());
    }
}