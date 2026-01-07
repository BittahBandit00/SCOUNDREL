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
                    rules.ShowCardRemaining = !rules.ShowCardRemaining;
                    break;
                case "2":
                    rules.DoubleSkip = !rules.DoubleSkip;
                    break;
                case "3":
                    rules.ExtraHealth = !rules.DoubleSkip;
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

        Console.WriteLine($"  [1] Show Cards Remaining   :  {(rules.ShowCardRemaining ? "ON" : "OFF")}");
        Console.WriteLine($"  [2] Double Skip            :  {(rules.DoubleSkip ? "ON" : "OFF")}");
        Console.WriteLine($"  [3] Extra Health           :  {(rules.ExtraHealth ? "ON" : "OFF")}");
        Console.WriteLine();

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine(" [B] Back");
        Console.WriteLine("-----------------------------------------------");
        Console.Write("\n>> ");
    }

}
