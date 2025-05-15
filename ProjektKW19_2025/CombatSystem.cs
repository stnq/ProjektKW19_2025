
using System;
using WorldsWorstGamedev;

public static class CombatSystem
{
    public static bool Fight(Player player, BugEnemy enemy)
    {
        Console.WriteLine($"Kampf gestartet gegen: {enemy.Name}!");

        while (player.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine($"{player.Name} HP: {player.Health} | {enemy.Name} HP: {enemy.Health}");
            Console.WriteLine("1) Angreifen 2) Inventar oeffnen 3) Gegner untersuchen");

            string input = Console.ReadLine();
            if (input == "1") player.Attack(enemy);
            else if (input == "2") player.Inventory.ShowInventory();
            else if (input == "3") Console.WriteLine($"{enemy.Name} sieht fehlerhaft aus... Bugtyp erkannt.");
            else Console.WriteLine("Ungueltige Eingabe. Bitte nur 1) 2) oder 3).");

            if (enemy.IsAlive()) enemy.Attack(player);

			int totalDamage = player.Damage + player.WeaponDamage;

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
					ZoneName = GameManager.Progress.CurrentZone,
					Motivation = GameManager.Status.Motivation,
					Caffeine = GameManager.Status.Caffeine,
					Skill = GameManager.Status.SkillPoints,
					InventoryItems = GameManager.Player.Inventory.GetAllItems(),
					CompanionName = GameManager.Player.Companion?.Name ?? ""
				});
			}

			return true;
		}

		Console.WriteLine("Du wurdest besiegt...");
		return false;
	}
}
