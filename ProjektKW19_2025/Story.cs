using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKW19_2025
{
	class Story
	{
		public static void Intro(Player player)
		{
			Console.Clear();
			Console.WriteLine("Du wachst in einer pixeligen Welt auf. Willkommen in der Code-Zone!");
			Console.WriteLine("Eine Stimme sagt: 'Möchtest du ein Tutorial spielen?'");
			Console.WriteLine("1: Ja, bitte. Ich habe keine Ahnung.");
			Console.WriteLine("2: Nein danke, ich bin ein Keyboard-Krieger.");

			string input = Console.ReadLine();

			if (input == "1")
			{
				Tutorial.Start(player);
			}
			else
			{
				Console.WriteLine("Viel Glück... du wirst es brauchen.");
				
			}
		}
	}
}
