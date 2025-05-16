using System;
using System.Threading;

namespace WorldsWorstGamedev
{
	public static class GameManager
	{
		public static Player Player { get; private set; }
		public static GameState State { get; private set; }
		public static GameStatus Status { get; private set; }

		public static void Start()
		{
			TextUtil.ShowIntro();
			InitializeGame();
			ShowFirstChoice();
		}

		public static void InitializeGame()
		{
			if (State == null)
				State = new GameState();

			Player = new Player("Helmut Hardcode");
			Player.Inventory = new Inventory();

			Status = new GameStatus
			{
				Motivation = State.Motivation,
				Caffeine = State.Caffeine,
				SkillPoints = State.Skill
			};

			foreach (var item in State.InventoryItems)
				Player.Inventory.AddItem(item);

			if (!string.IsNullOrEmpty(State.CompanionName))
				Player.Companion = new Companion(State.CompanionName, 4);
		}

		public static void NewGame()
		{
			State = new GameState();
			InitializeGame();
			TextUtil.ShowIntro();
			ShowFirstChoice();
		}

		public static void LoadGame()
		{
			State = SaveSystem.Load();

			Player = new Player("Helmut Hardcode");
			Player.Inventory = new Inventory();

			Status = new GameStatus
			{
				Motivation = State.Motivation,
				Caffeine = State.Caffeine,
				SkillPoints = State.Skill
			};

			foreach (var item in State.InventoryItems)
				Player.Inventory.AddItem(item);

			if (!string.IsNullOrEmpty(State.CompanionName))
				Player.Companion = new Companion(State.CompanionName, 4);

			if (State.ZoneName == "Dev-Schlucht" || State.ZoneName == "TutorialZone")
				ShowFirstChoice();
			else
				ZoneGameplay.PlayZone(Player, Status, State);
		}

		public static void StartTutorial()
		{
			Console.Clear();
			Console.WriteLine("TUTORIAL AKTIVIERT: 'Kaempfe gegen deinen ersten Bug.'\n");
			BugEnemy enemy = new BugEnemy("Line17.NullReferenceException", 12, 3);
			bool victory = CombatSystem.Fight(Player, enemy);

			if (victory)
			{
				Player.Inventory.AddItem("Energy Drink");
				Status.ErhöheSkill("NullReference verstehen");
				State.ZoneName = "Dev-Schlucht";

				SaveSystem.Save(State);

				ZoneGameplay.PlayZone(Player, Status, State);
			}
			else
			{
				Console.WriteLine("Du bist im Tutorial gescheitert. Aber du kannst es nochmal versuchen.");
				ShowFirstChoice();
			}
		}

		public static void SkipTutorial()
		{
			Console.Clear();
			Console.WriteLine("Du rennst ohne Anleitung los. Wahrscheinlich eine schlechte Idee...");
			State.ZoneName = "Dev-Schlucht";
			ZoneGameplay.PlayZone(Player, Status, State);
		}

		public static void EndGame()
		{
			Console.Clear();
			Console.WriteLine("GG WP! Gib deine Bankverbindung ein um die App zu schließen.");
			Console.ReadKey();
			Environment.Exit(0);
		}

		public static void ReturnToMainMenu()
		{
			Console.Clear();
			Console.WriteLine("Hauptmenue:");
			Console.WriteLine("1) Weiterspielen");
			Console.WriteLine("2) Spielstand neu laden");
			Console.WriteLine("3) Spiel beenden");

			Console.Write("Auswahl: ");
			string input = Console.ReadLine();

			switch (input)
			{
				case "1":
					ZoneGameplay.PlayZone(Player, Status, State);
					break;
				case "2":
					LoadGame();
					break;
				case "3":
					Console.WriteLine("Spiel beendet. Auf Wiedersehen!");
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Ungueltige Eingabe. Bitte erneut waehlen.");
					ReturnToMainMenu();
					break;
			}
		}

		public static void ShowFirstChoice()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("1) „Nanu? Wasn hier los?!“ - Um Hilfe rufen");
			Console.WriteLine("2) „Tutorial? Tsk, Brauch ich nicht.“ - Einfach loslaufen");
			Console.ResetColor();

			Console.Write("Deine Wahl: ");
			var input = Console.ReadLine();

			if (input == "1")
				GameManager.StartTutorial();
			else if (input == "2")
				GameManager.SkipTutorial();
			else
			{
				Console.WriteLine("Ungueltige Eingabe! Bitte nur 1) oder 2)");
				ShowFirstChoice(); // Wiederholen
			}
		}

		public static bool StackOverflowQuiz(GameStatus status)
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
				return true;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Falsch! Die richtige Antwort war: 2");
				status.VerliereMotivation(10);
				return false;
			}
		}

		public static bool EscapeDBahnLoop(GameStatus status)
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
				return true;
			}
			else
			{
				Console.WriteLine("Das hat nicht geholfen. -10 Motivation.");
				status.Motivation -= 10;
				return false;
			}
		}
	

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
			Console.WriteLine("\nZUFALLSEVENT: Windows Update!");
			Console.ResetColor();

			Console.WriteLine("Windows installiert ungefragt Updates... 5 Minuten verloren.");
			status.VerliereMotivation(15);
			status.Caffeine -= 10;
		}

		private static void TastaturKaputt(GameStatus status)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\nZUFALLSEVENT: Deine Tastatur spinnt!");
			Console.ResetColor();

			Console.WriteLine("Du drueckst 'A' und es kommt 'Q'... du verlierst Zeit.");
			status.VerliereMotivation(10);
		}
	}
}