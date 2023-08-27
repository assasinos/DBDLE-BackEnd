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
        while (!stoppingToken.IsCancellationRequested)
        {
            

            //1->n relationship in case I want to serve image from backend or different server
            
            //Documentation says this SQL query might be slow on large tables, but I don't think it will be a problem here
            var cmd = new CommandDefinition($@"SELECT C.CharacterName, C.Gender, C.Origin, C.Height, C.Difficulty, C.ReleaseYear, I.ImagePath FROM `Characters` C join Images I on I.ImageUID = C.ImageUID ORDER BY RAND() LIMIT 1");

            
            
            var character = (await _connection.QueryAsync<CharacterModel,ImageModel, CharacterModel>(cmd,
                (model, imageModel) =>
                {
                    model.Image = imageModel;
                    return model;
                },splitOn:"ImagePath")).FirstOrDefault() ?? throw new Exception($"Could not find character");
            _dailyCharacter.UpdateDailyCharacter(character);

            
            //1 minute for testing purposes, will be changed to 24 hours
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}