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
        Console.WriteLine("Welcome to SCOUNDREL — a fast, brutal, card-driven dungeon crawl.");
        Console.WriteLine("Your goal is simple: survive the deck and outlast the dungeon.");
        Console.WriteLine();
        Console.WriteLine("The deck *is* the dungeon. Every card you draw is a room filled with an enemy,");
        Console.WriteLine("a weapon, or a potion. You begin with 20 Health. If it reaches zero, your run");
        Console.WriteLine("ends immediately.");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" ROOM STRUCTURE");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("Each turn, you reveal the top four cards of the deck. Choose one to resolve;");
        Console.WriteLine("the others remain until the room is cleared. When only one card remains,");
        Console.WriteLine("three new cards are drawn to refill the room.");
        Console.WriteLine();
        Console.WriteLine("Face cards use their printed number. Aces count as 14.");
        Console.WriteLine("Card values:");
        Console.WriteLine("  J = 11");
        Console.WriteLine("  Q = 12");
        Console.WriteLine("  K = 13");
        Console.WriteLine("  A = 14");
        Console.WriteLine();

        // ===================== ENEMIES =====================
        Console.Write("  ENEMIES   ");
        WriteColored("♣", ConsoleColor.DarkCyan);
        Console.Write(" / ");
        WriteColored("♠", ConsoleColor.DarkCyan);
        Console.WriteLine();
        Console.WriteLine("      • An enemy's value is its attack strength - you take that much damage.");
        Console.WriteLine("      • Your weapon can reduce this damage when it applies.");
        Console.WriteLine("      • With no weapon, you always take the full attack value.");
        Console.WriteLine("      • You may choose to fight an enemy with your FISTS at any time.");
        Console.WriteLine("      • Fist fights ignore your weapon and you receive full damage.");
        Console.WriteLine();

        // ===================== WEAPONS =====================
        Console.Write("  WEAPONS   ");
        WriteColored("♦", ConsoleColor.Red);
        Console.WriteLine();
        Console.WriteLine("      • Picking up a diamond card gives you a weapon with that card's value.");
        Console.WriteLine("      • A fresh weapon can be used against any enemy, reducing damage");
        Console.WriteLine("        by its value, even if the enemy's value is higher.");
        Console.WriteLine("      • When you defeat an enemy using your weapon, its durability");
        Console.WriteLine("        becomes that enemy's value.");
        Console.WriteLine("      • After that, your weapon only protects you against enemies");
        Console.WriteLine("        with a MODIFIED value than its current durability.");
        Console.WriteLine("      • If you use your weapon against an enemy whose value is not lower,");
        Console.WriteLine("        it fails to protect you and you take full damage.");
        Console.WriteLine("      • Fist fights do not use or change your weapon's durability.");
        Console.WriteLine("      • Tip: Use fresh, high-value weapons to safely fight strong enemies");
        Console.WriteLine("        before your durability locks in to a lower value.");
        Console.WriteLine();



        // ===================== POTIONS =====================
        Console.Write("  POTIONS   ");
        WriteColored("♥", ConsoleColor.Red);
        Console.WriteLine();
        Console.WriteLine("      • Potions heal you for their value when selected.");
        Console.WriteLine("      • You may drink ONE potion per room — choose wisely.");
        Console.WriteLine("      • Healing cannot exceed your maximum health - extra healing is lost.");
        Console.WriteLine("      • Drinking additional potions in the same room wastes them.");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" ACTIONS");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("At the start of each room, you may choose to FIGHT or RUN.");
        Console.WriteLine();
        Console.WriteLine("  FIGHT");
        Console.WriteLine("      • Select a card (1-4) and resolve its effect immediately.");
        Console.WriteLine("      • Add 'B' or 'F' to fight with your fists.");
        Console.WriteLine("        Example: '2F' fights card 2 using your fists.");
        Console.WriteLine("      • If you defeat an enemy using a red weapon, its durability");
        Console.WriteLine("        becomes that enemy's value (see WEAPONS section).");
        Console.WriteLine("      • A weapon only protects you if its durability is higher");
        Console.WriteLine("        than the enemy's value.");
        Console.WriteLine("      • Fist attacks ignore your weapon and always deal full damage.");
        Console.WriteLine();
        Console.WriteLine("  RUN");
        Console.WriteLine("      • Sends all 4 cards to the *bottom* of the deck.");
        Console.WriteLine("      • Cannot be used twice in a row - no coward loops.");
        Console.WriteLine();

        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" OBJECTIVE");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("You win when the deck is empty and the final room is cleared.");
        Console.WriteLine("Clear the entire deck without dying. Every room is a gamble,");
        Console.WriteLine("every choice a wager, and every victory hard-earned.");
        Console.WriteLine();
        Console.WriteLine("Good luck, Scoundrel.");
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu...");
        Console.WriteLine("Tip: Scroll up if you missed anything.");
        Console.ReadLine();
    }
}
