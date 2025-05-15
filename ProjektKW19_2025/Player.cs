
using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 200;
	public int MaxHealth { get; set; } = 1000;
	public int Damage { get; set; } = 15 ;
    public Inventory Inventory { get; set; }
	public Companion? Companion { get; set; }
	public string EquippedWeapon { get; set; } = "Keine";
	public int WeaponDamage { get; set; } = 0;
	
    public Player(string name)
    {
        Name = name;
        Inventory = new Inventory();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
        Console.WriteLine($"{Name} erleidet {amount} Schaden! HP: {Health}");
    }

    public void Attack(BugEnemy enemy)
    {
        int totalDamage = Damage;
        if (Companion != null)
        {
            int extra = Companion.GetDamage(Damage);
            totalDamage += extra;
            Console.WriteLine($"Dein Begleiter {Companion.Name} fuegt {extra} Bonus-Schaden hinzu!");
        }

        enemy.Health -= totalDamage;
        Console.WriteLine($"Du greifst an und verursachst {totalDamage} Schaden!");
    }


	public void Heal(int amount)
	{
		Health += amount;
		if (Health > MaxHealth)
			Health = MaxHealth;
		Console.WriteLine($"Aktuelle HP: {Health}/{MaxHealth}");
	}



	public bool IsAlive() => Health > 0;
}
