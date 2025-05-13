
using System;

public static class CombatSystem
{
    public static bool Fight(Player player, BugEnemy enemy)
    {
        Console.WriteLine($"⚔️ Kampf gestartet gegen: {enemy.Name}!");

        while (player.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine($"{player.Name} HP: {player.Health} | {enemy.Name} HP: {enemy.Health}");
            Console.WriteLine("1) Angreifen 2) Inventar öffnen 3) Gegner untersuchen");

            string input = Console.ReadLine();
            if (input == "1") player.Attack(enemy);
            else if (input == "2") player.Inventory.ShowInventory();
            else if (input == "3") Console.WriteLine($"{enemy.Name} sieht fehlerhaft aus... Bugtyp erkannt.");
            else Console.WriteLine("Ungültige Eingabe.");

            if (enemy.IsAlive()) enemy.Attack(player);
        }

        if (player.IsAlive())
        {
            Console.WriteLine($"✅ {enemy.Name} wurde besiegt!");
            return true;
        }

        Console.WriteLine("☠️ Du wurdest besiegt...");
        return false;
    }
}
