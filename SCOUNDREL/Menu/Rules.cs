using System;
using System.Linq;

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
        LineWithHighlight("      • You may choose to fight an enemy with your FISTS at any time.", ("FISTS", ConsoleColor.Yellow));
        LineWithHighlight("      • FISTS ignore your weapon and you receive full damage.", ("FISTS", ConsoleColor.Yellow));
        Console.WriteLine();

        // ===================== WEAPONS =====================
        Console.Write("  WEAPONS   ");
        WriteColored("♦", ConsoleColor.Red);
        Console.WriteLine();
        LineWithHighlight("      • Picking up a diamond card gives you a RED weapon with that card's value.", ("RED", ConsoleColor.Red));
        LineWithHighlight("      • A RED weapon can be used against any enemy, blocking damage", ("RED", ConsoleColor.Red)); ;
        Console.WriteLine("        equal to your weapon's value, even if the enemy's value is higher.");
        Console.WriteLine("      • When you defeat an enemy using your weapon, your weapon becomes");
        LineWithHighlight("        BLUE.", ("BLUE", ConsoleColor.DarkCyan));
        LineWithHighlight("      • BLUE weapons only work on enemies with a lower value.", ("BLUE", ConsoleColor.DarkCyan));
        LineWithHighlight("      • If you use your BLUE weapon against an enemy whose value is not lower,", ("BLUE", ConsoleColor.DarkCyan));
        LineWithHighlight("        you will be forced into using FISTS and you take full damage.", ("FISTS", ConsoleColor.Yellow));
        LineWithHighlight("      • Using FISTS never use or change your weapon.", ("FISTS", ConsoleColor.Yellow));
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
        LineWithHighlight("      • Add 'B' or 'F' to fight with your FISTS.", ("FISTS", ConsoleColor.Yellow));
        LineWithHighlight("        Example: '2F' fights card [2] using your FISTS.", ("FISTS", ConsoleColor.Yellow));
        LineWithHighlight("      • If you defeat an enemy using a RED weapon it becomes,", ("RED", ConsoleColor.Red));
        LineWithHighlight("        a BLUE weapon with that enemy's value (see WEAPONS section).", ("BLUE", ConsoleColor.DarkCyan));
        Console.WriteLine("      • A weapon only protects you if its value is higher");
        Console.WriteLine("        than the enemy's value.");
        LineWithHighlight("      • FISTS attacks ignore your weapon and always deal full damage.", ("FISTS", ConsoleColor.Yellow));
        Console.WriteLine();
        Console.WriteLine("  ESCAPE");
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

    public static void ShowQuickReference()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine(" QUICK REFERENCE");
        Console.WriteLine("------------------------------------------------------------------------------");

        WriteColored("♣", ConsoleColor.DarkCyan);
        Console.Write(" / ");
        WriteColored("♠", ConsoleColor.DarkCyan);
        Console.WriteLine("  ENEMY — Take damage equal to enemy value");

        WriteColored("♥", ConsoleColor.Red);
        Console.WriteLine("  POTION — Heal for card value (max 1 per room)");

        WriteColored("♦", ConsoleColor.Red);
        Console.WriteLine("  WEAPON — Gain a RED weapon with that card's value");

        Console.WriteLine();
        LineWithHighlight("RED WEAPON — Blocks damage equal to its value", ("RED", ConsoleColor.Red));
        LineWithHighlight("BLUE WEAPON — Only works on enemies with lower value", ("BLUE", ConsoleColor.DarkCyan));
        LineWithHighlight("FISTS — Always take full damage", ("FISTS", ConsoleColor.Yellow));

        Console.WriteLine();
        Console.WriteLine("ESCAPE — Sends all 4 cards to the bottom of the deck");
        Console.WriteLine("WIN — Empty the deck and clear the final room");
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the Dungeon.");
        Console.ReadLine();
    }

    private static void LineWithHighlight(
    string text,
    params (string word, ConsoleColor color)[] highlights)
    {
        var original = Console.ForegroundColor;

        int index = 0;

        while (index < text.Length)
        {
            // Find the next highlight match
            var match = highlights
                .Select(h => (h.word, h.color, pos: text.IndexOf(h.word, index, StringComparison.OrdinalIgnoreCase)))
                .Where(m => m.pos >= 0)
                .OrderBy(m => m.pos)
                .FirstOrDefault();

            // No more matches - write the rest normally
            if (match.word == null)
            {
                Console.Write(text.Substring(index));
                break;
            }

            // Write text before the match
            if (match.pos > index)
                Console.Write(text.Substring(index, match.pos - index));

            // Write the highlighted word
            Console.ForegroundColor = match.color;
            Console.Write(match.word);
            Console.ForegroundColor = original;

            // Move index past the highlighted word
            index = match.pos + match.word.Length;
        }

        Console.WriteLine();
    }

}
