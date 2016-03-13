using System;
using System.Globalization;
using System.Linq;
using SmartMoneyJobRunner.Models;

namespace SmartMoneyJobRunner
{
    public class DetectPOI
    {
        public void Run()
        {
            var smartMoneyDbContext = new SmartMoneyDbContext();
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + " Detecting POI");
            Console.WriteLine("Analyzing " + smartMoneyDbContext.Stops.Count() + " stops");
        }
    }
}