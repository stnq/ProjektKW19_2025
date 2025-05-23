using System;
using System.IO;
using System.Text.Json;

public static class SaveSystem
{
	private static string GetPath(int slot)
	{
		string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WWD");
		Directory.CreateDirectory(directory);
		return Path.Combine(directory, $"save_slot{slot}.json");
	}

	public static void Save(GameState state, int slot)
	{
		try
		{
			string path = GetPath(slot);
			string json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(path, json);
			Console.WriteLine($"Spielstand in Slot {slot} gespeichert!");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
		}
	}

	public static GameState Load(int slot)
	{
		try
		{
			string path = GetPath(slot);

			if (!File.Exists(path))
			{
				Console.WriteLine($"Kein Spielstand in Slot {slot} gefunden. Neuer Spielstand wird erstellt.");
				return new GameState();
			}

			string json = File.ReadAllText(path);
			GameState state = JsonSerializer.Deserialize<GameState>(json);

			Console.WriteLine($"Spielstand aus Slot {slot} geladen.");
			return state ?? new GameState();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Fehler beim Laden von Slot {slot}: {ex.Message}");
			return new GameState();
		}
	}
}
