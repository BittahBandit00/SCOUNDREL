using System.Collections.Generic;

public class Dungeon
{
    private Deck deck;
    private int roomCount;
    public List<Card> CurrentRoom { get; private set; } = new List<Card>();

    public Dungeon(Deck deck)
    {
        this.deck = deck;
       
    }

    public void SetRoomCount(int roomCount)
    {
        this.roomCount = roomCount;
    }

    public void DrawNewRoom()
    {
        CurrentRoom.Clear();


        for (int i = 0; i < roomCount; i++)
        {
            if (deck.GetCardCount() > 0)
                CurrentRoom.Add(deck.Draw());
        }
    }

    public void DrawNextRoom()
    {
        while (CurrentRoom.Count < roomCount && deck.GetCardCount() > 0)
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
