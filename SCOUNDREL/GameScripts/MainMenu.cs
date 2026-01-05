using System;

public class MainMenu
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("                     S C O U N D R E L              ");
            Console.WriteLine("====================================================");
            Console.WriteLine();
            Console.WriteLine("  [R]    Learn how to play");
            Console.WriteLine("  [S]    Start the game");
            Console.WriteLine("  [O]    Optional Rules - WIP");
            Console.WriteLine("  [Q]    Quit");
            Console.WriteLine();
            Console.Write("  >> ");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "q")
            {
                Console.WriteLine("\nExiting game...");
                Environment.Exit(0);
            }

            if (input == "r")
            {
                Rules.Show();
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
                continue;
            }

            if (input == "s")
            {
                Game game = new Game();
                game.Start();
                return;
            }

            Console.WriteLine("\nUnknown command. Press Enter to try again.");
            Console.ReadLine();
        }
    }
}
