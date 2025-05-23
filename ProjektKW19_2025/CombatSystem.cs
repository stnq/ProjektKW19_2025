
using System;
using ProjektKW19_2025;
using WorldsWorstGamedev;

public static class CombatSystem
{
	public static bool Fight(Player player, Enemy enemy)
	{
		Console.WriteLine($"Kampf gestartet gegen: {enemy.Name}!");

		while (player.IsAlive() && enemy.IsAlive())
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write($"{player.Name} HP: {player.Health}  ");
			Console.ResetColor();
			Console.Write("| ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{enemy.Name} HP: {enemy.Health}");
			Console.ResetColor();
			Console.WriteLine("1) Angreifen 2) Inventar oeffnen 3) Gegner untersuchen");

			string input = Console.ReadLine();
			Console.Clear();
			if (input == "1") player.Attack(enemy);
			else if (input == "2") player.Inventory.ShowInventory();
			else if (input == "3") Console.WriteLine($"{enemy.Name} sieht fehlerhaft aus... Bugtyp erkannt.");
			else Console.WriteLine("Ungueltige Eingabe. Bitte nur 1), 2) oder 3).");

			if (enemy.IsAlive()) enemy.Attack(player);



		}

		if (player.IsAlive())
		{
			Console.WriteLine($"{enemy.Name} wurde besiegt!");
			Console.WriteLine("\nMoechtest du deinen Fortschritt jetzt speichern?");
			Console.WriteLine("1) Ja");
			Console.WriteLine("2) Nein");

			string input = Console.ReadLine();
			if (input == "1")
			{
				SaveSystem.Save(new GameState
				{
					ZoneName = GameManager.State.ZoneName,
					Motivation = GameManager.Status.Motivation,
					Caffeine = GameManager.Status.Caffeine,
					Skill = GameManager.Status.SkillPoints,
					InventoryItems = GameManager.Player.Inventory.GetAllItems(),
					CompanionName = GameManager.Player.Companion?.Name ?? ""
				}, GameManager.ActiveSlot);

				return true;
			}

			return true; 
		}

		Console.WriteLine("Du wurdest besiegt...");
		return false;
	}
}


