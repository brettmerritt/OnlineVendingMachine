using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {

        Inventory inventory = new Inventory();
        public void DispenseItem(string itemID, decimal currentBalance)
        {
            Item item = new Item(itemID);
            int currentNumber = inventory.stock[itemID];
            inventory.stock[itemID] = --currentNumber;
            Console.WriteLine($"Dispensing your {item.ItemName}. It cost {item.ItemPrice}. You have a remaining balance of {currentBalance - item.ItemPrice}");
            Console.WriteLine(item.ItemMessage(item.ItemType));
            //currentBalance = currentBalance - item.ItemPrice;
        }
        public void DisplayItems()
        {
            
            foreach (KeyValuePair<string, string> kvp in inventory.GoodsKeyDictionary)
            {
                Item item = new Item(kvp.Key);
                if (inventory.stock[kvp.Key] == 0)
                {
                    Console.WriteLine($"{kvp.Key}] {kvp.Value} - ${item.ItemPrice}  Available: SOLD OUT");
                } else
                {
                    Console.WriteLine($"{kvp.Key}] {kvp.Value} - ${item.ItemPrice}  Available: {inventory.stock[kvp.Key]}");
                }

            }
        }
        public bool IsOutOfStock(string itemID)
        {
            return (inventory.stock[itemID] < 1);
        }

        public string GiveChange(decimal change)
        {
            Money money = new Money(change);
            //variables
            decimal totalChange = change;
            //int dollarAmount = 0;
            int quarterAmount = 0;
            int dimeAmount = 0;
            int nickelAmount = 0;
            string result = "";
        
        
            //dollarAmount = (int)(change / Money.dollarValue);
            //change -= dollarAmount / Money.dollarValue;
            quarterAmount = (int)(change / Money.quarterValue);
            change -= quarterAmount * Money.quarterValue;
            dimeAmount = (int)(change / Money.dimeValue);
            change -= dimeAmount * Money.dimeValue;
            nickelAmount = (int)(change / Money.nickelValue);
            change -= nickelAmount * Money.nickelValue;

            //print-out of change 
            if (totalChange < 0)
            {
                result = "No Change For You!!!";
            }
            //else if (quarterAmount == 0 && nickelAmount == 0 && dimeAmount == 0)
            //{
            //    result = $"Your Change Is {dollarAmount} Dollar(s) For a Total of ${totalChange}.";
            //}
            else if (nickelAmount == 0 && dimeAmount == 0)
            {
                result = $"Your Change Is {quarterAmount} Quarter(s) For a Total of ${totalChange}.";
            }
            else if (dimeAmount == 0)
            {
                result = $"Your Change Is {quarterAmount} Quarter(s) and {nickelAmount} Nickel(s) For a Total of ${totalChange}.";
            }
            else if (nickelAmount == 0)
            {
                result = $"Your Change Is {quarterAmount} Quarter(s) and {dimeAmount} Dime(s) For a Total of ${totalChange}.";
            }
            else
            {
                result = $"Your Change Is {quarterAmount} Quarter(s), {dimeAmount} Dime(s) and {nickelAmount} Nickel(s) For a Total of ${totalChange}.";
            }
            return result;
        }

    }

}
