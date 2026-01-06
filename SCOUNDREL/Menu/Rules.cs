using System;

public static class Rules
{
    private static void WriteColored(string text, ConsoleColor color)
    {
        var original = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = original;
    }

    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("==============================================================================");
        Console.WriteLine("HOW TO PLAY                    ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine();
        Console.WriteLine("Welcome to SCOUNDREL — a fast, brutal, card‑driven dungeon crawl.");
        Console.WriteLine("Your goal is simple: survive the deck and outlast the dungeon.");
        Console.WriteLine();
        Console.WriteLine("The deck *is* the dungeon. Every card you draw is a room filled with an enemy,");
        Console.WriteLine("a weapon, or a potion. You begin with 20 Health. If it reaches zero, your run");
        Console.WriteLine("ends immediately.");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" ROOM STRUCTURE");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("Each turn, you reveal the top 4 cards of the deck. You must choose");
        Console.WriteLine("one to resolve. The others remain until the room is cleared.");
        Console.WriteLine("When only one card remains, three more cards are drawn to refill.");
        Console.WriteLine();

        // ===================== ENEMIES =====================
        Console.Write("  ENEMIES   ");
        WriteColored("♣", ConsoleColor.DarkCyan);
        Console.Write(" / ");
        WriteColored("♠", ConsoleColor.DarkCyan);
        Console.WriteLine();
        Console.WriteLine("      • Their value is their attack strength — you take that much damage.");
        Console.WriteLine("      • Your weapon reduces incoming damage by its value.");
        Console.WriteLine("      • With NO weapon, you always take the full attack value.");
        Console.WriteLine("      • You may choose to fight an enemy BARE‑HANDED at any time.");
        Console.WriteLine("      • Bare‑handed fights ignore your weapon and deal full damage.");
        Console.WriteLine();

        // ===================== WEAPONS =====================
        Console.Write("  WEAPONS   ");
        WriteColored("♦", ConsoleColor.Red);
        Console.WriteLine();
        Console.WriteLine("      • Picking up a weapon replaces your current one immediately.");
        Console.WriteLine("      • Defeating an enemy sets your weapon's durability to its value.");
        Console.WriteLine("      • If your weapon's durability is lower than the enemy's strength,");
        Console.WriteLine("        it fails to protect you and deals no damage reduction.");
        Console.WriteLine("      • A failed weapon strike forces a bare‑handed fight instead.");
        Console.WriteLine("      • Choosing to fight bare‑handed does NOT destroy your weapon.");
        Console.WriteLine();

        // ===================== POTIONS =====================
        Console.Write("  POTIONS   ");
        WriteColored("♥", ConsoleColor.Red);
        Console.WriteLine();
        Console.WriteLine("      • Potions heal you for their value when selected.");
        Console.WriteLine("      • You may drink ONE potion per room — choose wisely.");
        Console.WriteLine("      • Drinking additional potions in the same room wastes them.");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Face cards use their printed number. Aces count as 14.");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" ACTIONS");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("At the start of each room, you may choose to FIGHT or RUN.");
        Console.WriteLine();
        Console.WriteLine("  FIGHT");
        Console.WriteLine("      • Select a card (1–4) and resolve its effect immediately.");
        Console.WriteLine("      • Add 'B' or 'F' to your choice to fight bare‑handed.");
        Console.WriteLine("        Example:  '2B'  fights card 2 using your fists.");
        Console.WriteLine("      • Bare‑handed attacks ignore your weapon and deal full damage.");
        Console.WriteLine("      • Bare‑handed attacks never change or replace your weapon.");
        Console.WriteLine();
        Console.WriteLine("  RUN");
        Console.WriteLine("      • Sends the chosen enemy to the *bottom* of the deck.");
        Console.WriteLine("      • Cannot be used twice in a row — no coward loops.");
        Console.WriteLine();

        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" OBJECTIVE");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("Clear the entire deck without dying. Every room is a gamble,");
        Console.WriteLine("every choice a wager, and every victory hard-earned.");
        Console.WriteLine();
        Console.WriteLine("Good luck, Scoundrel.");
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();
    }
}
