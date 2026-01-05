using System.Collections.Generic;

public class Dungeon
{
    private Deck deck;
    public List<Card> CurrentRoom { get; private set; } = new List<Card>();

    public Dungeon(Deck deck)
    {
        this.deck = deck;
    }

    public void DrawNewRoom()
    {
        CurrentRoom.Clear();
        for (int i = 0; i < 4; i++)
            CurrentRoom.Add(deck.Draw());
    }

    public void DrawNextRoom()
    {
        while (CurrentRoom.Count < 4 && deck.GetCardCount() > 0)
        {
            CurrentRoom.Add(deck.Draw());
        }
    }


    public void SkipRoom()
    {
        foreach (var card in CurrentRoom)
            deck.ReturnCardToBottom(card);

        DrawNewRoom();
    }
}
