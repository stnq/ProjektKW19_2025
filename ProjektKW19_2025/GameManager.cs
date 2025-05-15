using System;

namespace WorldsWorstGamedev
{
    public static class GameManager
    {
        public static Player Player { get; private set; }
        public static GameState State { get; private set; }
        public static GameStatus Status { get; private set; }
        public static ProgressTracker Progress { get; private set; }

        public static void Start()
        {
            TextUtil.ShowIntro();
            InitializeGame();
            Interface.ShowFirstChoice();
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

            Progress = new ProgressTracker
            {
                CurrentZone = State.ZoneName,
                DefeatedBosses = State.DefeatedBosses ?? new()
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
            Interface.ShowFirstChoice();
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

            Progress = new ProgressTracker
            {
                CurrentZone = State.ZoneName,
                DefeatedBosses = State.DefeatedBosses ?? new()
            };

            foreach (var item in State.InventoryItems)
                Player.Inventory.AddItem(item);

            if (!string.IsNullOrEmpty(State.CompanionName))
                Player.Companion = new Companion(State.CompanionName, 4);

            if (Progress.CurrentZone == "Dev-Schlucht" || Progress.CurrentZone == "TutorialZone")
                Interface.ShowFirstChoice();
            else
                ZoneGameplay.PlayZone(Player, Status, Progress);
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
                Progress.CurrentZone = "Dev-Schlucht";

                SaveSystem.Save(new GameState
                {
                    ZoneName = Progress.CurrentZone,
                    Motivation = Status.Motivation,
                    Caffeine = Status.Caffeine,
                    Skill = Status.SkillPoints,
                    InventoryItems = Player.Inventory.GetAllItems(),
                    CompanionName = Player.Companion?.Name ?? "",
                    DefeatedBosses = Progress.DefeatedBosses
                });

                ZoneGameplay.PlayZone(Player, Status, Progress);
            }
            else
            {
                Console.WriteLine("Du bist im Tutorial gescheitert. Aber du kannst es nochmal versuchen.");
                Interface.ShowFirstChoice();
            }
        }

        public static void SkipTutorial()
        {
            Console.Clear();
            Console.WriteLine("Du rennst ohne Anleitung los. Wahrscheinlich eine schlechte Idee...");
            Progress.CurrentZone = "Dev-Schlucht";
            ZoneGameplay.PlayZone(Player, Status, Progress);
        }

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Du hast 'World’s Worst Gamedev' erfolgreich abgeschlossen!");
            Console.WriteLine("Helmut kehrt zurueck in die echte Welt – mit Skillpunkten, einem Begleiter...");
            Console.WriteLine("...und dem Wissen, dass er vielleicht doch kein voelliger Noob ist.");
            Console.WriteLine("\nVielen Dank fuers Spielen!");
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
                    ZoneGameplay.PlayZone(Player, Status, Progress);
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
    }
}