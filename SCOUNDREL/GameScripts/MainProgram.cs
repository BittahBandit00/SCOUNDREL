using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class MainProgram
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        MainMenu mainMenu = new MainMenu();
        mainMenu.Show();
    }
}