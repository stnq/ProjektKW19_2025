
using System.Collections.Generic;

public class GameState
{
    public string ZoneName { get; set; } = "TutorialZone";
    public List<string> DefeatedEnemies { get; set; } = new List<string>();
    public List<string> DefeatedBosses { get; set; } = new List<string>();
    public int Motivation { get; set; } = 100;
    public int Caffeine { get; set; } = 50;
    public int Skill { get; set; } = 0;
    public List<string> InventoryItems { get; set; } = new List<string>();
    public string? CompanionName { get; set; }
}
