using System;
using System.Collections.Generic;
using System.Linq;

public static class ZoneManager
{
	public static List<BugEnemy> GetZoneMobs(string zone)
	{
		return zone switch
		{
			"Dev-Schlucht" => new List<BugEnemy>
			{
				new BugEnemy("OffByOne-Gnome", 20, 5),
				new BugEnemy("Nullie der Nullinator", 16, 4),
				new BugEnemy("Division durch Kevin", 16, 10),
				new BugEnemy("Regex-Ritter", 25, 5),
			},
			"StackOverflow-Ruinen" => new List<BugEnemy>
			{
				new BugEnemy("Konsolen.Chaos()", 35, 8),
				new BugEnemy("ArgumentOutOfRangeRover", 35, 9),
				new BugEnemy("GhostDependency", 35, 7)
			},
			"Mainframe-Zitadelle" => new List<BugEnemy>
			{
				new BugEnemy("Deadline-Daemon", 40, 15),
				new BugEnemy("FehlendenSemicolon", 50, 10),
				new BugEnemy("Kapitän CodeSmell", 55, 11),
			},
			_ => new List<BugEnemy>()
		};
	}

	public static List<BossEnemy> GetZoneBosses(string zone)
	{
		return zone switch
		{
			"Dev-Schlucht" => new List<BossEnemy>
			{
				new BossEnemy("Fehlermeldungs-Fee", 30, 6, "MessageBoxRain()", "", false),
				new BossEnemy("Der Stackleaker", 35, 5, "MemoryDrain()", "", false),
				new BossEnemy("Namespace-Ninja", 28, 7, "ShadowClone.cs()", "", false)
			},


			"StackOverflow-Ruinen" => new List<BossEnemy>
			{
				new BossEnemy("TryCatch-Troll", 60, 8, "BlockAndExplode()", "USB: TrollShadow", true),
				new BossEnemy("Dependency-Krake", 65, 9, "LibTentacle()", "", false),
				new BossEnemy("Merge-Konflikt-Moench", 70, 7, "ResolveForce()", "USB: GitShadow", true),
				new BossEnemy("SpaghettiBot 3000", 80, 11, "GotoLoop()", "", false),
				new BossEnemy("RNGesus-Shadow", 90, 12, "RandomCrit()", "USB: RNG-Fragment", true)
			},

			"Mainframe-Zitadelle" => new List<BossEnemy>
			{
				new BossEnemy("Recursive Rambo", 100, 13, "StackOverflow()", "", false),
				new BossEnemy("Compiler-Spacko", 105, 14, "SyntaxRage()", "", false),
				new BossEnemy("ZombieTaskCouseng", 150, 12, "AsyncHell()", "", false),
				new BossEnemy("ThreadWarlock", 110, 15, "DeadlockDoom()", "", false),
				new BossEnemy("keineReturnWerte", 115, 16, "BlueScreen()", "", false),
				
			},

			_ => new List<BossEnemy>()
		};
	}

	public static string GetNextZone(string current)
	{
		return current switch
		{
			"Dev-Schlucht" => "StackOverflow-Ruinen",
			"StackOverflow-Ruinen" => "Mainframe-Zitadelle",
			"Mainframe-Zitadelled" => "Finale",
			_ => "Finale"
		};
	}
}
