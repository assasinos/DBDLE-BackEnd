using DBDLE_BackEnd.Services.DailyCharacter;

namespace DBDLE_BackEnd.Services.DailyCharacterUpdate;

public class DailyCharacterUpdateService : BackgroundService
{
    private readonly IDailyCharacter _dailyCharacter;

    public DailyCharacterUpdateService(IDailyCharacter dailyCharacter)
    {
        _dailyCharacter = dailyCharacter;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var random = new Random();
        while (!stoppingToken.IsCancellationRequested)
        {

            //Add random selection of character

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}