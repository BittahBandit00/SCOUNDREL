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

            if (deck.GetCardCount() == 0 && dungeon.CurrentRoom.Count == 0)
            {
                renderer.PrintWin();
                return;
            }

            if (health.GetHealth() == 0)
            {
                renderer.PrintDefeat();
                return;
            }
        }
    }

    private void HandleAction()
    {
        string action = input.GetAction();

        if (action == "fight" || action == "f")
            return;

        if (action == "run" || action == "r")                   // OPTIONAL RULE -> INCREASE SKIP COUNT TO 2
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
        string raw = input.GetCardSelection(dungeon.CurrentRoom.Count);

        bool useFists = false;

        string trimmed = raw.Trim().ToLower();

        // detect bare‑handed mode
        if (trimmed.EndsWith("b") || trimmed.EndsWith("bare") || trimmed.EndsWith("fists") || trimmed.EndsWith("f"))
        {
            useFists = true;
            trimmed = new string(trimmed.TakeWhile(char.IsDigit).ToArray());
        }

        if (!int.TryParse(trimmed, out int index))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        index -= 1;

        if (index < 0 || index >= dungeon.CurrentRoom.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Card chosen = dungeon.CurrentRoom[index];
        dungeon.CurrentRoom.RemoveAt(index);

        ResolveCard(chosen, useFists);

        if (dungeon.CurrentRoom.Count == 1 && deck.GetCardCount() > 0)
        {
            dungeon.DrawNextRoom();
            hasHealed = false;
            enteringRoom = true;
        }
    }



    private void ResolveHeart(Card card)            // OPTIONAL RULES CANDIDATE - HEAL AS MANY TIMES
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

    private void ResolveEnemy(Card card, bool useFists)
    {
        int weaponValue = 0;

        // If using weapon, get its value
        if (!useFists && weapon.Count > 0)
            weaponValue = weapon.Last().GetValue();

        int enemyValue = card.GetValue();
        int damage = 0;

        // If weapon is an enemy card and too weak, it breaks → forced fists
        if (!useFists && weapon.Count > 0 && (weapon.Last().Suit == "♣" || weapon.Last().Suit == "♠"))
        {
            if (enemyValue >= weaponValue)
            {
                weaponValue = 0;
                useFists = true;
            }
        }

        // If you have no weapon at all → forced fists
        if (weapon.Count == 0)
            useFists = true;

        // Damage calculation
        if (enemyValue > weaponValue)
            damage = enemyValue - weaponValue;

        health.Damage(damage);

        // Only add monster as weapon if NOT bare‑handed
        if (!useFists)
            weapon.Add(card);
    }




    private void ResolveCard(Card card, bool useFists)
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
                ResolveEnemy(card, useFists);
                break;
        }
    }

}

// "♣", "♠", "♥", "♦" 
