﻿using System;

namespace SmartMoneyJobRunner.Models
{
    public class Account
    {
        public int Type { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Account ()
        {
            Id = Guid.NewGuid();
        }
    }
         
}