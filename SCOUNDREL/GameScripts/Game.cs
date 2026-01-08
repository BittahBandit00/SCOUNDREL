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
    private MainMenu mainMenu;
    private OptionalRules optionalRules;
    
    private Deck deck = new Deck();
    private Health health = new Health();
    private Renderer renderer = new Renderer();
    private InputController input = new InputController();

    private List<Card> weapon = new List<Card>();

    public bool hasHealed = false;
    public bool enteringRoom = true;

    //optional rules
    private int escapeCount = 1;
    private bool infiniteHeals = false;
    private bool ShowCardsRemaining = false;
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

        if (optionalRules.AllHeartsAreOne)
        {
            foreach (var card in deck.cards)
                card.SetHeartsToOne();

        }
      
        if (optionalRules.JokerShuffle)
        {
            deck.cards.Add(new Card("JO", "★"));
            deck.cards.Add(new Card("JO", "★"));

            //debug
            for (int i = 0; i < 13; i++)
            {
                deck.cards.Add(new Card("JO", "★"));
            }
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
            if (!isAnimating)
                renderer.PrintRoom(dungeon.CurrentRoom, health.GetHealth(), weapon, deck.GetCardCount() + dungeon.CurrentRoom.Count, escapeCount, ShowCardsRemaining);

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

            ClearInputLine();
            Console.Write(">> ");
        }
    }

    private int selectedCardIndex = -1;
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

        selectedCardIndex = index;

        Card chosen = dungeon.CurrentRoom[index];

        selectedCardIndex = index;

        if (chosen.Suit == "★")
        {
            
            ResolveCard(chosen, useFists);
        }
        else
        {
            
            dungeon.CurrentRoom.RemoveAt(index);
            ResolveCard(chosen, useFists);
        }


        if (dungeon.CurrentRoom.Count == 1 && deck.GetCardCount() > 0)
        {
            dungeon.DrawNextRoom();
            ResetActions();
          
        }
    }

    private void ResetActions()
    {
        hasHealed = false;
        escapeCount = SetSkips();
        enteringRoom = true;
    }


    private void ResolveHeart(Card card)           
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

            case "★":
                HandleJoker();
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

    private bool isAnimating = false;


    private void HandleJoker()
    {
        isAnimating = true;

        renderer.AnimateCardLaughs(dungeon.CurrentRoom, selectedCardIndex);

        dungeon.CurrentRoom.RemoveAt(selectedCardIndex);

        renderer.ClearHaSlots();

        dungeon.Reset();
        deck.Shuffle();
        dungeon.DrawNewRoom();
        ResetActions();

        isAnimating = false;
    }





}

// "♣", "♠", "♥", "♦" 
