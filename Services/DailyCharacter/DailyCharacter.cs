using DBDLE_BackEnd.Models;
using Microsoft.Extensions.Options;

namespace DBDLE_BackEnd.Services.DailyCharacter;

public class DailyCharacter : IDailyCharacter
{
    //Shouldn't be null
    private CharacterModel _dailyCharacter = null!;

    private DateTime _lastUpdateDateTime;

    public CharacterModel GetDailyCharacter() => _dailyCharacter;

    public void UpdateDailyCharacter(CharacterModel character)
    {
        _dailyCharacter = character;
    }

    public void UpdateLastUpdateDateTime(DateTime dateTime)
    {
        _lastUpdateDateTime = dateTime;
    }

    public DateTime GetLastUpdateDateTime() => _lastUpdateDateTime;
}