using DBDLE_BackEnd.Models;
using Microsoft.Extensions.Options;

namespace DBDLE_BackEnd.Services.DailyCharacter;

public class DailyCharacter : IDailyCharacter
{
    //Shouldn't be null
    private CharacterModel _dailyCharacter = null!;
    private readonly DailyCharacterConfiguration _configuration;

    public DailyCharacter(IOptions<DailyCharacterConfiguration> configuration)
    {
        _configuration = configuration.Value;
    }


    public CharacterModel GetDailyCharacter() => _dailyCharacter;

    public void UpdateDailyCharacter(CharacterModel character)
    {
        _dailyCharacter = character;
    }

    public int GetMaxOffset() => _configuration.MaxOffset;
}