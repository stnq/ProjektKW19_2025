
using System;
using System.Collections.Generic;
using ProjektKW19_2025;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 250;
	public int MaxHealth { get; set; } = 1000;
	public int Damage { get; set; } = 15 ;
    public Inventory Inventory { get; set; }
	public Companion? Companion { get; set; }
	public string EquippedWeapon { get; set; } = "bloﬂen H‰nden";
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
    }

	public void Attack(Enemy enemy)
	{
		int totalDamage = Damage + WeaponDamage;

		if (Companion != null)
		{
			int extra = Companion.GetDamage(Damage);
			totalDamage += extra;
			Console.WriteLine($"Dein Begleiter {Companion.Name} f¸gt {extra} Bonus-Schaden hinzu!");
		}

		enemy.Health -= totalDamage;
		Console.WriteLine($"Du greifst an und verursachst {totalDamage} Schaden mit {EquippedWeapon}!");
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
