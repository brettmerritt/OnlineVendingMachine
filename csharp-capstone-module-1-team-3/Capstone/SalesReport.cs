using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class SalesReport
    {

        //public string OutputFile()
        //{
        //    string today = DateTime.Now.ToString("yyyy-MMdd");
        //    string outputDirectory = @"..\..\..\..";
        //    string outputFileName = $"SalesReport{today}.txt";
        //    string outputFullPath = Path.Combine(outputDirectory, outputFileName);
        //    return outputFullPath;
        //}

        ////Contains itemID of each item and the number sold
        //public Dictionary<string, int> SalesReportDictionary = new Dictionary<string, int>();


        //public void GenerateEmptyReport()
        //{
        //    Inventory inventory = new Inventory();
        //    foreach (KeyValuePair<string, string> kvp in inventory.GoodsKeyDictionary)
        //    {
        //        SalesReportDictionary.Add(kvp.Key, 0);
        //    }

        //}

        //public Dictionary<string, int> UpdateSalesReport(string itemID)
        //{
        //    //Dictionary<string, int> salesReport = new Dictionary<string, int>();
        //    if (SalesReportDictionary.ContainsKey(itemID))
        //    {

        //        int newValue = SalesReportDictionary[itemID] + 1;
        //        SalesReportDictionary[itemID] = newValue;

        //    }
        //    return SalesReportDictionary;
        //}

        //public string TotalSales()
        //{
        //    decimal totalSales = 0.0M;
        //    foreach (KeyValuePair<string, int> kvp in SalesReportDictionary)
        //    {
        //        Item item = new Item(kvp.Key);
        //        totalSales = item.ItemPrice * kvp.Value;
        //    }
        //    return $"Total Sales: {totalSales}";
        //}

        //public void LogSalesReport()
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(OutputFile(), true))
        //        {
        //            foreach(KeyValuePair<string, int> kvp in SalesReportDictionary)
        //            {
        //                sw.WriteLine($"{kvp.Key} | {kvp.Value}");
        //            }
        //            sw.WriteLine(TotalSales());
        //        }
        //    }
        //    catch (IOException ioe)
        //    {
        //        Console.WriteLine("There was an error getting the sales report file.");
        //        Console.WriteLine(ioe.Message);
        //    } catch (Exception e)
        //    {
        //        Console.WriteLine("There was an error");
        //        Console.WriteLine(e.Message);
        //    }
        //}




    }
}
