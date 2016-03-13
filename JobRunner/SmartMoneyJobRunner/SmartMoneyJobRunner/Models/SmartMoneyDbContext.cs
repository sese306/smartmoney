using System.Data.Entity;

namespace SmartMoneyJobRunner.Models
{
    public class SmartMoneyDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Estimation> Estimations { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public SmartMoneyDbContext()
            : base("SmartMoneyConnectionString")
        {
            
        }
    }
}