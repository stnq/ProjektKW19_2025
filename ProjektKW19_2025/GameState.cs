using System.Collections.Generic;

public class GameState
{
    public string ZoneName { get; set; } = "Dev-Schlucht";
    public int Motivation { get; set; }
    public int Caffeine { get; set; }
    public int Skill { get; set; }
    public List<string> InventoryItems { get; set; } = new();
    public string CompanionName { get; set; } = "";
    public List<string> DefeatedBosses { get; set; } = new();
}