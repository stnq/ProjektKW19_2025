
using System;
using WorldsWorstGamedev;

public class GameStatus
{
    public int Motivation { get; set; } = 100;
    public int Caffeine { get; set; } = 50;
    public int SkillPoints { get; set; } = 0;

    public void Anzeigen()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[STATUS]");
        Console.WriteLine($"Motivation: {Motivation}");
        Console.WriteLine($"Koffeinpegel: {Caffeine}");
        Console.WriteLine($"Skillpunkte: {SkillPoints}");
        Console.ResetColor();
		Console.WriteLine($"Waffe: {GameManager.Player.EquippedWeapon} (+{GameManager.Player.WeaponDamage} DMG)");
	}

    public void ErhöheSkill(string thema)
    {
        SkillPoints++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Du hast durch {thema} +1 Skillpunkt erhalten!");
        Console.ResetColor();
    }

    public void VerliereMotivation(int menge)
    {
        Motivation -= menge;
        if (Motivation < 0) Motivation = 0;
        Console.WriteLine($"Motivation gesunken! (-{menge})");
    }
}
