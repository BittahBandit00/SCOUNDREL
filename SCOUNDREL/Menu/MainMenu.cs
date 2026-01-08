using System;

public class MainMenu
{
    private OptionalRules optionalRules = new OptionalRules();
    private InputController input = new InputController();
    private OptionalRulesMenu optionalRulesMenu;
    private int quiteDelay = 1000;
    
    public MainMenu()
    {
        optionalRulesMenu = new OptionalRulesMenu(optionalRules, input);
    }



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
            Console.WriteLine("  [S]   Start Game");
            Console.WriteLine("  [R]   Rules & How to Play");
            Console.WriteLine("  [O]   Optional Rules");
            Console.WriteLine("  [C]   Credits");
            Console.WriteLine("  [Q]   Quit");
            Console.WriteLine();
            Console.Write("  >> ");


            string choice = input.GetAction();


            switch (choice)
            {
                case "q":
                    Console.WriteLine("\nSee you soon, Scoundrel...");
                    System.Threading.Thread.Sleep(quiteDelay);
                    Environment.Exit(0);
                    break;


                case "r":
                    Rules.Show();
                    continue;

                case "s":
                    Game game = new Game(optionalRules, this);
                    game.Start();
                    continue;

                case "c":
                    Credits.Show();
                    continue;

                case "o":
                    optionalRulesMenu.Show();
                    continue;

                //case "d": // DEBUG ONLY
                //   Renderer r = new Renderer();
                //    r.PrintWin();
                //    continue;


                default:
                    Console.WriteLine("\nUnknown command. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }
        }
    }


}
