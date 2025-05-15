
using System;

namespace WorldsWorstGamedev
{
    public static class Interface
    {
        public static void ShowFirstChoice()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) „Was zur Hoelle ist hier los?!“ - Um Hilfe rufen");
            Console.WriteLine("2) „Tutorial? Brauch ich nicht.“ - Einfach loslaufen");
            Console.ResetColor();

            Console.Write("Deine Wahl: ");
            var input = Console.ReadLine();

            if (input == "1") GameManager.StartTutorial();
            else if (input == "2") GameManager.SkipTutorial();
            else
            {
                Console.WriteLine("Ungueltige Eingabe! Bitte nur 1) oder 2)");
                ShowFirstChoice();
            }
        }
    }
}
