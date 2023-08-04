using Dapper;
using DBDLE_BackEnd.Extensions;
using DBDLE_BackEnd.Models;
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
        //Convert to JSON bcs of the enum and null values,
        //Then convert to base64 to hide the data
        Ok( _dailyCharacter.GetDailyCharacter().ConvertToBase64Json());

    [HttpGet]
    public async Task<IActionResult> GetAllCharacters()
    {
        //1->n relationship in case I want to serve image from backend or different server
        var cmd = new CommandDefinition($@"SELECT C.CharacterName, C.Gender, C.Origin, C.Height, C.Difficulty, C.ReleaseYear, I.ImagePath FROM `Characters` C join Images I on I.ImageUID = C.ImageUID");


        var character = await _connection.QueryAsync<CharacterModel, ImageModel, CharacterModel>(cmd,
            (model, imageModel) =>
            {
                model.Image = imageModel;
                return model;
            }, splitOn: "ImagePath");
        //Convert to JSON bcs of the enum and null values
        return Ok(character.ConvertToJson());
    }
    
    
}