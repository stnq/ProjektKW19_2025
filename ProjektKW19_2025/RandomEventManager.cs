
using System;

public static class RandomEventManager
{
    private static Random rnd = new Random();

    public static void PrüfeZufallsEvent(GameStatus status)
    {
        int chance = rnd.Next(0, 100);
        if (chance < 20)
        {
            WindowsUpdate(status);
        }
        else if (chance < 35)
        {
            TastaturKaputt(status);
        }
    }

    private static void WindowsUpdate(GameStatus status)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n🔄 ZUFALLSEVENT: Windows Update!");
        Console.ResetColor();

        Console.WriteLine("Windows installiert ungefragt Updates... 5 Minuten verloren.");
        status.VerliereMotivation(15);
        status.Caffeine -= 10;
    }

    private static void TastaturKaputt(GameStatus status)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n⌨️ ZUFALLSEVENT: Deine Tastatur spinnt!");
        Console.ResetColor();

        Console.WriteLine("Du drückst 'A' und es kommt 'Q'... du verlierst Zeit.");
        status.VerliereMotivation(10);
    }
}
