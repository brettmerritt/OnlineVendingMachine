using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void CSVTest()
        {
            Inventory csv = new Inventory();
            string expectedReturn = @"..\..\..\..\vendingmachine.csv";
            Assert.AreEqual(expectedReturn, csv.InputFile);
        }
        //tested the only method available to test to my knowlege.
    }


}
