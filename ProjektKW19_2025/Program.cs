using System;
using System.Collections.Generic;
using System.Numerics;


namespace ProjektKW19_2025
{
    class Program
    {
		static void Main(string[] args)
		{
			Console.WriteLine("Willkommen zum Schlechtesten Programmierer der Welt!");
			Console.WriteLine("Drücke eine beliebige Taste, um deinen Kaffee zu trinken...");
			Console.ReadKey();

			Console.Clear();
			Console.WriteLine("Du trinkst deinen Kaffee... und plötzlich flackert der Bildschirm!");
			Console.WriteLine("Ein grelles Licht blendet dich – du wirst in deine Konsole gezogen!");

			Player player = new Player("Protagonist");
			Story.Intro(player);

		}
	}
}
