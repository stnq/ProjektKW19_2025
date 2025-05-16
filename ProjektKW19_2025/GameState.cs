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
	public Dictionary<string, bool> QuizDone { get; set; } = new()
	{
		{ "StackQuiz", false },
		{ "DBahnQuiz", false },
		{ "NameQuiz", false }
	};

	public void RegisterKill(string zone, bool isBoss, string name)
	{
		if (isBoss && !DefeatedBosses.Contains(name))
			DefeatedBosses.Add(name);
	}

	public bool ZoneBossGoalReached(string zone)
	{
		int defeatedCount = DefeatedBosses
			.FindAll(name => ZoneManager.GetZoneBosses(zone).Exists(b => b.Name == name)).Count;

		return zone switch
		{
			"StackOverflow-Ruinen" => defeatedCount >= 3,
			"Mainframe-Zitadelle" => defeatedCount >= 2,
			_ => defeatedCount >= 3
		};
	}
}
