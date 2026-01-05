using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    public string Rank { get; }
    public string Suit { get; }

    public Card(string rank, string suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public int GetValue()
    {
        if (int.TryParse(Rank, out int value))
            return value;

        switch (Rank)
        {
            case "J": return 11;
            case "Q": return 12;
            case "K": return 13;
            case "A": return 14;
            default: return 0;
        }
    }

    public override string ToString() => $"{Rank}{Suit}";
}