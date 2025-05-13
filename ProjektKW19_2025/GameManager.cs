
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
            Player = new Player("Helmut Hardcode");
            State = new GameState();
            Status = new GameStatus();
            Progress = new ProgressTracker();
        }

        public static void StartTutorial()
        {
            Console.Clear();
            Console.WriteLine("📘 TUTORIAL AKTIVIERT: 'Kämpfe gegen deinen ersten Bug.'\n");
            BugEnemy enemy = new BugEnemy("BugMob.cs:Line17.NullReferenceException", 12, 3);
            bool victory = CombatSystem.Fight(Player, enemy);

            if (victory)
            {
                Player.Inventory.AddItem("Energy Drink");
                Status.ErhöheSkill("NullReference verstehen");
                Progress.CurrentZone = "Anfängerzone";
                ZoneGameplay.PlayZone(Player, Status, Progress);
            }
            else
            {
                Console.WriteLine("☠️ Du bist im Tutorial gescheitert. Aber du kannst es nochmal versuchen.");
                Interface.ShowFirstChoice();
            }
        }

        public static void SkipTutorial()
        {
            Console.Clear();
            Console.WriteLine("Du rennst ohne Anleitung los. Wahrscheinlich eine schlechte Idee...");
            Progress.CurrentZone = "Anfängerzone";
            ZoneGameplay.PlayZone(Player, Status, Progress);
        }

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine("🏁 Du hast 'World’s Worst Gamedev' erfolgreich abgeschlossen!");
            Console.WriteLine("Helmut kehrt zurück in die echte Welt – mit Skillpunkten, einem Begleiter...");
            Console.WriteLine("...und dem Wissen, dass er vielleicht doch kein völliger Noob ist.");
            Console.WriteLine("\n🎓 Vielen Dank fürs Spielen!");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
