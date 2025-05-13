
using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public int Damage { get; set; } = 10;
    public Companion? Companion { get; set; }
    public Inventory Inventory { get; set; }

    public Player(string name)
    {
        Name = name;
        Inventory = new Inventory();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
        Console.WriteLine($"☠️ {Name} erleidet {amount} Schaden! HP: {Health}");
    }

    public void Attack(BugEnemy enemy)
    {
        int totalDamage = Damage;
        if (Companion != null)
        {
            int extra = Companion.GetDamage(Damage);
            totalDamage += extra;
            Console.WriteLine($"🛡️ Dein Begleiter {Companion.Name} fügt {extra} Bonus-Schaden hinzu!");
        }

        enemy.Health -= totalDamage;
        Console.WriteLine($"🗡️ Du greifst an und verursachst {totalDamage} Schaden!");
    }

    public bool IsAlive() => Health > 0;
}
