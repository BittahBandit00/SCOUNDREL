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
        int roomCount = 4;             // good candidate for optional rule


        CurrentRoom.Clear();


        for (int i = 0; i < roomCount; i++)
        {
            if (deck.GetCardCount() > 0)
                CurrentRoom.Add(deck.Draw());
        }
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

    public void Reset()
    {
        foreach (var card in CurrentRoom)
            deck.ReturnCardToBottom(card);
        CurrentRoom.Clear();
    }

}
