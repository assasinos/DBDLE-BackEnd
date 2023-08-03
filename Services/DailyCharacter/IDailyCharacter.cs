using DBDLE_BackEnd.Models;

namespace DBDLE_BackEnd.Services.DailyCharacter;

public interface IDailyCharacter
{
    
    //Read from private property
    CharacterModel GetDailyCharacter();
    void UpdateDailyCharacter(CharacterModel character);
    //Read the maximum value for random character selection
    int GetMaxOffset();

}