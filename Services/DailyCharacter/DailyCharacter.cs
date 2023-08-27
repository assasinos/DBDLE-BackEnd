using DBDLE_BackEnd.Models;
using Microsoft.Extensions.Options;

namespace DBDLE_BackEnd.Services.DailyCharacter;

public class DailyCharacter : IDailyCharacter
{
    //Shouldn't be null
    private CharacterModel _dailyCharacter = null!;


    public CharacterModel GetDailyCharacter() => _dailyCharacter;

    public void UpdateDailyCharacter(CharacterModel character)
    {
        _dailyCharacter = character;
    }
    
}