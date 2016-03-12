using System;

namespace SmartMoneyJobRunner.Models
{
    public class Category
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Category()
        {
            Id = Guid.NewGuid();
        }
    }
}