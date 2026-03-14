using System.ComponentModel.DataAnnotations;

namespace BowlingApi.Data;

public class Team
{
    [Key]
    public int TeamID { get; set; }
    public string TeamName { get; set; } = string.Empty;
}
