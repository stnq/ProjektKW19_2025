
using System;
using WorldsWorstGamedev;

public static class FinaleManager
{
    public static void StarteFinalkampf()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nFINALE: Antares – Der finale Exec erscheint!");
        Console.ResetColor();

        BossEnemy antares = new BossEnemy(
            "Antares – Der finale Exec",
            150,
            20,
            "FinalBuildCrash()",
            "",
            false
        );

        bool sieg = CombatSystem.Fight(GameManager.Player, antares);

        if (sieg)
        {
            MiniGameManager.EscapeDBahnLoop(GameManager.Status);
            SpielBeenden();
        }
        else
        {
            Console.WriteLine("Du wurdest vom finalen Exec vernichtet...");
            Console.WriteLine("Aber vielleicht gibt es noch Hoffnung? Versuchs nochmal!");
            Console.ReadKey();
            GameManager.EndGame();
        }
    }

    public static void SpielBeenden()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("GLUECKWUNSCH!");
        Console.ResetColor();

        Console.WriteLine("Du hast alle Bugs bekaempft, das Legacy-System ueberlebt...");
        Console.WriteLine("Und schließlich sogar den gefuerchteten Exec 'Antares' besiegt.");
        Console.WriteLine("Ein letzter Lichtblitz blendet dich.");
        Console.WriteLine("\n[REBOOTING...]");
        Console.WriteLine("\n...");
        Console.WriteLine("\nDu wachst vor deinem Rechner auf. Die Tasse ist leer.");
        Console.WriteLine("Auf dem Monitor steht:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\"Build succeeded. No warnings.\"");
        Console.ResetColor();
        Console.WriteLine("\nWar alles nur ein Traum?");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nABSPANN:");
        Console.WriteLine("- Helmut Hardcode: Du selbst");
        Console.WriteLine("- Gegnerdesign: Deine schlimmsten Debug-Naechte");
        Console.WriteLine("- Codeassistenz: ChatGPT... *äh... deine harte Arbeit natürlich*");
        Console.WriteLine("- Musik: Deine Kaffee-Maschine");
        Console.ResetColor();

        Console.WriteLine("\n[ENTER druecken, um das Spiel zu beenden]");
        Console.ReadKey();
        Environment.Exit(0);
    }
}
