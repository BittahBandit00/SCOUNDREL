using System;

public class OptionalRulesMenu
{
    private readonly OptionalRules rules;
    private readonly InputController input;

    public OptionalRulesMenu(OptionalRules rules, InputController input)
    {
        this.rules = rules;
        this.input = input;
    }

    public void Show()
    {
        while (true)
        {
            PrintMainMenu();
            string choice = input.GetAction().ToLower();

            switch (choice)
            {
                case "1":
                    ShowOptionalRules();
                    break;

                case "2":
                    ShowChallenges();
                    break;
                
                case "3":
                    rules.ResetToDefaults();
                    break;

                case "b":
                    return;

                default:
                    continue; // silent ignore
            }
        }
    }

    // ============================
    // MAIN MENU
    // ============================
    private void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("===============================================");
        Console.WriteLine("                 RULES MENU                    ");
        Console.WriteLine("===============================================");
        Console.WriteLine();
        Console.WriteLine("  [1] Optional Rules  (Easier)");
        Console.WriteLine("  [2] Challenge Modes (Harder)");
        Console.WriteLine("  [3] Default");
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("  [B] Back");
        Console.WriteLine("-----------------------------------------------");
        Console.Write("\n>> ");
    }

    // ============================
    // OPTIONAL RULES SUBMENU
    // ============================
    private void ShowOptionalRules()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("               OPTIONAL RULES                  ");
            Console.WriteLine("===============================================");
            Console.WriteLine();
            Console.WriteLine("  These options make the game easier.");
            Console.WriteLine();
            Console.WriteLine($"  [1] Show Encounters Left       : {(rules.ShowEncountersLeft ? "ON" : "OFF")}");
            Console.WriteLine($"  [2] Altered Weapon Can Match   : {(rules.AlteredWeaponCanMatch ? "ON" : "OFF")}");
            Console.WriteLine($"  [3] Double Escapes             : {(rules.DoubleSkip ? "ON" : "OFF")}");
            Console.WriteLine($"  [4] 25 Starting Health         : {(rules.ExtraHealth ? "ON" : "OFF")}");
            Console.WriteLine($"  [5] Low Aces                   : {(rules.LowAces ? "ON" : "OFF")}");
            Console.WriteLine($"  [6] Infinite Heals             : {(rules.InfiniteHeals ? "ON" : "OFF")}");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  [B] Back");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("\n>> ");

            string choice = input.GetAction().ToLower();

            switch (choice)
            {
                case "1": rules.ShowEncountersLeft = !rules.ShowEncountersLeft; break;
                case "2": rules.AlteredWeaponCanMatch = !rules.AlteredWeaponCanMatch; break;
                case "3": rules.DoubleSkip = !rules.DoubleSkip; break;
                case "4": rules.ExtraHealth = !rules.ExtraHealth; break;
                case "5": rules.LowAces = !rules.LowAces; break;
                case "6": rules.InfiniteHeals = !rules.InfiniteHeals; break;

                case "b":
                    return;

                default:
                    continue;
            }
        }
    }

    // ============================
    // CHALLENGES SUBMENU 
    // ============================
    private void ShowChallenges()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("                CHALLENGE MODES                ");
            Console.WriteLine("===============================================");
            Console.WriteLine();
            Console.WriteLine("  These options make the game harder.");
            Console.WriteLine();
            Console.WriteLine($"  [1] All Hearts Are One         : {(rules.AllHeartsAreOne ? "ON" : "OFF")}");
            Console.WriteLine($"  [2] Max Turn Count             : {(rules.TurnCount ? "ON" : "OFF")}");
            Console.WriteLine($"  [3] Double Encounters          : {(rules.DoubleEncounters ? "ON" : "OFF")}");
            Console.WriteLine($"  [4] Double Deck                : {(rules.DoubleDeck ? "ON" : "OFF")}");
            Console.WriteLine($"  [5] Limited Escapes            : {(rules.LimitedEscapes ? "ON" : "OFF")}");
            Console.WriteLine($"  [J] Chaotic Jokers             : {(rules.JokerShuffle ? "ON" : "OFF")}");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  [B] Back");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("\n>> ");

            string choice = input.GetAction().ToLower();
            switch (choice)
            {
                case "1": 
                    rules.AllHeartsAreOne = !rules.AllHeartsAreOne; 
                    break;
                case "2":
                    rules.TurnCount = !rules.TurnCount;
                    break;
                case "3":
                    rules.DoubleEncounters = !rules.DoubleEncounters;
                    break;
                case "4":
                    rules.DoubleDeck= !rules.DoubleDeck;
                    break;
                case "5":
                    rules.LimitedEscapes = !rules.LimitedEscapes;
                    break;
                case "j":
                    rules.JokerShuffle = !rules.JokerShuffle;
                    break;

                case "b":
                    return;

                default:
                    continue;
            }
        }
    }
}
