using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    public List<Card> cards = new List<Card>();
    private Random rng = new Random();

    public Deck()
    {
        string[] blackSuits = { "♣", "♠" };
        string[] blackRanks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        string[] redSuits = { "♥", "♦" };
        string[] redRanks = { "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        foreach (var suit in blackSuits)
            foreach (var rank in blackRanks)
                cards.Add(new Card(rank, suit));

        foreach (var suit in redSuits)
            foreach (var rank in redRanks)
                cards.Add(new Card(rank, suit));
    }

    public void Shuffle() =>
        cards = cards.OrderBy(_ => rng.Next()).ToList();

    public Card Draw()
    {
        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    public void ReturnCardToBottom(Card card)
    {
        cards.Add(card);
    }

    public int GetCardCount()
    {
        return cards.Count;
    }
}