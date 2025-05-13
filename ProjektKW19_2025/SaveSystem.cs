
using System;

public static class SaveSystem
{
    public static void Save(GameState state)
    {
        // In einer echten App: JSON schreiben
        Console.WriteLine("💾 Spielstand gespeichert! (Mock)");
    }

    public static GameState Load()
    {
        // In einer echten App: JSON lesen
        Console.WriteLine("📂 Spielstand geladen! (Mock)");
        return new GameState();
    }
}
