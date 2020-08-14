using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu : Menu
    {
        public void DisplayMainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("Please enter the number of your choice: ");
        }
    }
}
