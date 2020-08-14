using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Item
    {
        public Item (string itemID)
        {
            ItemID = itemID;
        }

        public string ItemID { get; }
        public string ItemName
        {
            get
            {
                Inventory inventory = new Inventory();
                return inventory.GoodsKeyDictionary[ItemID];
            }
           
        }
        public decimal ItemPrice
        {
            get
            {
                Inventory inventory = new Inventory();
                return inventory.ItemPriceDictionary[ItemName];
            }
        }
        public string ItemType
        {
            get
            {
                string itemType = "";
                if (ItemID.Contains("A"))
                {
                    itemType = "Chips";
                } else if (ItemID.Contains("B"))
                {
                    itemType = "Candy";
                } else if (ItemID.Contains("C"))
                {
                    itemType = "Drink";
                } else if (ItemID.Contains("D"))
                {
                    itemType = "Gum";
                }
                return itemType;
            }
        }

        public string ItemMessage(string ItemType)
        {
            string message = "";
            switch (ItemType)
            {
                case "Chips":
                    message = "Crunch Crunch, Yum!";
                    break;
                case "Candy":
                    message = "Munch Munch, Yum!";
                    break;
                case "Drink":
                    message ="Glug Glug, Yum!";
                    break;
                case "Gum":
                    message ="Chew Chew, Yum!";
                    break;
                }
            return message;

        }

        public bool ItemExists(string itemID)
        {
            Inventory inventory = new Inventory();
            return inventory.GoodsKeyDictionary.ContainsKey(itemID);
        }

    }
}
