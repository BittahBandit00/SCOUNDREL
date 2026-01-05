using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    private Deck deck = new Deck();
    private Health health = new Health();
    private Dungeon dungeon;
    private Renderer renderer = new Renderer();
    private InputController input = new InputController();

    private List<Card> weapon = new List<Card>();

    public bool enteringRoom = true;
    public bool hasHealed = false;

    public Game()
    {
        deck.Shuffle();
        dungeon = new Dungeon(deck);
    }

    public void Start()
    {
        dungeon.DrawNewRoom();

        while (true)
        {
            renderer.PrintRoom(dungeon.CurrentRoom, health.GetHealth(), weapon);

            if (enteringRoom)
            {
                HandleAction();
                enteringRoom = false;
            }
            else
            {
                HandleCardSelection();
            }

            if(deck.GetCardCount() == 0 && dungeon.CurrentRoom.Count == 0)
            {
                renderer.PrintWin();
                return;
            }

            if(health.GetHealth() == 0)
            {
                // lose condition
            }
        }
    }

    private void HandleAction()
    {
        string action = input.GetAction();

        if (action == "fight" || action == "f")
            return;

        if (action == "run" || action == "r")
        {
            dungeon.SkipRoom();
            hasHealed = false;
            enteringRoom = true;
            return;
        }

            Console.WriteLine("Unknown action.");
    }

    private void HandleCardSelection()
    {
        int index = input.GetCardSelection(dungeon.CurrentRoom.Count);

        if (index < 0 || index >= dungeon.CurrentRoom.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Card chosen = dungeon.CurrentRoom[index];
        dungeon.CurrentRoom.RemoveAt(index);

        Console.WriteLine("You selected: " + chosen);
        ResolveCard(chosen);

        if (dungeon.CurrentRoom.Count == 1 && deck.GetCardCount() > 0)
        {
            dungeon.DrawNextRoom();
            hasHealed = false;
            enteringRoom = true;
        }
    }

    private void ResolveHeart(Card card)
    {
        if (hasHealed)
            return;

        health.Heal(card.GetValue());
        hasHealed = true;
    }
    
    private void ResolveDiamond(Card card)
    {
        weapon.Clear();
        weapon.Add(card);

    }

    private void ResolveEnemy(Card card)
    {
        int weaponValue;
        int damage = 0;
         
        // pretty sure if latest weapon card is enemy, and the enemy card is higher, you fight bare fisted

        if (weapon.Count == 0)
        {
            weaponValue = 0;
        }
        else
        {
            weaponValue = weapon.Last<Card>().GetValue();
        }
        
        if (card.GetValue() > weaponValue)
        {
            damage = card.GetValue() - weaponValue;
        }

        health.Damage(damage);

        weapon.Add(card);
    }

    private void ResolveCard(Card card)
    {
        switch (card.Suit)
        {
            case "♥":
                ResolveHeart(card);
                break;

            case "♦":
                ResolveDiamond(card);
                break;

            case "♣":
            case "♠":
                ResolveEnemy(card);
                break;
        }
    }
}

// "♣", "♠", "♥", "♦" 
