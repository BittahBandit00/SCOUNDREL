using System;

public class OptionalRulesMenu
{
    private OptionalRules rules;
    private InputController input;

    public OptionalRulesMenu(OptionalRules rules, InputController input)
    {
        this.rules = rules;
        this.input = input;
    }

    public void Show()
    {
        while (true)
        {
            PrintMenu();
            string choice = input.GetAction();

            switch (choice)

            {
                case "1":
                    rules.ShowEncountersLeft = !rules.ShowEncountersLeft;
                    break;
                case "2":
                    rules.AlteredWeaponCanMatch = !rules.AlteredWeaponCanMatch;
                    break;
                case "3":
                    rules.DoubleSkip = !rules.DoubleSkip;
                    break;
                case "4":
                    rules.ExtraHealth = !rules.ExtraHealth;
                    break;
                case "5":
                    rules.LowAces = !rules.LowAces;
                    break;
                case "6":
                    rules.InfiniteHeals = !rules.InfiniteHeals;
                    break;


                case "b":
                    return;

                default:
                    // silently ignore invalid input
                    continue;
            }
        }
    }

    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("===============================================");
        Console.WriteLine("               OPTIONAL RULES                  ");
        Console.WriteLine("===============================================");
        Console.WriteLine();
        Console.WriteLine("   WARNING: These options make the game");
        Console.WriteLine("            significantly easier.");
        Console.WriteLine();
        Console.WriteLine($"  [1]  Show Encounters Left       :  {(rules.ShowEncountersLeft ? "ON" : "OFF")}");
        Console.WriteLine($"  [2]  Altered Weapon Can Match   :  {(rules.AlteredWeaponCanMatch ? "ON" : "OFF")}");
        Console.WriteLine($"  [3]  Double Escapes             :  {(rules.DoubleSkip ? "ON" : "OFF")}");
        Console.WriteLine($"  [4]  25 Starting Health         :  {(rules.ExtraHealth ? "ON" : "OFF")}");
        Console.WriteLine($"  [5]  Low Aces                   :  {(rules.LowAces ? "ON" : "OFF")}");
        Console.WriteLine($"  [6]  Infinite Heals             :  {(rules.InfiniteHeals ? "ON" : "OFF")}");
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine(" [B] Back");
        Console.WriteLine("-----------------------------------------------");
        Console.Write("\n>> ");
    }

}
