public class Card
{
    public string Rank { get; private set; }
    public string Suit { get; }

    private bool aceIsOne = false;
    private bool heartIsOne = false;

    public Card(string rank, string suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public int GetValue()
    {
        if (Suit == "♥" && heartIsOne)
            return 1;

        if (int.TryParse(Rank, out int value))
            return value;

        // Face cards
        switch (Rank)
        {
            case "J": return 11;
            case "Q": return 12;
            case "K": return 13;
            case "A": return aceIsOne ? 1 : 14;
        }

        return 0;
    }

    public void SetAcesToOne()
    {
        aceIsOne = true;
        if (Rank == "A")
            Rank = "1";
    }

    public void SetHeartsToOne()
    {
        heartIsOne = true;
        if (Suit == "♥")
            Rank = "1";
    }

    public override string ToString() => $"{Rank}{Suit}";
}
