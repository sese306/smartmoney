using System;
using System.Globalization;

namespace SmartMoneyJobRunner
{
    public class EstimateExpenses
    {
        public void Run()
        {
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + " Estimating Expenses");
        }
    }
}