using System;

public class InputController
{
    public string GetAction()
    {
        return Console.ReadLine().Trim().ToLower();
    }

    public string GetCardSelection(int max)
    {
        Console.WriteLine("CARD SELECTION");
        Console.WriteLine();
        Console.WriteLine($"  [1–{max}]   Choose a card");
        Console.WriteLine();
        Console.Write(">> ");
        return Console.ReadLine().Trim().ToLower();
    }

    public string GetRawInput()
    {
        return Console.ReadLine().Trim().ToLower();
    }
}
