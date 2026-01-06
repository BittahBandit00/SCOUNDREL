using System;

public class MainMenu
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=====================================================");
            Console.WriteLine("                  S C O U N D R E L                  ");
            Console.WriteLine("          Inspired by Zach Gage & Kurt Bieg          ");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.WriteLine("  [R]   Rules & How to Play");
            Console.WriteLine("  [S]   Start Game");
            Console.WriteLine("  [C]   Credits");
            Console.WriteLine("  [O]   Optional Rules (WIP)");
            Console.WriteLine("  [Q]   Quit");
            Console.WriteLine();
            Console.Write("  >> ");


            string input = Console.ReadLine().Trim().ToLower();

            switch (input)
            {
                case "q":
                    Console.WriteLine("\nSee you soon, Scoundrel. Exiting game...");
                    Environment.Exit(0);
                    break;

                case "r":
                    Rules.Show();
                    continue;

                case "s":
                    Game game = new Game();
                    game.Start();
                    continue;

                case "c":
                    Credits.Show();
                    continue;

                case "o":
                    Console.WriteLine("\nOptional rules are not implemented yet.");
                    Console.WriteLine("Press Enter to return to the menu...");
                    Console.ReadLine();
                    continue;

                case "d": // DEBUG ONLY
                    Renderer r = new Renderer();
                    r.PrintWin();
                    continue;


                default:
                    Console.WriteLine("\nUnknown command. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }
        }
    }


}
