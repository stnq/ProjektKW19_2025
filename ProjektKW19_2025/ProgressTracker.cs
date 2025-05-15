using System.Collections.Generic;

public class ProgressTracker
{
    public string CurrentZone = "Dev-Schlucht";
    public List<string> DefeatedBosses = new();

    public void RegisterKill(string zone, bool isBoss, string name)
    {
        if (isBoss && !DefeatedBosses.Contains(name))
            DefeatedBosses.Add(name);
    }

    public bool ZoneBossGoalReached(string zone)
    {
        int defeatedCount = DefeatedBosses
            .FindAll(name => ZoneManager.GetZoneBosses(zone).Exists(b => b.Name == name)).Count;

        if (zone == "StackOverflow-Ruinen")
            return defeatedCount >= 3;

        if (zone == "Mainframe-Zitadelle")
            return defeatedCount >= 2;

        return defeatedCount >= 3;
    }
}