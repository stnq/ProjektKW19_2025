using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKW19_2025
{
	class Player
	{
		public string Name { get; private set; }
		public int Damage { get; private set; }
		public List<Item> Inventory { get; private set; }

		public Player(string name)
		{
			Name = name;
			Damage = 5; 
			Inventory = new List<Item>();
		}

		public int Attack()
		{
			return Damage;
		}

		public void AddItem(Item item)
		{
			Inventory.Add(item);
			Console.WriteLine($"Item erhalten: {item.Name}");
		}
	}
}
