using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


public class Renderer
{
    private HashSet<int> haSlots = new HashSet<int>();
    private int cardRowY;
    public int CardRowY => cardRowY;


    public void PrintRoom(List<Card> room, int health, List<Card> weapon, int deckCount, int skips, bool showCardsRemaining)
    {
        Console.Clear();

        Console.WriteLine("===============================================");
        Console.WriteLine("                 D U N G E O N                 ");
        Console.WriteLine("===============================================");

        if (showCardsRemaining)
        {
            Console.WriteLine();
            Console.WriteLine($"ENCOUNTERS:" + deckCount);
        }

        Console.WriteLine();

        cardRowY = Console.CursorTop;
        // Print the cards
        for (int i = 0; i < room.Count; i++)
        {
            Console.Write($" [{i + 1}] ");

            if (haSlots.Contains(i))
                Console.Write("HA!");
            else
                PrintCard(room[i]);

            Console.Write("    ");
        }


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($" HEALTH: {health}");
        PrintWeapon(weapon);
        Console.WriteLine($" ESCAPES LEFT : {skips}");
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
        Console.Write(" WEAPON: ");

        if (weapon.Count > 1)
        {
            PrintCard(weapon[weapon.Count - 1]); // the first card in the chain
        }
        else
        {
            PrintCard(weapon[weapon.Count - 1]);
        }

        if (weapon.Count == 1)
        {
            Console.WriteLine();
            return;
        }
        Console.Write(" (");

        for (int i = 0; i < weapon.Count; i++)
        {
            PrintCard(weapon[i], ConsoleColor.Gray);
            if (i < weapon.Count - 1)
                Console.Write(" > ");
        }

        Console.WriteLine(")");
    }




    public void PrintCard(Card card, ConsoleColor? overrideColor = null)
    {
        var original = Console.ForegroundColor;

        if (overrideColor.HasValue)
        {
            Console.ForegroundColor = overrideColor.Value;
        }
        else
        {
            if (card.Suit == "♥" || card.Suit == "♦")
                Console.ForegroundColor = ConsoleColor.Red;
            else if (card.Suit == "★")
                Console.ForegroundColor = ConsoleColor.White;
            else
                Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

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

    int transformDelay = 75;

    public void AnimateCardLaughs(List<Card> room, int selectedIndex)
    {
        const int flashes = 6;

        for (int f = 0; f < flashes; f++)
        {
            Console.SetCursorPosition(0, CardRowY);

            for (int j = 0; j < room.Count; j++)
            {
                Console.Write($" [{j + 1}] ");

                if (j == selectedIndex)
                {
                    PrintCard(room[j]);
                }
                else
                {
                    var original = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan; // HA! colour
                    Console.Write("HA!");
                    Console.ForegroundColor = original;
                }

                Console.Write("    ");
            }

            Thread.Sleep(transformDelay);

            Console.SetCursorPosition(0, CardRowY);

            for (int j = 0; j < room.Count; j++)
            {
                Console.Write($" [{j + 1}] ");

                if (j == selectedIndex)
                {
                    PrintCard(room[j]);
                }
                else
                {
                    Console.Write("   "); 
                }

                Console.Write("    ");
            }

            Thread.Sleep(transformDelay);
        }
    }


    public void ClearHaSlots()
    {
        haSlots.Clear();
    }


}
