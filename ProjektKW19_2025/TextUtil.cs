
using System;
using System.Threading;


namespace WorldsWorstGamedev
{
    public static class TextUtil
    {
        public static void TypeLine(string text, int delay = 25)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static void ShowIntro()
        {
            Console.Clear();
            TypeLine("Es ist Montagmorgen. Die Sonne scheint durch das Fenster, aber du spuerst nichts davon.");
            TypeLine("Du starrst auf deine Kaffeetasse: 'Hello World – Goodbye Freizeit'");
            TypeLine("Doch ploetzlich vibriert der Tisch... Der Monitor flackert...");
            TypeLine(" ERROR 418 – Ich bin ein Teekessel?! ");
            TypeLine("BEVOR DU REAGIEREN KANNST, WIRST DU IN DIE KONSOLE GEZOGEN.");
            TypeLine("...");
            TypeLine("Eine Stimme fluestert: 'Willkommen in der Core.'");
            TypeLine("Du bist verwirrt");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("   ///// ");
			Console.WriteLine("  | o o |");
			Console.WriteLine(" (|  ^  |)");
			Console.WriteLine("  | [_] |");
			Console.WriteLine("   ----- ");
			Console.ResetColor();
			Console.WriteLine();
        }
    }
}
