using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InputController
{
    public string GetAction()
    {
        Console.Write("Type: Fight or Run > ");
        return Console.ReadLine().Trim().ToLower();
    }

    public int GetCardSelection(int max)
    {
        Console.Write($"Select card (1-{max}): ");
        string input = Console.ReadLine().Trim();

        if (int.TryParse(input, out int index))
            return index - 1;

        return -1;
    }
}

