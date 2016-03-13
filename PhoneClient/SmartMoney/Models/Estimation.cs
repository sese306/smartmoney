using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartMoney.Models
{
    public class Estimation
    {
        private static readonly List<string> Locations = new List<string>
                {
                    "Bila",
                    "Mojo",
                    "Metro",
                    "Peny",
                };

        public Guid StopId { get; set; }
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public Guid Id { get; set; }

        public string Location
        {
            get
            {
                var random = new Random();
                return Locations.ElementAt(random.Next(3));
            }
        }
    }
}