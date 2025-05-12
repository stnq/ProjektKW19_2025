using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKW19_2025
{
    class Tutorial
    {
		public static void Start(Player player)
		{
			Console.WriteLine("Willkommen im Tutorial!");
			Console.WriteLine("Ein Bug-Mob erscheint: Regex-Ritter!");

			int mobHealth = 10;

			while (mobHealth > 0)
			{
				Console.WriteLine("Drücke [A] zum Angreifen!");
				var key = Console.ReadKey(true);

				if (key.Key == ConsoleKey.A)
				{
					int damage = player.Attack();
					mobHealth -= damage;
					Console.WriteLine($"Du greifst an und verursachst {damage} Schaden!");

					if (mobHealth <= 0)
					{
						Console.WriteLine("Regex-Ritter wurde besiegt! Du hast das Tutorial bestanden!");
						player.AddItem(new Item("USB-Stick: Schatten-Archiv", "Ein merkwürdiger Stick..."));
					}
					else
					{
						Console.WriteLine($"Regex-Ritter hat noch {mobHealth} HP!");
					}
				}
			}
		}
	}
}
