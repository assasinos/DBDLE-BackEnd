using Dapper;
using DBDLE_BackEnd.Models;
using DBDLE_BackEnd.Services.DailyCharacter;
using MySqlConnector;

namespace DBDLE_BackEnd.Services.DailyCharacterUpdate;

public class DailyCharacterUpdateService : BackgroundService
{
    private readonly IDailyCharacter _dailyCharacter;

    private readonly MySqlConnection _connection;
    
    public DailyCharacterUpdateService(IDailyCharacter dailyCharacter, MySqlConnection connection)
    {
        _dailyCharacter = dailyCharacter;
        _connection = connection;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var random = new Random();
        while (!stoppingToken.IsCancellationRequested)
        {

            //Add random selection of character

            var randomOffset = random.Next(0, _dailyCharacter.GetMaxOffset());

            
            //1->n relationship in case I want to serve image from backend or different server
            var cmd = new CommandDefinition($@"SELECT C.CharacterName, C.Gender, C.Origin, C.Height, C.Difficulty, C.ReleaseYear, I.ImagePath FROM `Characters` C join Images I on I.ImageUID = C.ImageUID LIMIT 1 OFFSET {randomOffset}");

            
            
            var character = (await _connection.QueryAsync<CharacterModel,ImageModel, CharacterModel>(cmd,
                (model, imageModel) =>
                {
                    model.Image = imageModel;
                    return model;
                },splitOn:"ReleaseYear")).FirstOrDefault() ?? throw new Exception($"Could not find character with offset {randomOffset}");
            _dailyCharacter.UpdateDailyCharacter(character);

            
            //1 minute for testing purposes, will be changed to 24 hours
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}