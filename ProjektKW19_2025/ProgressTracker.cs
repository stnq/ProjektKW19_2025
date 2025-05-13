
using System.Collections.Generic;

public class ProgressTracker
{
    public string CurrentZone { get; set; } = "TutorialZone";
    public Dictionary<string, int> MobsKilled { get; set; } = new();
    public Dictionary<string, int> BossesKilled { get; set; } = new();
    public HashSet<string> DefeatedBosses { get; set; } = new();

    public void RegisterKill(string zone, bool isBoss, string enemyName)
    {
        var dict = isBoss ? BossesKilled : MobsKilled;
        if (!dict.ContainsKey(zone)) dict[zone] = 0;
        dict[zone]++;
        if (isBoss) DefeatedBosses.Add(enemyName);
    }

    public bool ZoneBossGoalReached(string zone)
    {
        return BossesKilled.ContainsKey(zone) && BossesKilled[zone] >= 3;
    }

    public int GetMobsKilled(string zone) => MobsKilled.ContainsKey(zone) ? MobsKilled[zone] : 0;
    public int GetBossesKilled(string zone) => BossesKilled.ContainsKey(zone) ? BossesKilled[zone] : 0;
}
