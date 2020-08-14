using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu : Menu
    {
        DateTime now = DateTime.Now;
        VendingMachine vendoMatic = new VendingMachine();
        SalesReport salesReport = new SalesReport();
        public string outputFile  //creates path to log purchases
        {
            get
            {
                string outputDirectory = @"..\..\..\..";
                string outputFileName = "Log.txt";
                string outputFullPath = Path.Combine(outputDirectory, outputFileName);
                return outputFullPath;
            }
        }

        public void PurchaseItemsMenu(decimal currentBalance) //Purchase Items Menu
        {
            bool repeatMenu = true;
            while (repeatMenu)
            {
                base.menuSpacer();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine();
                string userInputPurchase = Console.ReadLine();
                if (userInputPurchase == "1")
                {
                    currentBalance = UserInput1(currentBalance);
                }
                else if (userInputPurchase == "2")
                {
                    currentBalance = UserInput2(currentBalance);
                }
                else if (userInputPurchase == "3")
                {
                    UserInput3(currentBalance);
                    repeatMenu = false;
                }
                else
                {
                    Console.WriteLine("Please choose an option from the menu provided.");
                }
            }
        }

        public decimal UserInput1(decimal currentBalance) //Feed Money
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Please insert money in whole dollars($1, $2, $5, or $10)");
            string currentMoneyProvidedString = Console.ReadLine();
            decimal newCurrentMoneyProvided = decimal.Parse(currentMoneyProvidedString);
            if (newCurrentMoneyProvided % 1 != 0)
            {
                Console.WriteLine("This VendoMatic only accepts whole bills");
                return currentBalance;
            }
            currentBalance = currentBalance + newCurrentMoneyProvided;
            Console.WriteLine("Current money provided: " + "$" + currentBalance);

            try
            {
                using (StreamWriter sw = new StreamWriter(outputFile, true))
                {
                    sw.WriteLine(now.ToString() + " " + "FEED MONEY: " + "$" + newCurrentMoneyProvided + " " + "$" + currentBalance);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error");
                Console.WriteLine(e.Message);
            }

            return currentBalance;

        }
        //test would create and infinite loop because currentBalance is set through a void method on program.cs
        public decimal UserInput2(decimal currentBalance) //Purchase item
        {
            vendoMatic.DisplayItems();
            Console.WriteLine("Please enter the location code for your item.");
            string enteredItemID = Console.ReadLine().ToUpper();
            Item selectedItem = new Item(enteredItemID);

            //check if entered Item ID exists
            if (!selectedItem.ItemExists(enteredItemID))
            {
                Console.WriteLine("You have entered an invalid item code");
            }
            else if (selectedItem.ItemExists(enteredItemID) && vendoMatic.IsOutOfStock(enteredItemID))
            {
                Console.WriteLine("The item you selected is SOLD OUT");
            }
            else if (currentBalance >= selectedItem.ItemPrice) //Purchse Item succesful
            {
                vendoMatic.DispenseItem(enteredItemID, currentBalance);
                currentBalance = currentBalance - selectedItem.ItemPrice;
                //salesReport.UpdateSalesReport(enteredItemID);
                try
                {
                    using (StreamWriter sw = new StreamWriter(outputFile, true))
                    {
                        sw.WriteLine(now.ToString() + $" {selectedItem.ItemName} {selectedItem.ItemID} ${currentBalance + selectedItem.ItemPrice} ${currentBalance}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error");
                    Console.WriteLine(e.Message);
                    //return to PurchaseItems menu and rerun
                }
            }
            else if (currentBalance < selectedItem.ItemPrice)
            {
                Console.WriteLine("You do not have enough money to make that purchase. Please input money.");
            }

            return currentBalance;


        }

        public void UserInput3(decimal currentBalance)
        {

            Money money = new Money(currentBalance);
            decimal changeNeeded = money.CurrentBalance;
            Console.WriteLine(vendoMatic.GiveChange(changeNeeded));
            try
            {
                using (StreamWriter sw = new StreamWriter(outputFile, true))
                {
                    sw.WriteLine(now.ToString() + $" GIVE CHANGE: ${currentBalance} $0.00");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error");
                Console.WriteLine(e.Message);

            }


        }


    }
}
