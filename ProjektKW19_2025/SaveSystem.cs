using System;
using System.IO;
using System.Text.Json;

public static class SaveSystem
{
    private static readonly string SavePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WWD", "savegame.json");

    public static void Save(GameState state)
    {
        try
        {
            string directory = Path.GetDirectoryName(SavePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SavePath, json);
            Console.WriteLine("Spielstand erfolgreich gespeichert!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
        }
    }

    public static GameState Load()
    {
        try
        {
            if (!File.Exists(SavePath))
            {
                Console.WriteLine("Kein Spielstand gefunden. Neuer Spielstand wird gestartet.");
                return new GameState();
            }

            string json = File.ReadAllText(SavePath);
            GameState state = JsonSerializer.Deserialize<GameState>(json);

            Console.WriteLine("Spielstand erfolgreich geladen.");
            Console.WriteLine("Bisher besiegte Bosse:");
            foreach (var b in state.DefeatedBosses)
            {
                Console.WriteLine($"- {b}");
            }

            return state ?? new GameState();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden: {ex.Message}");
            return new GameState();
        }
    }
}