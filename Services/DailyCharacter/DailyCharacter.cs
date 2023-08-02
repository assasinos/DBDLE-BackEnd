using DBDLE_BackEnd.Models;

namespace DBDLE_BackEnd.Services.DailyCharacter;

public class DailyCharacter : IDailyCharacter
{
    
    private CharacterModel? _dailyCharacter;
    private readonly DailyCharacterConfigruation _configruation;

    public DailyCharacter(DailyCharacterConfigruation configruation)
    {
        _configruation = configruation;
    }


    public CharacterModel? GetDailyCharacter() => _dailyCharacter;

    public void UpdateDailyCharacter(CharacterModel? character)
    {
        _dailyCharacter = character;
    }

    public int GetMaxOffset() => _configruation.MaxOffset;
}