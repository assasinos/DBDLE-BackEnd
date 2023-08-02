namespace DBDLE_BackEnd.Models;

public class CharacterModel
{
    public string CharacterUid { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string Origin { get; set; } = null!;
    public HeightEnum Height { get; set; }
    public int ReleaseYear { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public ImageModel Image { get; set; }


}