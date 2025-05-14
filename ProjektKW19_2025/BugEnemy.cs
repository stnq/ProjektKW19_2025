
public class BugEnemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public BugEnemy(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public void Attack(Player player)
    {
        Console.WriteLine($"👾 {Name} greift an fuer {Damage} Schaden!");
        player.TakeDamage(Damage);
    }

    public bool IsAlive() => Health > 0;
}
