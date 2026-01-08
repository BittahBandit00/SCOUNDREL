using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Renderer
{
    private HashSet<int> haSlots = new HashSet<int>();
    private int cardRowY;
    public int CardRowY => cardRowY;

    private const int SlotWidth = 13; // width of each card slot

    // -----------------------------
    // MAIN ROOM RENDER
    // -----------------------------
    public void PrintRoom(List<Card> room, int health, List<Card> weapon, int deckCount, int skips, bool showCardsRemaining, int? turnsLeft)
    {
        Console.Clear();

        Console.WriteLine("===============================================");
        Console.WriteLine("                 D U N G E O N                 ");
        Console.WriteLine("===============================================");

        if (turnsLeft.HasValue || showCardsRemaining)
            Console.WriteLine();

        if (turnsLeft.HasValue)
            Console.WriteLine($"TURNS LEFT: {turnsLeft}");

        if (showCardsRemaining)
            Console.WriteLine($"CARDS LEFT: {deckCount}");

        Console.WriteLine();

        cardRowY = Console.CursorTop;

        // FIRST ROW (0–3)
        int top = Math.Min(4, room.Count);
        for (int i = 0; i < top; i++)
        {
            if (haSlots.Contains(i))
                PrintHaSlot(i);
            else
                PrintCardSlot(i, room[i]);
        }

        Console.WriteLine();

        // SECOND ROW (4–7)
        if (room.Count > 4)
        {
            int bottom = Math.Min(8, room.Count);
            for (int i = 4; i < bottom; i++)
            {
                if (haSlots.Contains(i))
                    PrintHaSlot(i);
                else
                    PrintCardSlot(i, room[i]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($" HEALTH: {health}");
        PrintWeapon(weapon);
        Console.WriteLine($" ESCAPES LEFT : {skips}");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();
    }

    // -----------------------------
    // FIXED-WIDTH CARD SLOT
    // -----------------------------
    private void PrintCardSlot(int index, Card card)
    {
        // Handle empty slot FIRST
        if (card == Card.Empty)
        {
            PrintBlankSlot(index);
            return;
        }

        string prefix = $"[{index + 1}] ";
        Console.Write(prefix);

        // Determine printed symbol
        string symbol = SuitSymbols.TryGetValue(card.Suit, out var mapped)
            ? mapped
            : card.Suit;

        // Print the card with color
        PrintCard(card);

        // Compute actual printed width
        int printedLength = prefix.Length + card.Rank.Length + symbol.Length;
        int padding = SlotWidth - printedLength;

        if (padding > 0)
            Console.Write(new string(' ', padding));
    }


    // -----------------------------
    // FIXED-WIDTH HA! SLOT
    // -----------------------------
    private void PrintHaSlot(int index)
    {
        string prefix = $"[{index + 1}] ";
        Console.Write(prefix);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("HA!");
        Console.ResetColor();

        int printedLength = prefix.Length + 3; // "HA!" is 3 chars
        int padding = SlotWidth - printedLength;

        if (padding > 0)
            Console.Write(new string(' ', padding));
    }


    // -----------------------------
    // WEAPON PRINTING
    // -----------------------------
    private void PrintWeapon(List<Card> weapon)
    {
        if (weapon == null || weapon.Count == 0)
        {
            Console.WriteLine(" WEAPON: FISTS");
            return;
        }

        Console.Write(" WEAPON: ");
        PrintCard(weapon.Last());

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

    // -----------------------------
    // COLOURED CARD PRINTER
    // -----------------------------
    public void PrintCard(Card card, ConsoleColor? overrideColor = null)
    {
        var original = Console.ForegroundColor;

        // Determine color
        if (overrideColor.HasValue)
        {
            Console.ForegroundColor = overrideColor.Value;
        }
        else if (SuitColors.TryGetValue(card.Suit, out var color))
        {
            Console.ForegroundColor = color;
        }

        // Determine symbol
        string symbol = SuitSymbols.TryGetValue(card.Suit, out var mapped)
            ? mapped
            : card.Suit; // fallback

        Console.Write($"{card.Rank}{symbol}");
        Console.ForegroundColor = original;
    }


    private static readonly Dictionary<string, string> SuitSymbols = new Dictionary<string, string>()
{
    { "D", "♦" },
    { "H", "♥" },
    { "C", "♣" },
    { "S", "♠" },
    { "JO", "*" } // keep your joker
};
    private static readonly Dictionary<string, ConsoleColor> SuitColors = new Dictionary<string, ConsoleColor>()
{
    { "D", ConsoleColor.Red },
    { "H", ConsoleColor.Red },
    { "C", ConsoleColor.DarkCyan },
    { "S", ConsoleColor.DarkCyan },
    { "JO", ConsoleColor.White }
};


    // -----------------------------
    // ANIMATION
    // -----------------------------
    int transformDelay = 110;

    public void AnimateCardLaughs(List<Card> room, int selectedIndex)
    {
        const int flashes = 4;

        for (int f = 0; f < flashes; f++)
        {
            // ============================
            // PASS 1 — Flash HA!
            // ============================
            Console.SetCursorPosition(0, CardRowY);

            // First row (0–3)
            int top = Math.Min(4, room.Count);
            for (int j = 0; j < top; j++)
            {
                if (j == selectedIndex)
                    PrintCardSlot(j, room[j]);
                else
                    PrintHaSlot(j);
            }

            Console.WriteLine();

            // Second row (4–7)
            if (room.Count > 4)
            {
                int bottom = Math.Min(8, room.Count);
                for (int j = 4; j < bottom; j++)
                {
                    if (j == selectedIndex)
                        PrintCardSlot(j, room[j]);
                    else
                        PrintHaSlot(j);
                }
                Console.WriteLine();
            }

            Thread.Sleep(transformDelay);

            // ============================
            // PASS 2 — Clear HA!
            // ============================
            Console.SetCursorPosition(0, CardRowY);

            // First row (0–3)
            for (int j = 0; j < top; j++)
            {
                if (j == selectedIndex)
                    PrintCardSlot(j, room[j]);
                else
                    PrintBlankSlot(j);
            }

            Console.WriteLine();

            // Second row (4–7)
            if (room.Count > 4)
            {
                int bottom = Math.Min(8, room.Count);
                for (int j = 4; j < bottom; j++)
                {
                    if (j == selectedIndex)
                        PrintCardSlot(j, room[j]);
                    else
                        PrintBlankSlot(j);
                }
                Console.WriteLine();
            }

            Thread.Sleep(transformDelay);
        }
    }


    private void PrintBlankSlot(int index)
    {
        string prefix = $"[{index + 1}] ";
        string blank = "   "; // must match HA! width

        Console.Write(prefix);
        Console.Write(blank);

        int printedLength = prefix.Length + blank.Length;
        int padding = SlotWidth - printedLength;

        if (padding > 0)
            Console.Write(new string(' ', padding));
    }


    // -----------------------------
    // UTILITY
    // -----------------------------
    public void ClearHaSlots()
    {
        haSlots.Clear();
    }
    //private int GetPrintedCardWidth(Card card)
    //{
    //    string symbol = SuitSymbols.TryGetValue(card.Suit, out var mapped)
    //        ? mapped
    //        : card.Suit;

    //    return card.Rank.Length + symbol.Length;
    //}

    // -----------------------------
    // WIN / LOSE SCREENS
    // -----------------------------
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
