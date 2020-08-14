using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Vendo-Matic 800!");
            decimal currentBalance = 0.00M;
            VendingMachine vendoMatic = new VendingMachine();
            //SalesReport salesReport = new SalesReport();
            MainMenu main = new MainMenu();
            PurchaseMenu purchase = new PurchaseMenu();
            Money money = new Money(currentBalance);


            bool showMainMenu = true;
            while (showMainMenu)
            {
                main.DisplayMainMenu();
                string userInputMain = Console.ReadLine();
                switch (userInputMain)
                {
                    case "1":
                        vendoMatic.DisplayItems();
                        main.menuSpacer();
                        showMainMenu = true;
                        break;
                    case "2":
                        purchase.PurchaseItemsMenu(money.CurrentBalance);
                        showMainMenu = true;
                        break;
                    //case "4":
                    //    Console.WriteLine("Sales Report");
                    //    main.menuSpacer();
                    //    //PrintSalesReport();
                    //    showMainMenu = true;
                    //    break;
                    case "3":
                        //salesReport.LogSalesReport();
                        showMainMenu = false;
                        break;
                    default:
                        showMainMenu = true;
                        break;
                }
            }

            main.menuSpacer();
            Console.WriteLine("Thank you! Please come again!");

        }

    }
}
