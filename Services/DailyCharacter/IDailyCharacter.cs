using DBDLE_BackEnd.Models;

namespace DBDLE_BackEnd.Services.DailyCharacter;

public interface IDailyCharacter
{
    
    //Read from private property
    CharacterModel GetDailyCharacter();
    void UpdateDailyCharacter(CharacterModel character);

    
    void UpdateLastUpdateDateTime(DateTime dateTime);
    DateTime GetLastUpdateDateTime();
}