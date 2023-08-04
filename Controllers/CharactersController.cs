using DBDLE_BackEnd.Extensions;
using DBDLE_BackEnd.Services.DailyCharacter;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace DBDLE_BackEnd.Controllers;


[Controller]
[Route("api/[controller]/[action]")]
public class CharactersController : Controller
{
    private readonly MySqlConnection _connection;
    private readonly IDailyCharacter _dailyCharacter;
    
    
    public CharactersController(MySqlConnection connection, IDailyCharacter dailyCharacter)
    {
        _connection = connection;
        _dailyCharacter = dailyCharacter;
    }


    [HttpGet]
    public IActionResult GetDailyCharacter() =>
        //Convert to JSON bcs of the enum and null values
        Ok( _dailyCharacter.GetDailyCharacter().ConvertToJson());
}