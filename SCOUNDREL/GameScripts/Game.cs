using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    private Dungeon dungeon;
    private OptionalRules optionalRules;
    private Renderer renderer = new Renderer();
    private MainMenu mainMenu;
    
    private Deck deck = new Deck();
    private Health health = new Health();
    private InputController input = new InputController();

    private List<Card> weapon = new List<Card>();

    public bool enteringRoom = true;
    public bool hasHealed = false;

    //optional rules
    private int escapeCount = 1;
    private bool ShowCardsRemaining = false;
    private int hp;
    private bool infiniteHeals = false;
    public Game(OptionalRules rules, MainMenu menu)
    {
        optionalRules = rules;
        mainMenu = menu;
        dungeon = new Dungeon(deck);
       
        InitialiseOptionalRules();
        deck.Shuffle();
    }

    private void InitialiseOptionalRules()
    {
        health.SetMaxHealth(optionalRules.ExtraHealth);
        escapeCount = SetSkips();
        ShowCardsRemaining = optionalRules.ShowEncountersLeft;
        infiniteHeals = optionalRules.InfiniteHeals;

        if (optionalRules.LowAces)
        {
            foreach (var card in deck.cards)
                card.SetAcesToOne();
        }


    }

    private int SetSkips()
    {
        return optionalRules.DoubleSkip ? 2 : 1;
    }

public void Start()
    {
        dungeon.DrawNewRoom();

        while (true)
        {
            renderer.PrintRoom(dungeon.CurrentRoom, health.GetHealth(), weapon, deck.GetCardCount() + dungeon.CurrentRoom.Count, escapeCount, ShowCardsRemaining );


            if (enteringRoom)
            {
                Console.WriteLine("ACTIONS");
                Console.WriteLine();
                Console.WriteLine("  [F]   FIGHT");
                Console.WriteLine("  [E]   ESCAPE");
                Console.WriteLine("  [Q]   QUIT");
                Console.WriteLine();
                Console.Write(">> ");
                if (HandleAction())
                    enteringRoom = false;
            }
            else
            {
                HandleCardSelection();
            }

            if (deck.GetCardCount() == 0 && dungeon.CurrentRoom.Count == 0 && health.GetHealth() > 0)
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

    private bool HandleAction()
    {
        while (true)
        {
            string action = input.GetAction();

            if (string.IsNullOrWhiteSpace(action))
            {
                ClearInputLine();
                Console.Write(">> ");
                continue;
            }

            action = action.ToLower();

            if (action == "f" || action == "fight")
                return true;

            if (action == "e" || action == "escape")
            {
                if (deck.GetCardCount() == 0)
                {
                    ClearInputLine();
                    Console.Write(">> ");
                    continue;
                }

                if (escapeCount > 0)
                {
                    escapeCount--;
                    dungeon.SkipRoom();
                    hasHealed = false;
                    enteringRoom = true;
                    return false;
                }
            }


            if (action == "q")
            {
                mainMenu.Show();
                return true;
            }

            // invalid input: clear and reprompt
            ClearInputLine();
            Console.Write(">> ");
        }
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
            escapeCount = SetSkips();
            enteringRoom = true;
        }
    }



    private void ResolveHeart(Card card)            // OPTIONAL RULES CANDIDATE - HEAL AS MANY TIMES
    {
        if (hasHealed && !infiniteHeals)
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
        int weaponValue = (!useFists && weapon.Count > 0)
            ? weapon.Last().GetValue()
            : 0;

        int enemyValue = card.GetValue();
        int damage = 0;

        bool isAltered = weapon.Count > 0 && (weapon.Last().Suit == "♣" || weapon.Last().Suit == "♠");
        bool canMatch = optionalRules.AlteredWeaponCanMatch && isAltered;

        // Determine if weapon breaks
        if (!useFists && isAltered)
        {
            bool weaponTooWeak =
                canMatch ? enemyValue > weaponValue     // allow equal
                         : enemyValue >= weaponValue;   // strict

            if (weaponTooWeak)
            {
                useFists = true;
                weaponValue = 0;
            }
        }

        if (weapon.Count == 0)
            useFists = true;

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

    private void ClearInputLine()
    {
        int line = Console.CursorTop - 1;
        Console.SetCursorPosition(0, line);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, line);
    }


}

// "♣", "♠", "♥", "♦" 
