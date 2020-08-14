using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Inventory
    {


        public string InputFile
        {
            get
            {
                string directory = @"..\..\..\..";
                string filename = "vendingmachine.csv";
                return Path.Combine(directory, filename);
            }
        }

        public Dictionary<string, int> stock = new Dictionary<string, int>
            {
                    {"A1", 5 }, {"A2", 5 }, {"A3", 5 }, {"A4", 5 },
                    {"B1", 5 }, {"B2", 5 }, {"B3", 5 }, {"B4", 5 },
                    {"C1", 5 }, {"C2", 5 }, {"C3", 5 }, {"C4", 5 },
                    {"D1", 5 }, {"D2", 5 }, {"D3", 5 }, {"D4", 5 },
             };



        //holds ID and Name
        public Dictionary<string, string> GoodsKeyDictionary
        {
            get
            {
                Dictionary<string, string> allGoods = new Dictionary<string, string>();
                using (StreamReader sr = new StreamReader(InputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] goodsArray = line.Split("|");
                        allGoods.Add(goodsArray[0], goodsArray[1]);

                    }
                }
                return allGoods;
            }
        }
        //Holds Name and Price 
        public Dictionary<string, decimal> ItemPriceDictionary
        {
            get
            {
                Dictionary<string, decimal> PriceDictionary = new Dictionary<string, decimal>();
                using (StreamReader sr = new StreamReader(InputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] goodsArray = line.Split("|");
                        PriceDictionary.Add(goodsArray[1], decimal.Parse(goodsArray[2]));

                    }
                }
                return PriceDictionary;
            }
        }
    }
}

