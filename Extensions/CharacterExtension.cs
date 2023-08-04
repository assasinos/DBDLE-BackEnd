using System.Text.Json;
using System.Text.Json.Serialization;
using DBDLE_BackEnd.Models;

namespace DBDLE_BackEnd.Extensions;

public static class CharacterExtension
{


    public static string ConvertToJson(this CharacterModel character)
    {
        return JsonSerializer.Serialize(character, new JsonSerializerOptions()
        {
            Converters =
            {
                new JsonStringEnumConverter()
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }


}