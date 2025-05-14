
using System;
using System.Collections.Generic;
using WorldsWorstGamedev;

public class Inventory
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"🎒 Du hast '{item}' erhalten.");
    }

    public void ShowInventory()
    {
        Console.WriteLine("\n[📦 INVENTAR]");
        if (items.Count == 0)
        {
            Console.WriteLine("Leer.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine($"- {item}");
        }
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void UseItem(string item)
    {
        if (!items.Contains(item))
        {
            Console.WriteLine("❌ Item nicht im Inventar.");
            return;
        }

        switch (item)
        {
            case "Energy Drink":
                Console.WriteLine("🧃 Du trinkst einen Energy Drink. Koffein +20");
                GameManager.Status.Caffeine += 20;
                break;
            case "Kaputte Tastatur":
                Console.WriteLine("⌨️ Du hast ein defektes Artefakt gefunden... Vielleicht ist es spaeter wichtig.");
                break;
            default:
                Console.WriteLine("Das Item scheint keinen Effekt zu haben...");
                break;
        }

        items.Remove(item);
    }

	public List<string> GetAllItems()
	{
		return new List<string>(items);
	}


}
