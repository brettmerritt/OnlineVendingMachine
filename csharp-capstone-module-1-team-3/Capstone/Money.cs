using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Money
    {
        //test would create and infinite loop because currentBalance is set through a void method on program.cs
        public Money(decimal currentBalance)
        {
            CurrentBalance = currentBalance;
        }

        public decimal currentMoneyProvided = 0.00M;

        public decimal CurrentBalance { get; set; }

        //public const decimal dollarValue = 1m;
        public const decimal quarterValue = .25M;
        public const decimal dimeValue = .10M;
        public const decimal nickelValue = .05M;


    }
}
