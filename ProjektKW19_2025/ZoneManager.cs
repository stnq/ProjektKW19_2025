
using System;
using System.Collections.Generic;

public static class ZoneManager
{
    public static List<BugEnemy> GetZoneMobs(string zone)
    {
        return zone switch
        {
            "Anfängerzone" => new List<BugEnemy>
            {
                new BugEnemy("OffByOne-Gnome", 20, 5),
                new BugEnemy("Nullie der Nullinator", 15, 4),
                new BugEnemy("Division durch Kevin", 10, 10),
                new BugEnemy("Magischer Boolean", 18, 6),
                new BugEnemy("Regex-Ritter", 25, 5),
            },
            "MidZone" => new List<BugEnemy>
            {
                new BugEnemy("Console.Chaos()", 35, 8),
                new BugEnemy("ArgumentOutOfRange", 30, 9),
                new BugEnemy("GhostDependency", 28, 7)
            },
            "EndZone" => new List<BugEnemy>
            {
                new BugEnemy("Deadline-Dämon", 50, 12),
                new BugEnemy("MissingSemicolon", 40, 10),
                new BugEnemy("Captain CodeSmell", 45, 11),
            },
            _ => new List<BugEnemy>()
        };
    }

    public static List<BossEnemy> GetZoneBosses(string zone)
    {
        return zone switch
        {
            "Anfängerzone" => new List<BossEnemy>
            {
                new BossEnemy("RNGesus-Shadow", 50, 10, "RandomCrit()", "USB: RNG-Fragment", true),
                new BossEnemy("TryCatch-Troll", 60, 8, "BlockAndExplode()", "USB: TrollShadow", true),
                new BossEnemy("Merge-Konflikt-Mönch", 70, 7, "ResolveForce()", "USB: GitShadow", true),
                new BossEnemy("Dependency-Krake", 65, 9, "LibTentacle()", "", false),
                new BossEnemy("SpaghettiBot 3000", 80, 11, "GotoLoop()", "", false)
            },
            "MidZone" => new List<BossEnemy>
            {
                new BossEnemy("Recursive Rambo", 90, 13, "StackOverflow()", "", false),
                new BossEnemy("Compiler Calamity", 95, 12, "SyntaxRage()", "", false),
                new BossEnemy("ZombieTaskAwaiter", 85, 11, "AsyncHell()", "", false),
                new BossEnemy("ThreadWarlock", 100, 15, "DeadlockDoom()", "", false)
            },
            "EndZone" => new List<BossEnemy>
            {
                new BossEnemy("Der Drucker", 110, 14, "PaperJam()", "", false),
                new BossEnemy("System.Windows.Error", 115, 16, "BlueScreen()", "", false),
                new BossEnemy("Antares – Der Exec", 150, 20, "FinalBuildCrash()", "", false)
            },
            _ => new List<BossEnemy>()
        };
    }

    public static string GetNextZone(string current)
    {
        return current switch
        {
            "Anfängerzone" => "MidZone",
            "MidZone" => "EndZone",
            "EndZone" => "Finale",
            _ => "Finale"
        };
    }
}
