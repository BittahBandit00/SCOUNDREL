using System;
using System.Collections.Generic;

public class Renderer
{
    public void PrintRoom(List<Card> room, int health, List<Card> weapon)
    {
        Console.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("                 D U N G E O N               ");
        Console.WriteLine("==============================================");
        Console.WriteLine();

        for (int i = 0; i < room.Count; i++)
        {
            Console.Write($" [{i + 1}] ");
            PrintCard(room[i]);
            Console.Write("    ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($" HEALTH: {health}");
        PrintWeapon(weapon);
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();
    }

    private void PrintWeapon(List<Card> weapon)
    {
        if (weapon == null || weapon.Count == 0)
        {
            Console.WriteLine(" WEAPON: (none)");
            return;
        }

        Console.Write(" WEAPON: ");

        for (int i = 0; i < weapon.Count; i++)
        {
            PrintCard(weapon[i]);

            if (i < weapon.Count - 1)
                Console.Write(", "); // separator between cards
        }

        Console.WriteLine();
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

}
