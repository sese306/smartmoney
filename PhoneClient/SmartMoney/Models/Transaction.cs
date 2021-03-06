﻿using System;

namespace SmartMoney.Models
{
    public class Transaction
    {
        public DateTime Timestamp { get; set; }
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public Guid StopId { get; set; }
        public Guid CategoryId { get; set; }
        public Transaction()
        {
            Id = Guid.NewGuid();
        }

        public Transaction(Estimation estimation)
            : this()
        {
            Timestamp = DateTime.Now;
            Amount = estimation.Amount;
            StopId = estimation.StopId;
        }
    }
}
