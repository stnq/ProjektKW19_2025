using System;
using WorldsWorstGamedev;

public static class ZoneGameplay
{
    public static void PlayZone(Player player, GameStatus status, ProgressTracker progress)
    {
        string zone = progress.CurrentZone;
		Console.Clear();
		ShowZoneLore(zone);
		Console.WriteLine("\n[ENTER] um fortzufahren...");
		Console.ReadLine();
		Console.Clear();
		var mobs = ZoneManager.GetZoneMobs(zone);
        var bosses = ZoneManager.GetZoneBosses(zone);

        while (true)
        {
            Console.WriteLine($"Zone: {zone}");
			Console.WriteLine("1) Weiter nach Links");
			Console.WriteLine("2) Weiter nach Rechts");
			Console.WriteLine("3) Status anzeigen");
			Console.WriteLine("4) Inventar anzeigen"); 
			Console.WriteLine("5) Ab ins nächste Gebiet");
			Console.WriteLine("6) Zum Menue zurueck");
			Console.Write("Aktion: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var mob = mobs[new Random().Next(mobs.Count)];
					if (CombatSystem.Fight(player, mob))
					{
						if (new Random().NextDouble() < 0.5)
						{
							player.Inventory.AddItem("Energy Drink");
							Console.WriteLine("Du findest einen Energy Drink beim toten Bug!");
						}

						progress.RegisterKill(zone, false, mob.Name);

						int chance = new Random().Next(0, 100);

						if (chance < 20)
						{
							Console.WriteLine("\nFLASHBACK!");
							Console.WriteLine("Dein Dozent ruft: 'Wer hat wieder `== true` in die if-Abfrage geschrieben?!'");
						}
						else if (chance < 40)
						{
							Console.WriteLine("\nDu findest einen Glueckskeks mit der Aufschrift:");
							Console.WriteLine("\"Semikolon vergessen? Willkommen im Club.\"");
						}
						else if (chance < 60)
						{
							Console.WriteLine("\nDeine Tastatur spinnt – Eingaben erscheinen rueckwaerts!");
						}
						else if (chance < 80)
						{
							Console.WriteLine("\nEine alte Büroklammer erscheint und fragt:");
							Console.WriteLine("\"Sie versuchen, ein Spiel zu entwickeln. Möchten Sie Hilfe?\"");
						}
						else
						{
							Console.WriteLine("\nDu findest eine .zip-Datei.");
							Console.WriteLine("Sie entpackt sich selbst...");
							Console.WriteLine("...und öffnet einen Ordner namens `AlteHausaufgaben_LetzteWoche_FINAL_v3_EndlichFinal.zip`.");
						}
					}
					break;

                case "2":
                    Console.WriteLine("Aktive Bosse in dieser Zone:");
                    foreach (var b in bosses)
                    {
                        Console.WriteLine($"- {b.Name} | Besiegt: {progress.DefeatedBosses.Contains(b.Name)}");
                    }

                    var unbesiegt = bosses.FindAll(b => !progress.DefeatedBosses.Contains(b.Name));
                    if (unbesiegt.Count == 0)
                    {
                        Console.WriteLine("Alle Bosse in dieser Zone wurden bereits besiegt.");
                        break;
                    }

                    var boss = unbesiegt[new Random().Next(unbesiegt.Count)];
                    if (CombatSystem.Fight(player, boss))
                    {
                        progress.RegisterKill(zone, true, boss.Name);

						if (boss.Name.Contains("Dependency"))
						{
							Console.WriteLine("Der Dependency-Krake lässt etwas fallen...");
							Console.WriteLine("Du hebst das 'Refactor-Katana' auf (+10 DMG)");
							player.Inventory.AddItem("Waffe: Refactor-Katana");
						}
						else if (boss.Name.Contains("SpaghettiBot"))
						{
							Console.WriteLine("SpaghettiBot 3000 entlädt ein Relikt aus der Legacy-Zeit:");
							Console.WriteLine("Du erhältst die legendäre 'Ama no Sakahoko' (+15 DMG)");
							player.Inventory.AddItem("Waffe: Ama no Sakahoko");
						}

						if (boss.UnlocksCompanion)
						{
							if (boss.Name.Contains("RNGesus"))
							{
								Console.WriteLine("\nAlles friert ein. Der Bildschirm beginnt zu flackern...");
								Console.WriteLine("Eine Stimme flüstert: \"Ich bin das Chaos. Ich bin der Zufall. Ich bin... irgendwie cool?\"");
								Console.WriteLine("> RNGesus-Shadow: \"Ich werde dir folgen. Weil... warum nicht?\"");

								var comp = new Companion("RNGesus-Shadow", 0, true);
								player.Companion = comp;
								player.Inventory.AddItem("USB: RNG-Fragment");

								Console.WriteLine("[RNGesus-Shadow ist jetzt dein Begleiter.]");
							}
							else
							{
								Companion comp;
								if (boss.Name.Contains("Troll"))
									comp = new Companion("TryCatch-Troll-Schatten", 3);
								else
									comp = new Companion("Merge-Moench-Schatten", 5);

								player.Companion = comp;
								player.Inventory.AddItem(boss.UsbDrop);
								Console.WriteLine($"Begleiter freigeschaltet: {comp.Name}");
							}
						}

						SaveSystem.Save(new GameState
                        {
                            ZoneName = progress.CurrentZone,
                            Motivation = status.Motivation,
                            Caffeine = status.Caffeine,
                            Skill = status.SkillPoints,
                            InventoryItems = player.Inventory.GetAllItems(),
                            CompanionName = player.Companion?.Name ?? "",
                            DefeatedBosses = progress.DefeatedBosses
                        });
                    }
                    break;

                case "3":
                    status.Anzeigen();
                    break;
				
                case "4":
					ShowInventoryMenu(player);
					break;
				
                case "5":
                    if (progress.ZoneBossGoalReached(zone))
                    {
                        if (zone == "Mainframe-Zitadelle")
                        {
                            Console.WriteLine("Du hast zwei Endbosse besiegt...");
                            Console.WriteLine("Ein Riss öffnet sich in der Konsole...");
                            Console.WriteLine("Der finale Fehler naht: Antares – Der Exec.");
                            FinaleManager.StarteFinalkampf();
                            return;
                        }

                        string next = ZoneManager.GetNextZone(zone);
                        Console.WriteLine($"Du darfst jetzt in die {next} weiterziehen. Fortfahren?");
                        Console.WriteLine("1) Ja 2) Nein");

                        if (Console.ReadLine() == "1")
                        {
                            progress.CurrentZone = next;
                            if (next == "Finale")
                            {
                                FinaleManager.StarteFinalkampf();
                                return;
                            }
                            else
                            {
                                PlayZone(player, status, progress);
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du musst mehr Bosse besiegen, um weiterzuziehen.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Du kehrst zum Hauptmenue zurueck...");
                    GameManager.ReturnToMainMenu();
                    return;

                default:
                    Console.WriteLine("Ungueltige Eingabe.");
                    break;
            }
        }
    }

	private static void ShowInventoryMenu(Player player)
	{
		Console.WriteLine("\nINVENTAR:");
		var items = player.Inventory.GetAllItems();

		if (items.Count == 0)
		{
			Console.WriteLine("Du hast nichts im Inventar.");
			return;
		}

		for (int i = 0; i < items.Count; i++)
		{
			Console.WriteLine($"{i + 1}) {items[i]}");
		}

		Console.WriteLine("Waehle ein Item (Nummer) oder ENTER zum Abbrechen:");
		string input = Console.ReadLine();

		if (int.TryParse(input, out int index) && index > 0 && index <= items.Count)
		{
			string selected = items[index - 1];

			if (selected.Contains("Energy Drink"))
			{
				Console.WriteLine("Du trinkst einen Energy Drink und bekommst +50 HP & 20 Koffein!");
				player.Heal(50);
				player.Inventory.RemoveItem(selected);
			}
			else if (selected.Contains("Waffe"))
			{
				if (selected.Contains("Refactor"))
				{
					player.EquippedWeapon = "Refactor-Katana";
					player.WeaponDamage = 10;
				}
				else if (selected.Contains("Sakahoko"))
				{
					player.EquippedWeapon = "Ama no Sakahoko";
					player.WeaponDamage = 15;
				}
				else if (selected.Contains("Korkenzieher"))
				{
					player.EquippedWeapon = "Code-Korkenzieher";
					player.WeaponDamage = 5;
				}

				Console.WriteLine($"🗡️ Du hast nun {player.EquippedWeapon} ausgeruestet.");
			}

			else if (selected.Contains("TrollShadow") || selected.Contains("GitShadow") || selected.Contains("RNG-Fragment"))
			{
				Companion newComp;

				if (selected.Contains("Troll"))
					newComp = new Companion("TryCatch-Troll-Schatten", 3);
				else if (selected.Contains("Git"))
					newComp = new Companion("Merge-Moench-Schatten", 5);
				else
					newComp = new Companion("RNGesus-Shadow", 0, true);

				player.Companion = newComp;
				Console.WriteLine($"Begleiter gewechselt: {newComp.Name}");
			}
			else
			{
				Console.WriteLine("Unbekannte Itemfunktion.");
			}
		}
	}

	private static void ShowZoneLore(string zone)
	{

		switch (zone.Trim())
		{
			case "Dev-Schlucht":
				Console.WriteLine("Dev-Schlucht");
				Console.WriteLine("Ein Ort voller Tippfehler, Klammern ohne Partner und halb geschriebener Variablen.");
				Console.WriteLine("Hier lernt man nicht zu coden, sondern zu ueberleben.");
				break;

			case "StackOverflow-Ruinen":
				Console.WriteLine("StackOverflow-Ruinen");
				Console.WriteLine("Diese Zone war einst eine lebendige Wissensdatenbank.");
				Console.WriteLine("Jetzt ist sie ueberschwemmt von duplizierten Fragen und Antworten ohne Kontext.");
				Console.WriteLine("Einige sagen, hier spukt der Geist des ersten 'Why doesn’t this work?'-Postings.");
				break;

			case "Mainframe-Zitadelle":
				Console.WriteLine("Mainframe-Zitadelle");
				Console.WriteLine("Der letzte Ort. Hier wurden Legacy-Systeme geboren... und nie mehr gewartet.");
				Console.WriteLine("Vorsicht: Jede Entscheidung kann einen Blue Screen verursachen.");
				break;

			default:
				Console.WriteLine("Diese Zone scheint keiner dokumentiert zu haben. ... Oder hatte seine ProjektDoku nicht rechtzeitig abgegeben");
				break;
		}
	}
}