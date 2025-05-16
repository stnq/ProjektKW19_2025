using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKW19_2025
{
	public abstract class Enemy
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int Damage { get; set; }

		protected Enemy(string name, int health, int damage)
		{
			Name = name;
			Health = health;
			Damage = damage;
		}

		public virtual void Attack(Player player)
		{
			Console.WriteLine($"{Name} greift an für {Damage} Schaden!");
			player.TakeDamage(Damage);
		}

		public bool IsAlive() => Health > 0;
	}
}
