
using System;

public static class MiniGameManager
{
    public static void StackOverflowQuiz(GameStatus status)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nMINISPIEL: Stack Overflow Quiz");
        Console.ResetColor();

        Console.WriteLine("Frage: Was gibt Console.WriteLine(3 + \"3\") in C# aus?");
        Console.WriteLine("1) 6\n2) 33\n3) Fehler");

        Console.Write("Antwort (1-3): ");
        var input = Console.ReadLine();

        if (input == "2")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Korrekt! '3' ist ein String, daher ergibt es '33'");
            status.ErhöheSkill("StackOverflow Quiz");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Falsch! Die richtige Antwort war: 2");
            status.VerliereMotivation(10);
        }

        Console.ResetColor();
    }

    public static void EscapeDBahnLoop(GameStatus status)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nMINISPIEL: Escape the Infinite dBahn Loop");
        Console.ResetColor();

        Console.WriteLine("Du sitzt im Zug... ploetzlich Ansage: 'Verspaetung wegen Verspaetung.'");
        Console.WriteLine("Waehle deine Aktion:");
        Console.WriteLine("1) Fenster aufreißen\n2) Musik hoeren\n3) Meditieren");

        Console.Write("Aktion (1-3): ");
        var input = Console.ReadLine();

        if (input == "3") 
        {
            Console.WriteLine("Du bleibst ruhig. +10 Motivation.");
            status.Motivation += 10;
        }
        else
        {
            Console.WriteLine("Das hat nicht geholfen. -10 Motivation.");
            status.Motivation -= 10;
        }
    }
}
