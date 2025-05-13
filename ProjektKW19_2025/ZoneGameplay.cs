
using System;

public static class ZoneGameplay
{
    public static void PlayZone(Player player, GameStatus status, ProgressTracker progress)
    {
        string zone = progress.CurrentZone;
        var mobs = ZoneManager.GetZoneMobs(zone);
        var bosses = ZoneManager.GetZoneBosses(zone);

        while (true)
        {
            Console.WriteLine($"📍 Zone: {zone}");
            Console.WriteLine("1) Gegen Mob kämpfen");
            Console.WriteLine("2) Gegen Boss kämpfen");
            Console.WriteLine("3) Status anzeigen");
            Console.WriteLine("4) Weiterziehen (nach 3 Bossen)");
            Console.WriteLine("5) Beenden");
            Console.Write("Aktion: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var mob = mobs[new Random().Next(mobs.Count)];
                    if (CombatSystem.Fight(player, mob))
                        progress.RegisterKill(zone, false, mob.Name);
                    break;

                case "2":
                    foreach (var boss in bosses)
                    {
                        if (!progress.DefeatedBosses.Contains(boss.Name))
                        {
                            if (CombatSystem.Fight(player, boss))
                            {
                                progress.RegisterKill(zone, true, boss.Name);
                                if (boss.UnlocksCompanion)
                                {
                                    var comp = new Companion(boss.Name + "-Schatten", boss.Name.Contains("RNGesus") ? 0 : (boss.Name.Contains("Troll") ? 3 : 5), boss.Name.Contains("RNGesus"));
                                    player.Companion = comp;
                                    player.Inventory.AddItem(boss.UsbDrop);
                                    Console.WriteLine($"🔥 Begleiter freigeschaltet: {comp.Name}");
                                }
                            }
                            break;
                        }
                    }
                    break;

                case "3":
                    status.Anzeigen();
                    break;

                case "4":
                    if (progress.ZoneBossGoalReached(zone))
                    {
                        string next = ZoneManager.GetNextZone(zone);
                        Console.WriteLine($"🚪 Du darfst jetzt in die {next} weiterziehen. Fortfahren?");
                        Console.WriteLine("1) Ja 2) Nein");
                        if (Console.ReadLine() == "1")
                        {
                            progress.CurrentZone = next;
                            if (next == "Finale")
                            {
                                Console.WriteLine("⚠️ Du näherst dich dem finalen Bug: Antares...");
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
                        Console.WriteLine("❌ Du musst mindestens 3 Bosse besiegen, um weiterzuziehen.");
                    }
                    break;

                case "5":
                    Console.WriteLine("👋 Spiel wird beendet...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    break;
            }
        }
    }
}
