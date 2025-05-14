
using System;

namespace WorldsWorstGamedev
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.Title = "World’s Worst Gamedev: Das Debug-Abenteuer";
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			Console.WriteLine("🎮 Willkommen zu World’s Worst Gamedev!");
			Console.WriteLine("1) Neues Spiel starten");
			Console.WriteLine("2) Spielstand laden");
			Console.Write("Auswahl: ");
			string auswahl = Console.ReadLine();

			if (auswahl == "1")
			{
				GameManager.NewGame();
			}
			else if (auswahl == "2")
			{
				GameManager.LoadGame();
			}
			else
			{
				Console.WriteLine("Ungueltige Eingabe.");
			}
		}
    }
}
