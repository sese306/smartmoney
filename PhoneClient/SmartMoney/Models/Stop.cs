using System;

namespace SmartMoney.Models
{
    public class Stop
    {
        public string Location { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public int Duration { get; set; }
    }
}
