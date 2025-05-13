
public class Companion
{
    public string Name { get; set; }
    public int BaseDamage { get; set; }
    public bool ScalesWithPlayer { get; set; }

    public Companion(string name, int baseDamage, bool scales = false)
    {
        Name = name;
        BaseDamage = baseDamage;
        ScalesWithPlayer = scales;
    }

    public int GetDamage(int playerDmg)
    {
        return ScalesWithPlayer ? BaseDamage + (playerDmg / 5 * 2) : BaseDamage;
    }
}
