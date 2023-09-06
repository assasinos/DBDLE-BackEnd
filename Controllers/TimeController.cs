using DBDLE_BackEnd.Services.DailyCharacter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DBDLE_BackEnd.Controllers;


[Controller]
[EnableRateLimiting("sliding")]
[Route("api/[controller]/[action]")]
public class TimeController : Controller
{
    
    private IDailyCharacter _dailyCharacter;

    public TimeController(IDailyCharacter dailyCharacter)
    {
        _dailyCharacter = dailyCharacter;
    }
    
    [HttpGet]
    public IActionResult GetLastCharacterUpdate()
    {
        return new JsonResult(_dailyCharacter.GetLastUpdateDateTime());
    }
}