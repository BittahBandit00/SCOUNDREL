using System;

public static class Rules
{
    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("====================================================");
        Console.WriteLine("                     HOW TO PLAY                    ");
        Console.WriteLine("====================================================");
        Console.WriteLine();
        Console.WriteLine("Welcome to SCOUNDREL — a fast, brutal, card‑driven dungeon crawl.");
        Console.WriteLine("Your goal is simple: survive the deck.");
        Console.WriteLine();
        Console.WriteLine("The deck *is* the dungeon. Every card you draw is a room, an enemy,");
        Console.WriteLine("or a potion. You begin with 20 health. If it hits zero, your run ends.");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine(" ROOM STRUCTURE");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Each turn, you reveal the top 4 cards of the deck.");
        Console.WriteLine();
        Console.WriteLine("  ♣ / ♠  ENEMIES");
        Console.WriteLine("      • Their value = their attack strength");
        Console.WriteLine("      • You take damage equal to their value");
        Console.WriteLine("      • Your weapon reduces incoming damage");
        Console.WriteLine("      • Defeating an enemy sets your weapon to its value");
        Console.WriteLine("      • If you currently have NO weapon, you take full damage");
        Console.WriteLine();
        Console.WriteLine("  ♦  WEAPONS");
        Console.WriteLine("      • Picking one up replaces your current weapon");
        Console.WriteLine("      • Your weapon value reduces incoming enemy damage");
        Console.WriteLine("      • If your weapon is damaged and its value is lower than the enemy’s,");
        Console.WriteLine("        you fight bare‑handed and take full damage");
        Console.WriteLine();
        Console.WriteLine("  ♥  POTIONS");
        Console.WriteLine("      • Heal you for their value");
        Console.WriteLine("      • You may drink ONE potion per room");
        Console.WriteLine("      • Drinking more simply wastes them");
        Console.WriteLine();
        Console.WriteLine("Face cards use their number. Aces count as 14.");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine(" ACTIONS");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("You may choose to FIGHT or RUN.");
        Console.WriteLine();
        Console.WriteLine("  FIGHT");
        Console.WriteLine("      • Select a card and resolve its effect");
        Console.WriteLine("      • Enemies deal damage, potions heal, weapons equip");
        Console.WriteLine();
        Console.WriteLine("  RUN");
        Console.WriteLine("      • Shuffles the chosen enemy back to the *bottom* of the deck");
        Console.WriteLine("      • Cannot be used twice in a row");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine(" OBJECTIVE");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Clear the entire deck without dying.");
        Console.WriteLine("Every decision matters. Every card could save you or kill you.");
        Console.WriteLine();
        Console.WriteLine("Good luck, Scoundrel.");
        Console.WriteLine();
    }
}
