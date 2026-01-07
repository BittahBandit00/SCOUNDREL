using System;
using System.Linq;
using System.Collections.Generic;


public class Renderer
{

    public void PrintRoom(List<Card> room, int health, List<Card> weapon, int deckCount, int skips, bool showCardsRemaining)
    {
        Console.Clear();

        Console.WriteLine("===============================================");
        Console.WriteLine("                 D U N G E O N                 ");
        Console.WriteLine("===============================================");
        if (showCardsRemaining)
            Console.WriteLine($"cards left:" + deckCount);

        Console.WriteLine();

        for (int i = 0; i < room.Count; i++)
        {
            Console.Write($" [{i + 1}] ");
            PrintCard(room[i]);
            Console.Write("    ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($" HEALTH: {health}");
        PrintWeapon(weapon);
        Console.WriteLine($" SKIPS : {skips}");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();

    }


    private void PrintWeapon(List<Card> weapon)
    {
        if (weapon == null || weapon.Count == 0)
        {
            Console.WriteLine(" WEAPON: FISTS");
            return;
        }

        // Active durability card (last)
        Console.Write(" WEAPON: ");
        PrintCard(weapon[weapon.Count - 1]);

        // If only one card, we're done
        if (weapon.Count == 1)
        {
            Console.WriteLine();
            return;
        }

        // Print chain: first -> ... -> last
        Console.Write(" (");

        for (int i = 0; i < weapon.Count; i++)
        {
            PrintCard(weapon[i]);
            if (i < weapon.Count - 1)
                Console.Write(" > ");
        }

        Console.WriteLine(")");
    }




    public void PrintCard(Card card)
    {
        var original = Console.ForegroundColor;

        if (card.Suit == "♥" || card.Suit == "♦")
            Console.ForegroundColor = ConsoleColor.Red;
        else
            Console.ForegroundColor = ConsoleColor.DarkCyan;

        Console.Write($"{card.Rank}{card.Suit}");
        Console.ForegroundColor = original;
    }

    public void PrintWin()
    {
        Console.Clear();

        Console.WriteLine("====================================================");
        Console.WriteLine("                    V I C T O R Y                   ");
        Console.WriteLine("====================================================");
        Console.WriteLine();
        Console.WriteLine("   You have conquered the dungeon.");
        Console.WriteLine("   You have outplayed fate itself.");
        Console.WriteLine("   The deck is empty. Your story is not.");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("                 YOU ARE A SCOUNDREL                ");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("   Press Enter to return to the main menu...");
        Console.ReadLine();
    }

    public void PrintDefeat()

    {
        Console.Clear();

        Console.WriteLine("====================================================");
        Console.WriteLine("                    D E F E A T                     ");
        Console.WriteLine("====================================================");
        Console.WriteLine();
        Console.WriteLine("   Your journey ends here.");
        Console.WriteLine("   The dungeon claims another soul.");
        Console.WriteLine("   The deck is not empty...");
        Console.WriteLine("   but you are.");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("                 BETTER LUCK NEXT TIME              ");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("   Press Enter to return to the main menu...");
        Console.ReadLine();
    }


}
